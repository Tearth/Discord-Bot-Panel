using System;
using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using NLog;

namespace DiscordBotPanel.Backend
{
    public class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Logger.Info("Starting Discord Bot Panel...");
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
#if DEBUG
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://127.0.0.1:4000")
                .Build();
#else
            return WebHost.CreateDefaultBuilder(args)
                .UseKestrel(options =>
                {
                    options.Listen(IPAddress.Any, 4000, listenOptions =>
                    {
                        listenOptions.UseHttps("certificate.pfx");
                    });
                })
                .UseStartup<Startup>()
                .Build();
#endif
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Logger.Fatal(e.ExceptionObject);
        }
    }
}
