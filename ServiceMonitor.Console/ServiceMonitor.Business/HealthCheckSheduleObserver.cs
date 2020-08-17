namespace ServiceMonitor.Business
{
    /// <summary>
    /// Schedule Observer
    /// </summary>
    public abstract class HealthCheckScheduleObserver
    {
        /// <summary>
        /// Initiated Health Manager
        /// </summary>
        protected HealthCheckManager healthCheckManager;

        /// <summary>
        /// Method to update all schedules
        /// </summary>
        public abstract void UpdateSchedule();
    }
}
