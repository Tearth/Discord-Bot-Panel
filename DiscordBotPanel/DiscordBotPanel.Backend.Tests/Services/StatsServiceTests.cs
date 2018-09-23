using System;
using System.Collections.Generic;
using System.Linq;
using DiscordBotPanel.Backend.DAL.Models;
using DiscordBotPanel.Backend.DTO;
using DiscordBotPanel.Backend.Services.Stats;
using DiscordBotPanel.Backend.Tests.Helpers;
using Xunit;

namespace DiscordBotPanel.Backend.Tests.Services
{
    public class StatsServiceTests
    {
        public StatsServiceTests()
        {
            AutoMapperHelper.Init();
        }

        [Fact]
        public void Log_ExistingBot_ShouldReturnTrueAndSaveInDatabase()
        {
            var databaseContext = DatabaseFactory.Create();
            var timeProvider = TimeProviderFactory.Create();
            var statsService = new StatsService(databaseContext, timeProvider);

            databaseContext.Bots.Add(new BotModel
            {
                Id = 1,
                Name = "Bot1"
            });
            databaseContext.SaveChanges();

            var stats = new LogStatsDto
            {
                BotId = 1,
                ExecutedCommandsCount = 2,
                GuildsCount = 3,
                MembersCount = 4
            };

            var result = statsService.Log(stats);
            var loggedStats = databaseContext.Stats.First();

            Assert.True(result);
            Assert.Equal(1, databaseContext.Stats.Count());
            Assert.Equal(1ul, loggedStats.BotId);
            Assert.Equal(timeProvider.Get(), loggedStats.CreateTime);
            Assert.Equal(2, loggedStats.ExecutedCommandsCount);
            Assert.Equal(3, loggedStats.GuildsCount);
            Assert.Equal(4, loggedStats.MembersCount);
        }

        [Fact]
        public void Log_NonExistingBot_ShouldReturnFalse()
        {
            var databaseContext = DatabaseFactory.Create();
            var timeProvider = TimeProviderFactory.Create();
            var statsService = new StatsService(databaseContext, timeProvider);

            var stats = new LogStatsDto
            {
                BotId = 1,
                ExecutedCommandsCount = 2,
                GuildsCount = 3,
                MembersCount = 4
            };

            var result = statsService.Log(stats);

            Assert.False(result);
            Assert.Equal(0, databaseContext.Stats.Count());
        }

        [Fact]
        public void GetStatsForBot_ExistingBot_ShouldReturnListOfStats()
        {
            var databaseContext = DatabaseFactory.Create();
            var timeProvider = TimeProviderFactory.Create();
            var statsService = new StatsService(databaseContext, timeProvider);

            databaseContext.Bots.Add(new BotModel
            {
                Id = 1,
                Name = "Bot1",
                Stats = new List<StatsModel>
                {
                    new StatsModel {BotId = 1, CreateTime = DateTime.Now, ExecutedCommandsCount = 1001 },
                    new StatsModel {BotId = 1, CreateTime = DateTime.Now, ExecutedCommandsCount = 1002 },
                    new StatsModel {BotId = 1, CreateTime = DateTime.Now, ExecutedCommandsCount = 1003 }
                }
            });
            databaseContext.SaveChanges();

            var result = statsService.GetStatsForBot(1);

            Assert.Equal(3, result.Count);
            Assert.Equal(1001, result[0].ExecutedCommandsCount);
            Assert.Equal(1002, result[1].ExecutedCommandsCount);
            Assert.Equal(1003, result[2].ExecutedCommandsCount);
        }

        [Fact]
        public void GetStatsForBot_NonExistingBot_ShouldReturnNull()
        {
            var databaseContext = DatabaseFactory.Create();
            var timeProvider = TimeProviderFactory.Create();
            var statsService = new StatsService(databaseContext, timeProvider);

            var result = statsService.GetStatsForBot(0);

            Assert.Null(result);
        }
    }
}
