using Directone.App.GatewayExpress.Configuration.Core.Models;
using DirectOne.RogueOne.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directone.App.GatewayExpress.Configuration.Core.Domain.Services.Interface
{
    public interface IBrokerServices
    {
        public Task<HttpResult<IEnumerable<Broker>>> GetBroker();

        public Task<HttpResult<Broker>> GetBroker(string id);

        public Task<HttpResult<IEnumerable<Broker>>> SaveBroker(Broker NewBroker);

        public Task<HttpResult<IEnumerable<Broker>>> UpdateBroker(Broker NewBroker);

    }
}
