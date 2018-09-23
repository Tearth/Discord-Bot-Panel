using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using NLog;

namespace DiscordBotPanel.Backend
{
    public class Program
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public static void Main(string[] args)
        {
            _logger.Info("Starting Discord Bot Panel...");
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
