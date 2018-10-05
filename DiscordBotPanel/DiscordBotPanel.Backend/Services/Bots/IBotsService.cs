using System.Collections.Generic;
using DiscordBotPanel.Backend.DTO;

namespace DiscordBotPanel.Backend.Services.Bots
{
    public interface IBotsService
    {
        bool IsBotRegistered(string botId);
        List<BotDto> GetAllBots();
        BotDto GetBot(string botId);
        RegisterResult RegisterBot(RegisterBotDto registerBotDto);
    }
}
