﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DiscordBotPanel.Backend.DAL;
using DiscordBotPanel.Backend.DAL.Models;
using DiscordBotPanel.Backend.DTO;
using DiscordBotPanel.Backend.Helpers.Time;

namespace DiscordBotPanel.Backend.Services.Stats
{
    public class StatsService : IStatsService
    {
        private DatabaseContext _databaseContext;
        private ITimeProvider _timeProvider;

        public StatsService(DatabaseContext databaseContext, ITimeProvider timeProvider)
        {
            _databaseContext = databaseContext;
            _timeProvider = timeProvider;
        }

        public bool Log(LogStatsDTO logStatsDto)
        {
            if (!_databaseContext.Bots.Any(p => p.Id == logStatsDto.BotId))
            {
                return false;
            }

            var statsModel = Mapper.Map<StatsModel>(logStatsDto);
            statsModel.CreateTime = _timeProvider.Get();

            _databaseContext.Stats.Add(statsModel);
            _databaseContext.SaveChanges();

            return true;
        }
    }
}
