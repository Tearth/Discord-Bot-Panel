using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordBotPanel.Backend.Helpers.Time
{
    public interface ITimeProvider
    {
        DateTime Get();
    }
}
