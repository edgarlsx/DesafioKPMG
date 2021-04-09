using Core.DTO;
using Core.Models;
using DirectOne.RogueOne.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Services.Interface
{
    public interface IJsonDataServices
    {
        public void SaveInDataJson(IEnumerable<GameResult> lstGameResult);

        public HttpResult<IEnumerable<LeaderBoardDto>> GetBeast();

    }
}
