using System;

namespace DiscordBotPanel.Backend.Helpers.Time
{
    public interface ITimeProvider
    {
        DateTime Get();
    }
}
