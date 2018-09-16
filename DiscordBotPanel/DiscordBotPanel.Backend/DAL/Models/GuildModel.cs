using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordBotPanel.Backend.DAL.Models
{
    public class GuildModel
    {
        public ulong Id { get; set; }
        public DateTime CreateTime { get; set; }
        public string Name { get; set; }

        public ulong BotId { get; set; }
        public virtual BotModel Bot { get; set; }

        public virtual List<CommandExecutionModel> CommandExecutions { get; set; }
    }
}
