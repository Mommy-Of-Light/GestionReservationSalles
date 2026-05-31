using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;

namespace GestionReservationSalles  
{
    internal class UserManager
    {
        public static UserManager Instance { get; private set; } = new UserManager();

        public User? CurrentUser { get; private set; }

        private string connectionString = DbConfig.ConnectionString;
        private string serverConnectionString = DbConfig.ServerConnectionString;

        public UserManager()
        {
            EnsureDatabaseCreated();
        }

        public bool DeleteUser(int idUser)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (var tran = conn.BeginTransaction())
                    {
                        // remove reservations by this user first to satisfy FK
                        using (var delRes = new MySqlCommand("DELETE FROM Reservations WHERE IdUser = @id", conn, tran))
                        {
                            delRes.Parameters.AddWithValue("@id", idUser);
                            delRes.ExecuteNonQuery();
                        }

                        using (var delUser = new MySqlCommand("DELETE FROM Users WHERE IdUser = @id", conn, tran))
                        {
                            delUser.Parameters.AddWithValue("@id", idUser);
                            int affected = delUser.ExecuteNonQuery();
                            tran.Commit();
                            return affected > 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting user: {ex.Message}");
                return false;
            }
        }

        private void EnsureDatabaseCreated()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(serverConnectionString))
                {
                    conn.Open();

                    // Drop the database at start (useful for development). This is a single line —
                    // comment it out if you want to keep the database between runs.
                    //new MySqlCommand("DROP DATABASE IF EXISTS gestion_salles;", conn).ExecuteNonQuery();

                    // Create database if it does not exist
                    using (MySqlCommand cmd = new MySqlCommand("CREATE DATABASE IF NOT EXISTS gestion_salles CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Create Users table if it does not exist (use InnoDB for foreign keys)
                    using (MySqlCommand cmd = new MySqlCommand("CREATE TABLE IF NOT EXISTS gestion_salles.Users (IdUser INT AUTO_INCREMENT PRIMARY KEY, Name VARCHAR(100) NOT NULL, Email VARCHAR(255) NOT NULL UNIQUE, Password VARCHAR(255) NOT NULL, Role VARCHAR(50) NOT NULL) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Create Rooms table
                    using (MySqlCommand cmd = new MySqlCommand("CREATE TABLE IF NOT EXISTS gestion_salles.Rooms (IdRoom INT AUTO_INCREMENT PRIMARY KEY, Name VARCHAR(100) NOT NULL, Capacity INT NOT NULL, Building VARCHAR(100) NOT NULL, Floor INT NOT NULL) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Create Reservations table (no primary key as requested)
                    using (MySqlCommand cmd = new MySqlCommand("CREATE TABLE IF NOT EXISTS gestion_salles.Reservations (IdUser INT NOT NULL, IdRoom INT NOT NULL, Date DATE NOT NULL, Hours VARCHAR(50) NOT NULL, ClassName VARCHAR(100) NOT NULL, FOREIGN KEY (IdUser) REFERENCES gestion_salles.Users(IdUser), FOREIGN KEY (IdRoom) REFERENCES gestion_salles.Rooms(IdRoom)) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Seed default users if table is empty
                    using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM gestion_salles.Users;", conn))
                    {
                        long count = Convert.ToInt64(cmd.ExecuteScalar());
                        if (count == 0)
                        {
                            using (MySqlCommand insert = new MySqlCommand("INSERT INTO gestion_salles.Users (Name, Email, Password, Role) VALUES (@n1, @e1, @p1, 'admin'), (@n2, @e2, @p2, 'user');", conn))
                            {
                                insert.Parameters.AddWithValue("@n1", "Admin");
                                insert.Parameters.AddWithValue("@e1", "admin@exemple.com");
                                insert.Parameters.AddWithValue("@p1", "admin123");
                                insert.Parameters.AddWithValue("@n2", "User");
                                insert.Parameters.AddWithValue("@e2", "user@exemple.com");
                                insert.Parameters.AddWithValue("@p2", "user123");
                                insert.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating database or tables: {ex.Message}");
            }
        }

        public bool Authenticate(string email, string password)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Users WHERE Email = @Email AND Password = @Password";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var user = new User();
                                // Some existing schemas may have column named IdUser or Id. Try both.
                                try
                                {
                                    user.IdUser = reader["IdUser"] != DBNull.Value ? Convert.ToInt32(reader["IdUser"]) : 0;
                                }
                                catch
                                {
                                    user.IdUser = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0;
                                }

                                user.Name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : string.Empty;
                                user.Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : string.Empty;
                                user.Password = reader["Password"] != DBNull.Value ? reader["Password"].ToString() : string.Empty;
                                user.Role = reader["Role"] != DBNull.Value ? reader["Role"].ToString() : string.Empty;

                                CurrentUser = user;
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error authenticating user: {ex.Message}");
            }

            return false;
        }

        public void Logout()
        {
            CurrentUser = null;
        }

        public List<User> GetAllUsers()
        {
            var list = new List<User>();
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("SELECT IdUser, Name, Email, Password, Role FROM Users", conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new User
                            {
                                IdUser = Convert.ToInt32(reader["IdUser"]),
                                Name = reader["Name"].ToString() ?? string.Empty,
                                Email = reader["Email"].ToString() ?? string.Empty,
                                Password = reader["Password"].ToString() ?? string.Empty,
                                Role = reader["Role"].ToString() ?? string.Empty
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting users: {ex.Message}");
            }

            return list;
        }

        public bool UpdateUserRole(int idUser, string role)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("UPDATE Users SET Role = @role WHERE IdUser = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@role", role);
                        cmd.Parameters.AddWithValue("@id", idUser);
                        int affected = cmd.ExecuteNonQuery();
                        return affected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating user role: {ex.Message}");
                return false;
            }
        }

        public bool Register(string name, string email, string password)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Email", email);
                        long count = Convert.ToInt64(checkCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            return false; 
                        }
                    }

                    string insertQuery = "INSERT INTO Users (Name, Email, Password, Role) VALUES (@Name, @Email, @Password, 'user')";
                    using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@Name", name);
                        insertCmd.Parameters.AddWithValue("@Email", email);
                        insertCmd.Parameters.AddWithValue("@Password", password);
                        insertCmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error registering user: {ex.Message}");
                return false;
            }
        }
    }
}
