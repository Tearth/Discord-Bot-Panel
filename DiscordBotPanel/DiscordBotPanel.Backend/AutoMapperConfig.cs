using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DiscordBotPanel.Backend.DAL.Models;
using DiscordBotPanel.Backend.DTO;

namespace DiscordBotPanel.Backend
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<RegisterBotDTO, BotModel>().ReverseMap();
            CreateMap<RegisterGuildDTO, GuildModel>().ReverseMap();
        }
    }
}
