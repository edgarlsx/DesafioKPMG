using Core.Models;
using DirectOne.RogueOne.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Services.Interface
{
    public interface IGameResultServices
    {
        public HttpResult<IEnumerable<GameResult>> SaveMemory(GameResult gameResult);
        public IEnumerable<GameResult> GetMemory();
        public void ClearMemory();
    }
}
