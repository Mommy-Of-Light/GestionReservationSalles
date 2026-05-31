namespace GestionReservationSalles
{
    public class Room
    {
        public int IdRoom { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string Building { get; set; } = string.Empty;
        public int Floor { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Building} floor {Floor}, cap {Capacity})";
        }
    }
}
