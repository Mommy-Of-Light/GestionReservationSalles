namespace GestionReservationSalles
{
    public static class DbConfig
    {
        // Update these values to match your environment
        public static string ConnectionString { get; } = "Server=localhost;Database=gestion_salles;User=dev;Password=super;";
        public static string ServerConnectionString { get; } = "Server=localhost;User=dev;Password=super;";
    }
}
