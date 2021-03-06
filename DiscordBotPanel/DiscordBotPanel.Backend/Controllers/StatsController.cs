﻿using DiscordBotPanel.Backend.DTO;
using DiscordBotPanel.Backend.Services.Stats;
using Microsoft.AspNetCore.Mvc;

namespace DiscordBotPanel.Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/stats")]
    public class StatsController : Controller
    {
        private readonly IStatsService _statsService;

        public StatsController(IStatsService statsService)
        {
            _statsService = statsService;
        }

        [HttpGet("{botId}")]
        public ActionResult GetStatsForBot(string botId)
        {
            var stats = _statsService.GetStatsForBot(botId);
            if (stats == null)
            {
                return new NotFoundResult();
            }

            return Json(stats);
        }

        [HttpPost]
        public ActionResult Log([FromBody] LogStatsDto logStatsDto)
        {
            if (!_statsService.Log(logStatsDto))
            {
                return new BadRequestResult();
            }

            return new NoContentResult();
        }
    }
}
