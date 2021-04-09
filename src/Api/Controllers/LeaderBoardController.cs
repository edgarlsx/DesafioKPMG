using Core.Domain.Services.Interface;
using Core.DTO;
using Core.Models;
using DirectOne.RogueOne.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderBoardController : ControllerBase
    {
        private readonly ILeaderBoardServices _leaderBoard;
        public LeaderBoardController(ILeaderBoardServices leaderBoardServices)
        {
            _leaderBoard = leaderBoardServices;
        }

        // POST api/<GameResultController>
        [HttpGet]
        [Route("/leaderboard")]
        public HttpResult<IEnumerable<LeaderBoardDto>> Get()
        {
            return _leaderBoard.GetBeast();
        }
    }
}
