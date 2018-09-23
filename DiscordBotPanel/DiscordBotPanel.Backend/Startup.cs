using AutoMapper;
using DiscordBotPanel.Backend.DAL;
using DiscordBotPanel.Backend.Helpers.Time;
using DiscordBotPanel.Backend.Services.Bots;
using DiscordBotPanel.Backend.Services.Stats;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;

namespace DiscordBotPanel.Backend
{
    public class Startup
    {
        private Logger _logger = LogManager.GetCurrentClassLogger();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _logger.Info("Configuring services...");

            services.AddMvc();

            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DatabaseContext>(options => options.UseSqlite(connectionString));
            services.AddScoped<IBotsService, BotsService>();
            services.AddScoped<IStatsService, StatsService>();
            services.AddScoped<ITimeProvider, TimeProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            _logger.Info("Configuring pipeline and database...");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DatabaseContext>();

                context.Database.EnsureCreated();
                context.Database.Migrate();
            }

            Mapper.Initialize(cfg => cfg.AddProfiles(GetType().Assembly));

            app.UseMvc();
        }
    }
}
