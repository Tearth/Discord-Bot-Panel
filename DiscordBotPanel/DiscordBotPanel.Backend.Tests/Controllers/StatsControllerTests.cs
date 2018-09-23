using System;
using System.Collections.Generic;
using System.Text;
using DiscordBotPanel.Backend.Controllers;
using DiscordBotPanel.Backend.DAL.Models;
using DiscordBotPanel.Backend.DTO;
using DiscordBotPanel.Backend.Services.Bots;
using DiscordBotPanel.Backend.Services.Stats;
using DiscordBotPanel.Backend.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DiscordBotPanel.Backend.Tests.Controllers
{
    public class StatsControllerTests
    {
        [Fact]
        public void GetStatsForBot_ExistingBotId_ShouldReturnBotStats()
        {
            var statsServiceMock = new Mock<IStatsService>();
            var registerBotDto = new RegisterBotDTO
            {
                Id = 1000,
                Name = "Bot1"
            };

            statsServiceMock.Setup(p => p.GetStatsForBot(1000)).Returns(new List<LogStatsDTO>
            {
                new LogStatsDTO {BotId=1000, ExecutedCommandsCount = 1, GuildsCount = 1, MembersCount = 1},
                new LogStatsDTO {BotId=1000, ExecutedCommandsCount = 2, GuildsCount = 2, MembersCount = 2},
                new LogStatsDTO {BotId=1000, ExecutedCommandsCount = 3, GuildsCount = 3, MembersCount = 3}
            });

            var controller = new StatsController(statsServiceMock.Object);
            var jsonResult = controller.GetStatsForBot(1000) as JsonResult;

            Assert.IsAssignableFrom<List<LogStatsDTO>>(jsonResult.Value);
        }

        [Fact]
        public void GetStatsForBot_NonExistingBotId_ShouldReturnNotFound()
        {
            var statsServiceMock = new Mock<IStatsService>();

            statsServiceMock.Setup(p => p.GetStatsForBot(1000)).Returns((List<LogStatsDTO >)null);

            var controller = new StatsController(statsServiceMock.Object);
            var result = controller.GetStatsForBot(1000);

            Assert.IsAssignableFrom<NotFoundResult>(result);
        }

        [Fact]
        public void Log_ExistingId_ShouldReturnNoContent()
        {
            var statsServiceMock = new Mock<IStatsService>();
            var logStatsDto = new LogStatsDTO
            {
                BotId = 1000,
                ExecutedCommandsCount = 1,
                GuildsCount = 2,
                MembersCount = 3
            };

            statsServiceMock.Setup(p => p.Log(logStatsDto)).Returns(true);

            var controller = new StatsController(statsServiceMock.Object);
            var result = controller.Log(logStatsDto);

            Assert.IsAssignableFrom<NoContentResult>(result);
        }

        [Fact]
        public void Log_NonExistingId_ShouldReturnBadRequest()
        {
            var statsServiceMock = new Mock<IStatsService>();
            var logStatsDto = new LogStatsDTO
            {
                BotId = 1000,
                ExecutedCommandsCount = 1,
                GuildsCount = 2,
                MembersCount = 3
            };

            statsServiceMock.Setup(p => p.Log(logStatsDto)).Returns(false);

            var controller = new StatsController(statsServiceMock.Object);
            var result = controller.Log(logStatsDto);

            Assert.IsAssignableFrom<BadRequestResult>(result);
        }
    }
}
