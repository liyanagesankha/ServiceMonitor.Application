using ServiceMonitor.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceMonitor.Business
{
    /// <summary>
    /// This class contains schedule management related methods
    /// </summary>
    public class HealthCheckManager
    {
        /// <summary>
        /// Hold all observers
        /// </summary>
        private IList<HealthCheckScheduleObserver> healthCheckSheduleObservers = new List<HealthCheckScheduleObserver>();

        /// <summary>
        /// hold the current userSchedule
        /// </summary>
        private IList<UserSchedule> userScheduleList;

        /// <summary>
        /// Get and Set User Schedule
        /// </summary>
        public IList<UserSchedule> UserScheduleList
        {
            get
            {
                return this.userScheduleList;
            }
            set
            {
                this.userScheduleList = value;
                NotifySelectedlObserverToUpdateShedule();
            }
        }

        /// <summary>
        /// Hold new healthCheckSheduleObserver in HealthCheckManager
        /// </summary>
        /// <param name="healthCheckSheduleObserver"></param>
        public void Attach(HealthCheckScheduleObserver healthCheckSheduleObserver)
        {
            healthCheckSheduleObservers.Add(healthCheckSheduleObserver);
        }

        /// <summary>
        /// Notify All Observers regarding the new schedule
        /// </summary>
        private void NotifySelectedlObserverToUpdateShedule()
        {
            foreach (HealthCheckScheduleObserver healthCheckSheduler in healthCheckSheduleObservers)
            {
                healthCheckSheduler.UpdateSchedule();
            }
        }
    }
}
