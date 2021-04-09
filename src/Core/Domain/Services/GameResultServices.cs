using Core.Domain.Services.Interface;
using Core.DTO;
using Core.Models;
using DirectOne.RogueOne.Service;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Core.Domain.Services
{
    public class GameResultServices : IGameResultServices
    {
        List<GameResult> GameResultInMemory = new List<GameResult>();


        public HttpResult<IEnumerable<GameResult>> SaveMemory(GameResult gameResult)
        {
            GameResultInMemory.Add(gameResult);

            return new HttpResult<IEnumerable<GameResult>>(GameResultInMemory, HttpStatusCode.OK, null);
        }

        public IEnumerable<GameResult> GetMemory()
        {
            return GameResultInMemory;
        }

        public void ClearMemory()
        {
            GameResultInMemory.Clear();
        }
    }
}
