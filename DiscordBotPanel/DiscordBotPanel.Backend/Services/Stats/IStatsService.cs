using System.Collections.Generic;
using DiscordBotPanel.Backend.DTO;

namespace DiscordBotPanel.Backend.Services.Stats
{
    public interface IStatsService
    {
        bool Log(LogStatsDto logStatsDto);
        List<LogStatsDto> GetStatsForBot(ulong botId);
    }
}
