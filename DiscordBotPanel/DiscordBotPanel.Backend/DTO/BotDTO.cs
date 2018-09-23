using System;

namespace DiscordBotPanel.Backend.DTO
{
    public class BotDto
    {
        public ulong Id { get; set; }
        public DateTime CreateTime { get; set; }
        public string Name { get; set; }
    }
}
