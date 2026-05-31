namespace GestionReservationSalles
{
    public class User
    {
        public int IdUser { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = "user";

        public override string ToString()
        {
            return $"{Name} ({Email}) - {Role}";
        }
    }
}
