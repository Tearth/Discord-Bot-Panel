using DiscordBotPanel.Backend.DTO;

namespace DiscordBotPanel.Backend.Services.Bots
{
    public interface IBotsService
    {
        bool IsBotRegistered(ulong botId);
        BotDto GetBot(ulong botId);
        RegisterResult RegisterBot(RegisterBotDto registerBotDto);
    }
}
