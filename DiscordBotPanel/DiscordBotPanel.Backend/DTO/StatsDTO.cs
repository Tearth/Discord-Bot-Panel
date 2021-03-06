﻿using System;

namespace DiscordBotPanel.Backend.DTO
{
    public class StatsDto
    {
        public string BotId { get; set; }
        public DateTime CreateTime { get; set; }
        public int GuildsCount { get; set; }
        public int MembersCount { get; set; }
        public int ExecutedCommandsCount { get; set; }
    }
}
