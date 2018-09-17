﻿using System;
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
    public class BotServiceTests
    {
        public BotServiceTests()
        {
            AutomapperHelper.Init();
        }

        [Fact]
        public void RegisterBot_NonExistingBot_ShouldReturnTrueAndSaveInDatabase()
        {
            var databaseContext = DatabaseFactory.Create();
            var timeProvider = TimeProviderFactory.Create();
            var botService = new BotService(databaseContext, timeProvider);

            var bot = new RegisterBotDTO
            {
                Id = 1000,
                Name = "Bot1"
            };

            var result = botService.RegisterBot(bot);
            var registeredBot = databaseContext.Bots.First();

            Assert.True(result);
            Assert.Equal(1, databaseContext.Bots.Count());
            Assert.Equal(1000ul, registeredBot.Id);
            Assert.Equal(timeProvider.Get(), registeredBot.CreateTime);
        }

        [Fact]
        public void RegisterBot_ExistingBot_ShouldReturnFalse()
        {
            var databaseContext = DatabaseFactory.Create();
            var timeProvider = TimeProviderFactory.Create();
            var botService = new BotService(databaseContext, timeProvider);

            databaseContext.Bots.Add(new BotModel
            {
                Id = 1000,
                Name = "Some other bot",
                CreateTime = DateTime.Now
            });
            databaseContext.SaveChanges();

            var bot = new RegisterBotDTO
            {
                Id = 1000,
                Name = "Bot1"
            };

            var result = botService.RegisterBot(bot);

            Assert.False(result);
            Assert.Equal(1, databaseContext.Bots.Count());
        }
    }
}