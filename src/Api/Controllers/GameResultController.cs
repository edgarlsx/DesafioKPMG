using Core.Domain.Services.Interface;
using Core.DTO;
using Core.Models;
using DirectOne.RogueOne.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameResultController : ControllerBase
    {
        private readonly IGameResultServices _gamesResult;
        public GameResultController(IGameResultServices gameResultService)
        {
            _gamesResult = gameResultService;
        }

        // POST api/<GameResultController>
        [HttpPost]
        [Route("/gameresult")]
        public HttpResult<IEnumerable<GameResult>> Post(GameResult gameResult)
        {
            return _gamesResult.SaveMemory(gameResult);
        }
    }
}
