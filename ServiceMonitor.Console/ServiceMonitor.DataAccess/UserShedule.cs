using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceMonitor.DataAccess
{
    public class UserSchedule
    {
        public User User { get; set; }

        public IList<Service> Services { get; set; }
    }
}
