using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DiscordBotPanel.Backend.DAL;
using DiscordBotPanel.Backend.DAL.Models;
using DiscordBotPanel.Backend.DTO;
using DiscordBotPanel.Backend.Helpers.Time;
using Microsoft.EntityFrameworkCore;

namespace DiscordBotPanel.Backend.Services.Stats
{
    public class StatsService : IStatsService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly ITimeProvider _timeProvider;

        public StatsService(DatabaseContext databaseContext, ITimeProvider timeProvider)
        {
            _databaseContext = databaseContext;
            _timeProvider = timeProvider;
        }

        public bool Log(LogStatsDto logStatsDto)
        {
            if (!_databaseContext.Bots.Any(p => p.Id == logStatsDto.BotId))
            {
                return false;
            }

            var statsModel = Mapper.Map<StatsModel>(logStatsDto);
            statsModel.CreateTime = _timeProvider.Get();

            _databaseContext.Stats.Add(statsModel);
            _databaseContext.SaveChanges();

            return true;
        }

        public List<LogStatsDto> GetStatsForBot(string botId)
        {
            if (!_databaseContext.Bots.Any(p => p.Id == botId))
            {
                return null;
            }

            var botStats = _databaseContext.Stats
                .Where(p => p.BotId == botId)
                .GroupBy(p => p.CreateTime.Date, (date, stats) => new LogStatsDto
                {
                    BotId = botId,
                    CreateTime = date,
                    GuildsCount = stats.Max(s => s.GuildsCount),
                    MembersCount = stats.Max(s => s.MembersCount),
                    ExecutedCommandsCount = stats.Max(s => s.ExecutedCommandsCount)
                })
                .OrderBy(p => p.CreateTime)
                .ToList();

            return Mapper.Map<List<LogStatsDto>>(botStats);
        }
    }
}
