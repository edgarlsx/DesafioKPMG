using Directone.App.GatewayExpress.Configuration.Core.Domain.Services.Interface;
using DirectOne.RogueOne.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Directone.App.GatewayExpress.Configuration.Core.Models;
using System.Text;

namespace Directone.App.GatewayExpress.Configuration.Core.Domain.Services
{
    public class BrokerServices : IBrokerServices
    {
        private static string getJsonFile()
        {
            var x = AppDomain.CurrentDomain.BaseDirectory + @"broker.json";
            return x;
        }

        private static string getJsonFileRead()
        {
            var x = File.ReadAllText(getJsonFile());
            return x;
        }

        private static IEnumerable<Broker> getListBroker()
        {
            try
            {
                return JsonConvert.DeserializeObject<IEnumerable<Broker>>(getJsonFileRead());
            }
            catch {}
            return new Broker[0];
        }

        private static string SerializeObject(IEnumerable<Broker> ListBroker)
        {
            return JsonConvert.SerializeObject(ListBroker, Formatting.Indented);
        }

        private static bool CheckRecord(string brokerId)
        {
            bool check = false;
            if (getListBroker().FirstOrDefault(x => x.Id.Equals(brokerId)) != null)
            {
                check = true;
            }
            return check;
        }

        private static void SaveBroker(IEnumerable<Broker> ListBroker )
        {
            File.WriteAllText(getJsonFile(), SerializeObject(ListBroker));
        }

        public async Task<HttpResult<IEnumerable<Broker>>> GetBroker()
        {
            return new HttpResult<IEnumerable<Broker>>(getListBroker(), HttpStatusCode.OK, null);
        }

        public async Task<HttpResult<Broker>> GetBroker(string id)
        {
            return new HttpResult<Broker>(getListBroker().FirstOrDefault(x => x.Id.Equals(id)), HttpStatusCode.OK, null);
        }


        public async Task<HttpResult<IEnumerable<Broker>>> SaveBroker(Broker NewBroker)
        {

            if (CheckRecord(NewBroker.Id))
            {
                List<Broker> x = new List<Broker>();
                x.Add(NewBroker);
                ArgumentException error = new ArgumentException("Record found, go to Update");
                return new HttpResult<IEnumerable<Broker>>(x, HttpStatusCode.Found, error);
            }

            var ListBroker = getListBroker().ToList();
            ListBroker.Add(NewBroker);

            SaveBroker(ListBroker);

            return new HttpResult<IEnumerable<Broker>>(getListBroker(), HttpStatusCode.OK, null);
        }

        public async Task<HttpResult<IEnumerable<Broker>>> UpdateBroker(Broker UpBroker)
        {
            if (!CheckRecord(UpBroker.Id))
            {
                List<Broker> x = new List<Broker>();
                x.Add(UpBroker);
                ArgumentException error = new ArgumentException("Record not found with this Id.");
                return new HttpResult<IEnumerable<Broker>>(x, HttpStatusCode.NotFound, error);
            }

            var ListBroker = getListBroker().ToList();
            for (int i = 0; i <= ListBroker.Count() - 1; i++)
            {
                if (ListBroker[i].Id == UpBroker.Id)
                {
                    //ListBroker.RemoveAt(i);
                    //ListBroker.Add(uBroker); //Add object in finish register

                    ListBroker[i].Name = UpBroker.Name;
                    ListBroker[i].Status = UpBroker.Status;

                    for (int c = 0; c <= UpBroker.Channels.Count - 1; c++)
                    {
                        ListBroker[i].Channels[c].Kind = UpBroker.Channels[c].Kind;
                        ListBroker[i].Channels[c].Status = UpBroker.Channels[c].Status;
                        ListBroker[i].Channels[c].CertificateKind = UpBroker.Channels[c].CertificateKind;
                    }

                    break;
                }
            }

            SaveBroker(ListBroker);

            return new HttpResult<IEnumerable<Broker>>(getListBroker(), HttpStatusCode.OK, null);
        }
    }
}
