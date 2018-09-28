using System.Collections.Generic;
using DiscordBotPanel.Backend.DTO;

namespace DiscordBotPanel.Backend.Services.Bots
{
    public interface IBotsService
    {
        bool IsBotRegistered(ulong botId);
        List<BotDto> GetAllBots();
        BotDto GetBot(ulong botId);
        RegisterResult RegisterBot(RegisterBotDto registerBotDto);
    }
}
