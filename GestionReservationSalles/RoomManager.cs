using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace GestionReservationSalles
{
    public class RoomManager
    {
        private string connectionString = DbConfig.ConnectionString;
        public List<Room> GetAllRooms()
        {
            var list = new List<Room>();
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("SELECT IdRoom, Name, Capacity, Building, Floor FROM Rooms", conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Room
                            {
                                IdRoom = Convert.ToInt32(reader["IdRoom"]),
                                Name = reader["Name"].ToString() ?? string.Empty,
                                Capacity = Convert.ToInt32(reader["Capacity"]),
                                Building = reader["Building"].ToString() ?? string.Empty,
                                Floor = Convert.ToInt32(reader["Floor"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading rooms: {ex.Message}");
            }

            return list;
        }

        public bool AddRoom(Room room)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("INSERT INTO Rooms (Name, Capacity, Building, Floor) VALUES (@n, @c, @b, @f)", conn))
                    {
                        cmd.Parameters.AddWithValue("@n", room.Name);
                        cmd.Parameters.AddWithValue("@c", room.Capacity);
                        cmd.Parameters.AddWithValue("@b", room.Building);
                        cmd.Parameters.AddWithValue("@f", room.Floor);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding room: {ex.Message}");
                return false;
            }
        }

        public bool DeleteRoom(int idRoom)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (var tran = conn.BeginTransaction())
                    {
                        // delete reservations for the room first
                        using (var delRes = new MySqlCommand("DELETE FROM Reservations WHERE IdRoom = @id", conn, tran))
                        {
                            delRes.Parameters.AddWithValue("@id", idRoom);
                            delRes.ExecuteNonQuery();
                        }

                        using (var delRoom = new MySqlCommand("DELETE FROM Rooms WHERE IdRoom = @id", conn, tran))
                        {
                            delRoom.Parameters.AddWithValue("@id", idRoom);
                            int affected = delRoom.ExecuteNonQuery();
                            tran.Commit();
                            return affected > 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting room: {ex.Message}");
                return false;
            }
        }
    }
}
