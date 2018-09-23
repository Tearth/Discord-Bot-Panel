﻿using System;
using System.Collections.Generic;

namespace DiscordBotPanel.Backend.DAL.Models
{
    public class BotModel
    {
        public ulong Id { get; set; }
        public DateTime CreateTime { get; set; }
        public string Name { get; set; }

        public virtual List<StatsModel> Stats { get; set; }
    }
}
