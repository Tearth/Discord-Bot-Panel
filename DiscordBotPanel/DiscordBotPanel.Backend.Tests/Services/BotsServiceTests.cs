using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DiscordBotPanel.Backend.DAL.Models;
using DiscordBotPanel.Backend.DTO;
using DiscordBotPanel.Backend.Services.Bots;
using DiscordBotPanel.Backend.Tests.Helpers;
using Xunit;

namespace DiscordBotPanel.Backend.Tests.Services
{
    public class BotsServiceTests
    {
        public BotsServiceTests()
        {
            AutoMapperHelper.Init();
        }

        [Fact]
        public void IsBotRegistered_ExistingBot_ShouldReturnTrue()
        {
            var databaseContext = DatabaseFactory.Create();
            var timeProvider = TimeProviderFactory.Create();
            var botService = new BotsService(databaseContext, timeProvider);

            databaseContext.Bots.Add(new BotModel
            {
                Id = 1000,
                Name = "Bot1",
                CreateTime = DateTime.Now
            });
            databaseContext.SaveChanges();

            var result = botService.IsBotRegistered(1000);
            Assert.True(result);
        }

        [Fact]
        public void IsBotRegistered_NonExistingBot_ShouldReturnTrue()
        {
            var databaseContext = DatabaseFactory.Create();
            var timeProvider = TimeProviderFactory.Create();
            var botService = new BotsService(databaseContext, timeProvider);

            var result = botService.IsBotRegistered(1000);
            Assert.False(result);
        }

        [Fact]
        public void GetBot_ExistingBot_ShuildReturnBotData()
        {
            var databaseContext = DatabaseFactory.Create();
            var timeProvider = TimeProviderFactory.Create();
            var botService = new BotsService(databaseContext, timeProvider);

            databaseContext.Bots.Add(new BotModel
            {
                Id = 1000,
                Name = "Bot1",
                CreateTime = timeProvider.Get()
            });
            databaseContext.SaveChanges();

            var result = botService.GetBot(1000);

            Assert.Equal(1000ul, result.Id);
            Assert.Equal("Bot1", result.Name);
            Assert.Equal(timeProvider.Get(), result.CreateTime);
        }

        [Fact]
        public void GetBot_NonExistingBot_ShuildReturnBotData()
        {
            var databaseContext = DatabaseFactory.Create();
            var timeProvider = TimeProviderFactory.Create();
            var botService = new BotsService(databaseContext, timeProvider);

            var result = botService.GetBot(1000);

            Assert.Null(result);
        }

        [Fact]
        public void RegisterBot_NonExistingBot_ShouldReturnSuccessAndSaveInDatabase()
        {
            var databaseContext = DatabaseFactory.Create();
            var timeProvider = TimeProviderFactory.Create();
            var botService = new BotsService(databaseContext, timeProvider);

            var bot = new RegisterBotDto
            {
                Id = 1000,
                Name = "Bot1"
            };

            var result = botService.RegisterBot(bot);
            var registeredBot = databaseContext.Bots.First();

            Assert.Equal(RegisterResult.Success, result);
            Assert.Equal(1, databaseContext.Bots.Count());
            Assert.Equal(1000ul, registeredBot.Id);
            Assert.Equal("Bot1", registeredBot.Name);
            Assert.Equal(timeProvider.Get(), registeredBot.CreateTime);
        }

        [Fact]
        public void RegisterBot_ExistingBot_ShouldReturnDuplicatedIdError()
        {
            var databaseContext = DatabaseFactory.Create();
            var timeProvider = TimeProviderFactory.Create();
            var botService = new BotsService(databaseContext, timeProvider);

            databaseContext.Bots.Add(new BotModel
            {
                Id = 1000,
                Name = "Some other bot",
                CreateTime = DateTime.Now
            });
            databaseContext.SaveChanges();

            var bot = new RegisterBotDto
            {
                Id = 1000,
                Name = "Bot1"
            };

            var result = botService.RegisterBot(bot);

            Assert.Equal(RegisterResult.DuplicatedIdError, result);
            Assert.Equal(1, databaseContext.Bots.Count());
        }
    }
}
