using Prometheus;

namespace GestionReservationSalles
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var server = new MetricServer(hostname: "localhost", port: 9091);

            server.Start();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            // Use the singleton instance so the same FrmLogin object is reused across navigation
            Application.Run(FrmLogin.Instance);
        }
    }
}