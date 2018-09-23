using System;

namespace DiscordBotPanel.Backend.DAL.Models
{
    public class StatsModel
    {
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }

        public ulong BotId { get; set; }
        public virtual BotModel Bot { get; set; }

        public int GuildsCount { get; set; }
        public int MembersCount { get; set; }
        public int ExecutedCommandsCount { get; set; }
    }
}
