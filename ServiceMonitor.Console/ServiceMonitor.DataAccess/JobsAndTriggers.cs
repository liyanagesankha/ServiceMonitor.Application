namespace ServiceMonitor.DataAccess
{
    /// <summary>
    /// This class contains job and its triggers data
    /// </summary>
    public class JobsAndTriggers
    {
        public string jobIdentityKey { get; set; }
        public string TriggerIdentityKey { get; set; }
        public string JobDataUserAndUrl { get; set; }
        public int ScheduleIntervalInSec { get; set; }
    }
}
