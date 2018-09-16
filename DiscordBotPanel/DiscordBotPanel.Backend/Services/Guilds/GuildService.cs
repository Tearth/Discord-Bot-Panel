using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DiscordBotPanel.Backend.DAL;
using DiscordBotPanel.Backend.DAL.Models;
using DiscordBotPanel.Backend.DTO;
using DiscordBotPanel.Backend.Helpers.Time;
using Microsoft.EntityFrameworkCore;

namespace DiscordBotPanel.Backend.Services.Guilds
{
    public class GuildService : IGuildService
    {
        private DatabaseContext _databaseContext;
        private ITimeProvider _timeProvider;

        public GuildService(DatabaseContext databaseContext, ITimeProvider timeProvider)
        {
            _databaseContext = databaseContext;
            _timeProvider = timeProvider;
        }

        public bool RegisterGuild(RegisterGuildDTO registerGuildDto)
        {
            var existingGuild = _databaseContext.Guilds.FirstOrDefault(p => p.Id == registerGuildDto.Id);
            if (existingGuild != null)
            {
                if (existingGuild.Name != registerGuildDto.Name)
                {
                    existingGuild.Name = registerGuildDto.Name;
                    _databaseContext.SaveChanges();
                }

                return false;
            }

            var guildModel = Mapper.Map<GuildModel>(registerGuildDto);
            guildModel.CreateTime = _timeProvider.Get();

            _databaseContext.Guilds.Add(guildModel);
            _databaseContext.SaveChanges();

            return true;
        }
    }
}
