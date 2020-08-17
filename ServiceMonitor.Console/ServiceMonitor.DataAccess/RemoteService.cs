using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

/// <summary>
/// This class contains requested functions related services data related 
/// </summary>
namespace ServiceMonitor.DataAccess
{
    public class RemoteService : IRemoteService
    {
        /// <summary>
        /// Return all users Mock data
        /// </summary>
        /// <returns></returns>
        public IList<UserSchedule> GetAllUsersScheduleList()
        {
            return new List<UserSchedule>()
            {
                new UserSchedule() {
                    User = new User() { Id = 1 , Name = "Sankha" },
                    Services = new List<Service>(){
                        new Service() { Id = 1, Name = "Database Service", Host = "127.0.0.1", Port = 1234, Frequency = 5, Outage = true },
                        new Service() { Id = 2, Name = "Field Data Service", Host = "127.0.0.1", Port = 1235, Frequency = 10, Outage = false  },
                        new Service() { Id = 3, Name = "Sales Data Service", Host = "127.0.0.1", Port = 1239, Frequency = 8, Outage = false  },
                    }
                },
                new UserSchedule() {
                    User = new User() { Id = 2 , Name = "Kamal" },
                    Services = new List<Service>(){
                        new Service() { Id = 4, Name = "Database Service", Host = "127.0.0.1", Port = 1234, Frequency = 3, Outage = true  },
                        new Service() { Id = 5, Name = "Login Service", Host = "127.0.0.1", Port = 1237, Frequency = 20, Outage = false  },
                        new Service() { Id = 6, Name = "Audit Service", Host = "127.0.0.1", Port = 1238, Frequency = 16, Outage = false }
                    }
                },
                new UserSchedule() {
                    User =  new User() { Id = 3 , Name = "Amal" },
                    Services = new List<Service>(){
                        new Service() { Id = 7, Name = "Login Service", Host = "127.0.0.1", Port = 1237, Frequency = 5, Outage = false  },
                        new Service() { Id = 8, Name = "Sales Data Service", Host = "127.0.0.1", Port = 1239, Frequency = 1, Outage = false  }
                    }
                }
            };
        }



        /// <summary>
        /// Return user specific Mock data
        /// </summary> 
        /// <param name="userId"></param>
        /// <returns></returns>
        public IList<UserSchedule> GetUpdatedUserSchedules()
        {
            return new List<UserSchedule>()
            {
                new UserSchedule() {
                    User = new User() { Id = 1, Name = "Sankha" },
                            Services = new List<Service>(){
                                new Service() { Id = 1, Name = "User One - Database Service", Host = "127.0.0.1", Port = 1234, Frequency = 6, Outage = false  },
                                new Service() { Id = 2, Name = "User One - Field Data Service", Host = "127.0.0.1", Port = 1235, Frequency = 10, Outage = true  },
                                new Service() { Id = 3, Name = "User One - Sales Data Service", Host = "127.0.0.1", Port = 1239, Frequency = 5, Outage = false  },
                            }
                },
                new UserSchedule() {
                   User = new User() { Id = 2, Name = "Kamal" },
                            Services = new List<Service>(){
                                new Service() { Id = 4, Name = "User Two - Database Service", Host = "127.0.0.1", Port = 1234, Frequency = 3, Outage = false  },
                                new Service() { Id = 5, Name = "User Two - Login Service", Host = "127.0.0.1", Port = 1237, Frequency = 10, Outage = false  },
                                new Service() { Id = 6, Name = "User Two - Audit Service", Host = "127.0.0.1", Port = 1238, Frequency = 16, Outage = false }
                            }
                },
                new UserSchedule() {
                    User =  new User() { Id = 3 , Name = "Amal" },
                    Services = new List<Service>(){
                        new Service() { Id = 7, Name = "User Three - Login Service", Host = "127.0.0.1", Port = 1237, Frequency = 5, Outage = false  },
                        new Service() { Id = 8, Name = "User Three - Sales Data Service", Host = "127.0.0.1", Port = 1239, Frequency = 12, Outage = false  }
                    }
                }
            };
        }
    }
}
