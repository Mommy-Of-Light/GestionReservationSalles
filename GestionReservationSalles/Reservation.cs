using System;

namespace GestionReservationSalles
{
    public class Reservation
    {
        public int IdUser { get; set; }
        public int IdRoom { get; set; }
        public DateTime Date { get; set; }
        public string Hours { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public string RoomName { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{Date:yyyy-MM-dd} {Hours} - {ClassName} (Room: {RoomName})";
        }
    }
}
