using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace DiscordBotPanel.Backend.Tests.Helpers
{
    public static class AutomapperHelper
    {
        private static bool _initDone;

        public static void Init()
        {
            if (!_initDone)
            {
                Mapper.Initialize(cfg => cfg.AddProfile(new AutoMapperConfig()));
                _initDone = true;
            }
        }
    }
}
