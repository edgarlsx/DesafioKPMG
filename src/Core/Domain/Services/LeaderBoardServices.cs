using Core.Domain.Services;
using Core.Domain.Services.Interface;
using Core.DTO;
using DirectOne.RogueOne.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Services
{
    public class LeaderBoardServices: ILeaderBoardServices
    {
        private readonly IJsonDataServices Jds;
        public LeaderBoardServices(IJsonDataServices _Jds)
        {
            Jds = _Jds;
        }

        public HttpResult<IEnumerable<LeaderBoardDto>> GetBeast()
        {
            return Jds.GetBeast();
        }
    }
}
