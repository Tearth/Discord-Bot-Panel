using System;
using System.Collections.Generic;
using System.Text;
using DiscordBotPanel.Backend.Helpers.Time;
using Moq;

namespace DiscordBotPanel.Backend.Tests.Helpers
{
    public static class TimeProviderFactory
    {
        public static ITimeProvider Create()
        {
            var timeProviderMock = new Mock<ITimeProvider>();
            timeProviderMock.Setup(p => p.Get()).Returns(new DateTime(2018, 02, 15, 5, 30, 0));

            return timeProviderMock.Object;
        }
    }
}
