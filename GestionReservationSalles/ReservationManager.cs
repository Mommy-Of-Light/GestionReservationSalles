using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace GestionReservationSalles
{
    public class ReservationManager
    {
        private string connectionString = DbConfig.ConnectionString;

        public List<Reservation> GetReservationsForRoom(int idRoom)
        {
            var list = new List<Reservation>();
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("SELECT r.IdUser, r.IdRoom, r.Date, r.Hours, r.ClassName, RO.Name AS RoomName FROM Reservations r JOIN Rooms RO ON r.IdRoom = RO.IdRoom WHERE r.IdRoom = @idRoom ORDER BY r.Date", conn))
                    {
                        cmd.Parameters.AddWithValue("@idRoom", idRoom);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new Reservation
                                {
                                    IdUser = Convert.ToInt32(reader["IdUser"]),
                                    IdRoom = Convert.ToInt32(reader["IdRoom"]),
                                    Date = Convert.ToDateTime(reader["Date"]),
                                    Hours = reader["Hours"].ToString() ?? string.Empty,
                                    ClassName = reader["ClassName"].ToString() ?? string.Empty,
                                    RoomName = reader["RoomName"].ToString() ?? string.Empty
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading reservations: {ex.Message}");
            }
            return list;
        }

        public List<Reservation> GetReservationsForUser(int idUser)
        {
            var list = new List<Reservation>();
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("SELECT r.IdUser, r.IdRoom, r.Date, r.Hours, r.ClassName, RO.Name AS RoomName FROM Reservations r JOIN Rooms RO ON r.IdRoom = RO.IdRoom WHERE r.IdUser = @idUser ORDER BY r.Date", conn))
                    {
                        cmd.Parameters.AddWithValue("@idUser", idUser);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new Reservation
                                {
                                    IdUser = Convert.ToInt32(reader["IdUser"]),
                                    IdRoom = Convert.ToInt32(reader["IdRoom"]),
                                    Date = Convert.ToDateTime(reader["Date"]),
                                    Hours = reader["Hours"].ToString() ?? string.Empty,
                                    ClassName = reader["ClassName"].ToString() ?? string.Empty,
                                    RoomName = reader["RoomName"].ToString() ?? string.Empty
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading reservations for user: {ex.Message}");
            }
            return list;
        }

        public bool AddReservation(Reservation r)
        {
            // enforce server-side role check: only teachers and admins can create reservations
            var current = UserManager.Instance.CurrentUser;
            if (current == null) return false;
            if (current.Role != "teacher" && current.Role != "admin") return false;

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("INSERT INTO Reservations (IdUser, IdRoom, Date, Hours, ClassName) VALUES (@u, @r, @d, @h, @c)", conn))
                    {
                        cmd.Parameters.AddWithValue("@u", r.IdUser);
                        cmd.Parameters.AddWithValue("@r", r.IdRoom);
                        cmd.Parameters.AddWithValue("@d", r.Date.Date);
                        cmd.Parameters.AddWithValue("@h", r.Hours);
                        cmd.Parameters.AddWithValue("@c", r.ClassName);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding reservation: {ex.Message}");
                return false;
            }
        }

        public bool DeleteReservation(Reservation r)
        {
            // only allow deletion if current user is the reserver or an admin
            var current = UserManager.Instance.CurrentUser;
            if (current == null) return false;
            if (current.Role != "admin" && current.IdUser != r.IdUser) return false;

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("DELETE FROM Reservations WHERE IdUser = @u AND IdRoom = @rId AND Date = @d AND Hours = @h AND ClassName = @c LIMIT 1", conn))
                    {
                        cmd.Parameters.AddWithValue("@u", r.IdUser);
                        cmd.Parameters.AddWithValue("@rId", r.IdRoom);
                        cmd.Parameters.AddWithValue("@d", r.Date.Date);
                        cmd.Parameters.AddWithValue("@h", r.Hours);
                        cmd.Parameters.AddWithValue("@c", r.ClassName);
                        int affected = cmd.ExecuteNonQuery();
                        return affected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting reservation: {ex.Message}");
                return false;
            }
        }
    }
}
