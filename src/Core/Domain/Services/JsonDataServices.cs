using Core.Domain.Services.Interface;
using Core.DTO;
using Core.Models;
using DirectOne.RogueOne.Service;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Services
{
    public class JsonDataServices : IJsonDataServices
    {
        private static string getJsonFile()
        {
            return AppDomain.CurrentDomain.BaseDirectory + @"db.Json";
        }

        private static string getJsonFileRead()
        {
            return File.ReadAllText(getJsonFile());
        }

        private static IEnumerable<GameResult> getListGameResult()
        {
            try
            {
                return JsonConvert.DeserializeObject<IEnumerable<GameResult>>(getJsonFileRead());
            }
            catch { }
            return new GameResult[0];
        }

        private static string SerializeObject(IEnumerable<GameResult> ListGameResult)
        {
            return JsonConvert.SerializeObject(ListGameResult, Formatting.Indented);
        }

        private static void SaveListDataJson(IEnumerable<GameResult> ListGameResult)
        {
            File.WriteAllText(getJsonFile(), SerializeObject(ListGameResult));
        }

        public void SaveInDataJson(IEnumerable<GameResult> lstGameResult)
        {

            var ListGameResult = getListGameResult().ToList();
            int i = 0;

            foreach (GameResult gr in lstGameResult)
            {
                ListGameResult.Add(gr);
            }

            SaveListDataJson(ListGameResult);

        }

        public HttpResult<IEnumerable<LeaderBoardDto>> GetBeast()
        {
            var ListGameResult = getListGameResult().OrderByDescending(c => c.Win).Take(100).ToList();

            //var ListLeaderBoardDto = from g in ListGameResult
            //                         select new
            //                         {
            //                             PlayerId = g.PlayerId,
            //                             Balance = g.Win,
            //                             LastUpdateDate = g.TimeStamp
            //                         };


            var ListLeaderBoardDto = new List<LeaderBoardDto>();
            for (int i = 0; i <= ListGameResult.Count() - 1; i++)
            {
                var lb = new LeaderBoardDto();
                lb.PlayerId = ListGameResult[i].PlayerId;
                lb.Balance = ListGameResult[i].Win;
                lb.LastUpdateDate = ListGameResult[i].TimeStamp;

                ListLeaderBoardDto.Add(lb);

            }

            return new HttpResult<IEnumerable<LeaderBoardDto>>(ListLeaderBoardDto, HttpStatusCode.OK, null);
        }
    }
}
