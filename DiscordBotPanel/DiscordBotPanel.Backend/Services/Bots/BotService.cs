using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DiscordBotPanel.Backend.DAL;
using DiscordBotPanel.Backend.DAL.Models;
using DiscordBotPanel.Backend.DTO;
using DiscordBotPanel.Backend.Helpers.Time;

namespace DiscordBotPanel.Backend.Services.Bots
{
    public class BotService : IBotService
    {
        private DatabaseContext _databaseContext;
        private ITimeProvider _timeProvider;

        public BotService(DatabaseContext databaseContext, ITimeProvider timeProvider)
        {
            _databaseContext = databaseContext;
            _timeProvider = timeProvider;
        }

        public bool RegisterBot(RegisterBotDTO registerBotDto)
        {
            if (_databaseContext.Bots.Any(p => p.Id == registerBotDto.Id))
            {
                return false;
            }

            var botModel = Mapper.Map<BotModel>(registerBotDto);
            botModel.CreateTime = _timeProvider.Get();

            _databaseContext.Bots.Add(botModel);
            _databaseContext.SaveChanges();

            return true;
        }
    }
}
