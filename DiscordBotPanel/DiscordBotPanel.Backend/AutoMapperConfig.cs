using AutoMapper;
using DiscordBotPanel.Backend.DAL.Models;
using DiscordBotPanel.Backend.DTO;

namespace DiscordBotPanel.Backend
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<RegisterBotDto, BotModel>().ReverseMap();
            CreateMap<LogStatsDto, StatsModel>().ForMember(p => p.BotId, p => p.MapFrom(w => w.BotId)).ReverseMap();
            CreateMap<BotDto, BotModel>().ReverseMap();
        }
    }
}
