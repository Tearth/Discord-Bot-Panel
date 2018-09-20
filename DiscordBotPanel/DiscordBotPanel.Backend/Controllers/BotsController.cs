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

        [HttpPost]
        public ActionResult RegisterBot([FromBody] RegisterBotDTO registerBotDto)
        {
            if (_botsService.RegisterBot(registerBotDto))
            {
                return Json(new RequestResultDTO(true));
            }

            return Json(new RequestResultDTO(false, "Bot already registered."));
        }
    }
}