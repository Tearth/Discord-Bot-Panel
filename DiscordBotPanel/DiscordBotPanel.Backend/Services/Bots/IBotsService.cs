﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscordBotPanel.Backend.DTO;

namespace DiscordBotPanel.Backend.Services.Bots
{
    public interface IBotsService
    {
        bool IsBotRegistered(ulong botId);
        BotDTO GetBot(ulong botId);
        RegisterResult RegisterBot(RegisterBotDTO registerBotDto);
    }
}