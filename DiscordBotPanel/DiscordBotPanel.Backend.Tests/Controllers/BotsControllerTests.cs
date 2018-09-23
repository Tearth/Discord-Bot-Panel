using System;
using System.Collections.Generic;
using System.Text;
using DiscordBotPanel.Backend.Controllers;
using DiscordBotPanel.Backend.DTO;
using DiscordBotPanel.Backend.Services.Bots;
using DiscordBotPanel.Backend.Tests.Helpers;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DiscordBotPanel.Backend.Tests.Controllers
{
    public class BotsControllerTests
    {
        [Fact]
        public void GetBot_ExistingBotId_ShouldReturnValidBotData()
        {
            var botServiceMock = new Mock<IBotsService>();
            var timeProvider = TimeProviderFactory.Create();

            botServiceMock.Setup(p => p.GetBot(1000)).Returns(new BotDto
            {
                Id = 1000,
                Name = "Bot1",
                CreateTime = timeProvider.Get()
            });

            var controller = new BotsController(botServiceMock.Object);
            var jsonResult = controller.GetBot(1000) as JsonResult;

            Assert.Null(jsonResult.StatusCode);
            Assert.IsAssignableFrom<BotDto>(jsonResult.Value);
        }

        [Fact]
        public void GetBot_NonExistingBotId_ShouldReturnNotFound()
        {
            var botServiceMock = new Mock<IBotsService>();
            botServiceMock.Setup(p => p.GetBot(1000)).Returns((BotDto)null);

            var controller = new BotsController(botServiceMock.Object);
            var result = controller.GetBot(1000);

            Assert.IsAssignableFrom<NotFoundResult>(result);
        }

        [Fact]
        public void RegisterBot_NonExistingId_ShouldReturnNoContent()
        {
            var botServiceMock = new Mock<IBotsService>();
            var registerBotDto = new RegisterBotDto
            {
                Id = 1000,
                Name = "Bot1"
            };

            botServiceMock.Setup(p => p.IsBotRegistered(1000)).Returns(false);
            botServiceMock.Setup(p => p.RegisterBot(registerBotDto)).Returns(RegisterResult.Success);

            var controller = new BotsController(botServiceMock.Object);
            var result = controller.RegisterBot(registerBotDto);

            Assert.IsAssignableFrom<NoContentResult>(result);
        }

        [Fact]
        public void RegisterBot_ExistingId_ShouldReturnBadRequest()
        {
            var botServiceMock = new Mock<IBotsService>();
            var registerBotDto = new RegisterBotDto
            {
                Id = 1000,
                Name = "Bot1"
            };

            botServiceMock.Setup(p => p.IsBotRegistered(1000)).Returns(true);

            var controller = new BotsController(botServiceMock.Object);
            var result = controller.RegisterBot(registerBotDto);

            Assert.IsAssignableFrom<BadRequestResult>(result);
        }
    }
}
