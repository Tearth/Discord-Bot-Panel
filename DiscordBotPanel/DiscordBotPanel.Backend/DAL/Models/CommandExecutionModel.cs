using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordBotPanel.Backend.DAL.Models
{
    public class CommandExecutionModel
    {
        public ulong Id { get; set; }
        public DateTime CreateTime { get; set; }
        public string Name { get; set; }

        public ulong GuildId { get; set; }
        public virtual GuildModel Guild { get; set; }

        public ulong BotId { get; set; }
        public virtual BotModel Bot { get; set; }
    }
}
