using DiscordBotPanel.Backend.DTO;
using DiscordBotPanel.Backend.Services.Bots;
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
                return new NotFoundResult();
            }

            return Json(bot);
        }

        [HttpPost]
        public ActionResult RegisterBot([FromBody] RegisterBotDto registerBotDto)
        {
            if (_botsService.IsBotRegistered(registerBotDto.Id))
            {
                return new BadRequestResult();
            }

            if (_botsService.RegisterBot(registerBotDto) != RegisterResult.Success)
            {
                return new StatusCodeResult(500);
            }

            return new NoContentResult();
        }
    }
}