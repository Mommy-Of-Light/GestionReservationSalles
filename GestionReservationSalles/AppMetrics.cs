using Prometheus;

namespace GestionReservationSalles
{
    public static class AppMetrics
    {
        public static readonly Counter SuccessfulLogins =
            Metrics.CreateCounter(
                "grs_logins_total",
                "Successful logins");

        public static readonly Counter FailedLogins =
            Metrics.CreateCounter(
                "grs_failed_logins_total",
                "Failed logins");

        public static readonly Gauge ActiveUsers =
            Metrics.CreateGauge(
                "grs_active_users",
                "Current active users");

        public static readonly Counter ReservationCreated =
            Metrics.CreateCounter(
                "grs_reservations_created_total",
                "Reservations created");

        public static readonly Counter ReservationCancelled =
            Metrics.CreateCounter(
                "grs_reservations_cancelled_total",
                "Reservations cancelled");

        public static readonly Histogram ReservationLoadTime =
            Metrics.CreateHistogram(
                "grs_load_reservations_seconds",
                "Time spent loading reservations");
    }
}