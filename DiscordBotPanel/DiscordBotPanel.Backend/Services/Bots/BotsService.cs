using System.Linq;
using AutoMapper;
using DiscordBotPanel.Backend.DAL;
using DiscordBotPanel.Backend.DAL.Models;
using DiscordBotPanel.Backend.DTO;
using DiscordBotPanel.Backend.Helpers.Time;

namespace DiscordBotPanel.Backend.Services.Bots
{
    public class BotsService : IBotsService
    {
        private DatabaseContext _databaseContext;
        private ITimeProvider _timeProvider;

        public BotsService(DatabaseContext databaseContext, ITimeProvider timeProvider)
        {
            _databaseContext = databaseContext;
            _timeProvider = timeProvider;
        }

        public bool IsBotRegistered(ulong botId)
        {
            return _databaseContext.Bots.Any(p => p.Id == botId);
        }

        public BotDto GetBot(ulong botId)
        {
            var botModel = _databaseContext.Bots.FirstOrDefault(p => p.Id == botId);
            if (botModel == null)
            {
                return null;
            }

            return Mapper.Map<BotDto>(botModel);
        }

        public RegisterResult RegisterBot(RegisterBotDto registerBotDto)
        {
            if (_databaseContext.Bots.Any(p => p.Id == registerBotDto.Id))
            {
                return RegisterResult.DuplicatedIdError;
            }

            var botModel = Mapper.Map<BotModel>(registerBotDto);
            botModel.CreateTime = _timeProvider.Get();

            _databaseContext.Bots.Add(botModel);
            _databaseContext.SaveChanges();

            return RegisterResult.Success;
        }
    }
}
