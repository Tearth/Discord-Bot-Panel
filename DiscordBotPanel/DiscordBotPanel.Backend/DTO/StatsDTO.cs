using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordBotPanel.Backend.DTO
{
    public class StatsDto
    {
        public ulong BotId { get; set; }
        public DateTime CreateTime { get; set; }
        public int GuildsCount { get; set; }
        public int MembersCount { get; set; }
        public int ExecutedCommandsCount { get; set; }
    }
}
