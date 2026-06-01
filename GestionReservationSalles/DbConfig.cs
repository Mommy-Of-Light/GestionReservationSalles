namespace GestionReservationSalles
{
    public static class DbConfig
    {
        // Update these values to match your environment
        public static string ConnectionString { get; } = "Server=localhost;Database=gestion_salles;User=bastien;Password=super;";
        public static string ServerConnectionString { get; } = "Server=localhost;User=bastien;Password=super;";
    }
}
