using Core.DTO;
using DirectOne.RogueOne.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Services.Interface
{
    public interface ILeaderBoardServices
    {
        HttpResult<IEnumerable<LeaderBoardDto>> GetBeast();
    }
}
