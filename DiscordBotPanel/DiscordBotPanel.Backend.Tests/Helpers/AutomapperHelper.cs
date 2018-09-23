using AutoMapper;

namespace DiscordBotPanel.Backend.Tests.Helpers
{
    public static class AutoMapperHelper
    {
        private static bool _initDone;
        private static readonly object MapperInitLock;

        static AutoMapperHelper()
        {
            MapperInitLock = new object();
        }

        public static void Init()
        {
            lock (MapperInitLock)
            {
                if (!_initDone)
                {
                    Mapper.Initialize(cfg => cfg.AddProfile(new AutoMapperConfig()));
                    _initDone = true;
                }
            }
        }
    }
}
