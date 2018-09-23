using AutoMapper;

namespace DiscordBotPanel.Backend.Tests.Helpers
{
    public static class AutoMapperHelper
    {
        private static bool _initDone;
        private static object _mapperInitLock;

        static AutoMapperHelper()
        {
            _mapperInitLock = new object();
        }

        public static void Init()
        {
            lock (_mapperInitLock)
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
