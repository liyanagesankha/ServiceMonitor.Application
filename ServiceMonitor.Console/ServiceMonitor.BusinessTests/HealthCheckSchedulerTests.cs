using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quartz.Impl;
using ServiceMonitor.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceMonitor.Business.Tests
{
    [TestClass()]
    public class HealthCheckSchedulerTests
    {
        [TestMethod()]
        public async Task JobFactory_StartScheduler_RunScheduler()
        {
            var lstJobsAndTriggers = new List<JobsAndTriggers>()
            {
                new JobsAndTriggers()
                {
                    jobIdentityKey = "TEST_JOB_KEY_1_1",
                    TriggerIdentityKey ="TEST_TRIGGER_KEY_1_1",
                    JobDataUserAndUrl ="TestUser1;#TestServer1;#127.0.0.1;#1212",
                    ScheduleIntervalInSec = 5
                }
            };
            await HealthCheckScheduler.JobFactory(lstJobsAndTriggers);

            var schedulerFactory = new StdSchedulerFactory();
            var scheduler = schedulerFactory.GetScheduler().Result;
            Assert.IsTrue(scheduler.IsStarted);
        }
    }
}