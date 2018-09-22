using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscordBotPanel.Backend.DTO;
using DiscordBotPanel.Backend.Services.Bots;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiscordBotPanel.Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/bots")]
    public class BotsController : Controller
    {
        private IBotsService _botsService;

        public BotsController(IBotsService botsService)
        {
            _botsService = botsService;
        }

        [HttpGet("{botId}")]
        public ActionResult GetBot(ulong botId)
        {
            var bot = _botsService.GetBot(botId);
            if (bot == null)
            {
                Response.StatusCode = 404;
                return Json(new RequestResultDTO(false, "No bot with this id."));
            }

            return Json(bot);
        }

        [HttpPost]
        public ActionResult RegisterBot([FromBody] RegisterBotDTO registerBotDto)
        {
            if (_botsService.IsBotRegistered(registerBotDto.Id))
            {
                Response.StatusCode = 404;
                return Json(new RequestResultDTO(false, "Bot already registered."));
            }

            if (_botsService.RegisterBot(registerBotDto) != RegisterResult.Success)
            {
                Response.StatusCode = 404;
                return Json(new RequestResultDTO(false, "Internal RegisterBot error."));
            }

            return Json(new RequestResultDTO(true));
        }
    }
}