using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordBotPanel.Backend.DTO
{
    public class RegisterGuildDTO
    {
        public ulong Id { get; set; }
        public string Name { get; set; }

        public ulong BotId { get; set; }
    }
}
