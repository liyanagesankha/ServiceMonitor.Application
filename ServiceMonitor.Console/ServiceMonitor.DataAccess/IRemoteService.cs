#region Using Directives
using System.Collections.Generic;
#endregion Using Directives

namespace ServiceMonitor.DataAccess
{
    /// <summary>
    /// This interface contains service calls to get requested service data
    /// </summary>
    public interface IRemoteService
    {
        /// <summary>
        /// Return all schedules
        /// </summary>
        /// <returns></returns>
        public IList<UserSchedule> GetAllUsersScheduleList();

        /// <summary>
        /// Return specific user's schedule
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IList<UserSchedule> GetUpdatedUserSchedules();
    }
}
