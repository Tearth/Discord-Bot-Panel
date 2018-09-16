using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
