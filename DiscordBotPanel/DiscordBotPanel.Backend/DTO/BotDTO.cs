using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordBotPanel.Backend.DTO
{
    public class BotDTO
    {
        public ulong Id { get; set; }
        public DateTime CreateTime { get; set; }
        public string Name { get; set; }
    }
}
