using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DiscordBotPanel.Backend.DAL.Models;
using DiscordBotPanel.Backend.DTO;
using DiscordBotPanel.Backend.Services.Bots;
using DiscordBotPanel.Backend.Services.Guilds;
using DiscordBotPanel.Backend.Tests.Helpers;
using Xunit;

namespace DiscordBotPanel.Backend.Tests.Services
{
    public class GuildServiceTests
    {
        public GuildServiceTests()
        {
            AutomapperHelper.Init();
        }

        [Fact]
        public void RegisterGuild_NonExistingGuild_ShouldReturnTrueAndSaveInDatabase()
        {
            var databaseContext = DatabaseFactory.Create();
            var timeProvider = TimeProviderFactory.Create();
            var guildService = new GuildService(databaseContext, timeProvider);

            var guild = new RegisterGuildDTO
            {
                Id = 1000,
                Name = "Guild1",
                BotId = 1
            };

            var result = guildService.RegisterGuild(guild);
            var registeredGuild = databaseContext.Guilds.First();

            Assert.True(result);
            Assert.Equal(1, databaseContext.Guilds.Count());
            Assert.Equal(1000ul, registeredGuild.Id);
            Assert.Equal(1ul, registeredGuild.BotId);
            Assert.Equal(timeProvider.Get(), registeredGuild.CreateTime);
        }

        [Fact]
        public void RegisterGuild_ExistingGuildWithSameName_ShouldReturnFalse()
        {
            var databaseContext = DatabaseFactory.Create();
            var timeProvider = TimeProviderFactory.Create();
            var guildService = new GuildService(databaseContext, timeProvider);

            databaseContext.Guilds.Add(new GuildModel
            {
                Id = 1000,
                Name = "Guild1",
                BotId = 1,
                CreateTime = DateTime.Now
            });
            databaseContext.SaveChanges();

            var guild = new RegisterGuildDTO()
            {
                Id = 1000,
                Name = "Guild1",
                BotId = 1
            };

            var result = guildService.RegisterGuild(guild);

            Assert.False(result);
            Assert.Equal(1, databaseContext.Guilds.Count());
        }

        [Fact]
        public void RegisterGuild_ExistingGuildWithDifferentName_ShouldReturnFalse()
        {
            var databaseContext = DatabaseFactory.Create();
            var timeProvider = TimeProviderFactory.Create();
            var guildService = new GuildService(databaseContext, timeProvider);

            databaseContext.Guilds.Add(new GuildModel
            {
                Id = 1000,
                Name = "Some other guild",
                BotId = 1,
                CreateTime = DateTime.Now
            });
            databaseContext.SaveChanges();

            var guild = new RegisterGuildDTO()
            {
                Id = 1000,
                Name = "Guild1",
                BotId = 1
            };

            var result = guildService.RegisterGuild(guild);
            var registeredGuild = databaseContext.Guilds.First();

            Assert.False(result);
            Assert.Equal(1, databaseContext.Guilds.Count());
            Assert.Equal("Guild1", registeredGuild.Name);
        }
    }
}
