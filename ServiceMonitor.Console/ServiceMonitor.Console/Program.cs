#region Using Directives
using ServiceMonitor.Business;
using ServiceMonitor.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading;
#endregion Using Directives

namespace ServiceMonitor.Application
{
    /// <summary>
    /// Main Class
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nInitiate Health Check manager.");
            HealthCheckManager _healthCheckManager = new HealthCheckManager();

            Console.WriteLine("\nInitiate Health Check Scheduler.");
            new HealthCheckScheduler(_healthCheckManager);

            Console.WriteLine("\nGet all user schedules form remote service.");
            IList<UserSchedule> allUserSchedules = new RemoteService().GetAllUsersScheduleList();

            Console.WriteLine("\nSchedules push to health check manager..");
            _healthCheckManager.UserScheduleList = allUserSchedules;

            //Delay the thread for 10 min
            //Thread.Sleep(10000);
            //Console.WriteLine("\n\nupdating schedules settings...");

            ////Delay the thread for 10 min
            //Thread.Sleep(5000);
            //Console.WriteLine("\n\n settings updated ...");

            //Console.WriteLine("\nUpdated schedules push to Health Manager");
            //_healthCheckManager.UserScheduleList = new RemoteService().GetUpdatedUserSchedules();

            Console.ReadLine();
        }
    }
}
