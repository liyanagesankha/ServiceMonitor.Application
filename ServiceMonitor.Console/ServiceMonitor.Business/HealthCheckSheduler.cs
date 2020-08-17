#region Using Directives
using ServiceMonitor.DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using System.Linq;

#endregion Using Directives

namespace ServiceMonitor.Business
{
    /// <summary>
    /// This class contains schedule related logic
    /// </summary>
    public class HealthCheckScheduler : HealthCheckScheduleObserver
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="healthCheckManager"></param>
        public HealthCheckScheduler(HealthCheckManager healthCheckManager)
        {
            this.healthCheckManager = healthCheckManager;
            this.healthCheckManager.Attach(this);
        }

        /// <summary>
        /// Update specific schedules
        /// </summary>
        public override void UpdateSchedule()
        {
            Console.WriteLine("\tCheck new schedules....");
            IList<UserSchedule> userScheduleList = this.healthCheckManager.UserScheduleList;
            List<JobsAndTriggers> LstobjJobsAndTriggers = new List<JobsAndTriggers>();

            foreach (UserSchedule userSchedule in userScheduleList)
            {
                User user = userSchedule.User;
                foreach (var service in userSchedule.Services)
                {
                    string usernameAndUrl = "[" + user.Name + "]" + " - http://" + service.Host + ":" + service.Port.ToString() + " (" + service.Name + ") :";
                    Console.WriteLine("\n\t\t" + user.Name + " requested to check [" + service.Name + "] -[http://" + service.Host + ":" + service.Port + "/] service health in every [" + service.Frequency + "] seconds.");
                    Console.WriteLine("\t\tSystem is going to create new recurring job for this.");

                    string identityKey = user.Id.ToString() + "_" + service.Id.ToString();

                    LstobjJobsAndTriggers.Add(new JobsAndTriggers
                    {
                        jobIdentityKey = "JOB_KEY_" + identityKey,
                        TriggerIdentityKey = "TRIGGER1_" + identityKey,
                        JobDataUserAndUrl = user.Name + ";#" + service.Name + ";#" + service.Host + ";#" + service.Port.ToString(),
                        ScheduleIntervalInSec = service.Frequency
                    });
                }
            }
            JobFactory(LstobjJobsAndTriggers).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Schedule job factory method
        /// </summary>
        /// <param name="lstJobsAndTriggers"></param>
        /// <returns></returns>
        public static async Task JobFactory(List<JobsAndTriggers> lstJobsAndTriggers)
        {
            IScheduler scheduler;
            IJobDetail job = null;
            ITrigger trigger = null;

            var schedulerFactory = new StdSchedulerFactory();
            scheduler = schedulerFactory.GetScheduler().Result;

            scheduler.Start().Wait();

            foreach (var JobandTrigger in lstJobsAndTriggers)
            {
                JobKey jobKey = JobKey.Create(JobandTrigger.jobIdentityKey);

                job = JobBuilder.Create<HealthCheckJob>().
                    WithIdentity(jobKey)
                    .UsingJobData("UserAndUrl", JobandTrigger.JobDataUserAndUrl)
                    .Build();

                trigger = TriggerBuilder.Create()

                    .WithIdentity(JobandTrigger.TriggerIdentityKey)
                    .StartNow()
                    .WithSimpleSchedule(x => x.WithIntervalInSeconds(JobandTrigger.ScheduleIntervalInSec).RepeatForever()).Build();

                await scheduler.ScheduleJob(job, trigger);

            }
        }
    }
}
