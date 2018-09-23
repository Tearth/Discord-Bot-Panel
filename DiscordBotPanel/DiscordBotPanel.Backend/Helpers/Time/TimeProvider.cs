using System;

namespace DiscordBotPanel.Backend.Helpers.Time
{
    public class TimeProvider : ITimeProvider
    {
        public DateTime Get()
        {
            return DateTime.Now;
        }
    }
}
