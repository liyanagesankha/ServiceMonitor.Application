using Quartz;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace ServiceMonitor.Business
{
    public class HealthCheckJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            //JobKey key = context.JobDetail.Key;
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            string userAndUrl = dataMap.GetString("UserAndUrl");
            string[] serviceData = userAndUrl.Split(";#");
            string userName = serviceData[0];
            string serviceName = serviceData[1];
            string serviceHost = serviceData[2];
            int servicePort = Convert.ToInt32(serviceData[3]);
            string message = "Hi " + userName + ", [" + serviceName + " - " + "http://" + serviceHost + ":" + servicePort + "] which you requested is ";
            try
            {
                IPAddress address = IPAddress.Parse(serviceHost);
                using (TcpClient client = new TcpClient())
                {
                    client.Connect(IPAddress.Parse(serviceHost), servicePort);
                    if (client.Connected)
                    {
                        Console.WriteLine(DateTime.Now.ToString() + " " + message + "is up and running..");
                    }
                    else
                    {
                        Console.WriteLine(DateTime.Now.ToString() + " " + message + "down.");
                    }
                }
                //When it comes to web front end we should update the user by using signalR
            }
            catch
            {
                Console.WriteLine(DateTime.Now.ToString() + " " + message + "down.");
            }
            Console.WriteLine();
            return Task.FromResult(0);
        }
    }
}
