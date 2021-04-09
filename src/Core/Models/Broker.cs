using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Directone.App.GatewayExpress.Configuration.Core.Models
{
    public class Broker
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public List<BrokerChannel> Channels { get; set; }
    }
}
