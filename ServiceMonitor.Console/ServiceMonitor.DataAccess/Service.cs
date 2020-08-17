using System;

namespace ServiceMonitor.DataAccess
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public int Frequency { get; set; }
        public bool Outage { get; set; }
    }
}
