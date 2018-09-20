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
        private IStatsService _statsController;

        public StatsController(IStatsService statsController)
        {
            _statsController = statsController;
        }

        [HttpGet("{botId}")]
        public ActionResult GetStatsForBot(ulong botId)
        {
            var stats = _statsController.GetStatsForBot(botId);
            if (stats == null)
            {
                return Json(new RequestResultDTO(false, "No bot with this id,"));
            }

            return Json(stats);
        }
    }
}
