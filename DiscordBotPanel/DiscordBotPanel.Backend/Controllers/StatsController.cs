using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscordBotPanel.Backend.DTO;
using DiscordBotPanel.Backend.Services.Bots;
using DiscordBotPanel.Backend.Services.Stats;
using Microsoft.AspNetCore.Mvc;

namespace DiscordBotPanel.Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/stats")]
    public class StatsController : Controller
    {
        private IStatsService _statsService;

        public StatsController(IStatsService statsService)
        {
            _statsService = statsService;
        }

        [HttpGet("{botId}")]
        public ActionResult GetStatsForBot(ulong botId)
        {
            var stats = _statsService.GetStatsForBot(botId);
            if (stats == null)
            {
                Response.StatusCode = 404;
                return Json(new RequestResultDTO(false, "No bot with this id,"));
            }

            return Json(stats);
        }

        [HttpPost]
        public ActionResult Log([FromBody] LogStatsDTO logStatsDto)
        {
            if (!_statsService.Log(logStatsDto))
            {
                Response.StatusCode = 404;
                return Json(new RequestResultDTO(false, "Can't log data, check if bot is registered."));
            }

            return Json(new RequestResultDTO(true));
        }
    }
}
