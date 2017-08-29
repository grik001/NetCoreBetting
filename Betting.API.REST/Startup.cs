using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Betting.Data.DataModels.BrandX;
using Betting.Data.DataModels;
using Betting.Common.Helpers;
using Betting.Common.Models;
using Betting.Common.Helpers.IHelpers;
using Betting.API.REST.Helpers.WebSocketHelpers;

namespace Betting.API.REST
{
    public partial class Startup
    {
        NotificationsMessageHandler notificationsMessageHandler = null;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettingsModel>(Configuration.GetSection("ApplicationSettings"));

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                        .AllowCredentials());
            });

            // Add framework services.
            services.AddScoped<IGameDataModel, GameDataModel>();
            services.AddScoped<IMessageDataModel, MessageDataModel>();
            services.AddScoped<IAspNetUserDataModel, AspNetUsersDataModel>();
            services.AddSingleton<ICacheHelper, RedisCacheHelper>();
            services.AddSingleton<INotificationsMessageHandler>(provider => notificationsMessageHandler);

            services.AddOptions();



            services.AddWebSocketManager();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            //Added to use JWT Helpers and partial class for Startup

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseWebSockets();

            notificationsMessageHandler = serviceProvider.GetService<NotificationsMessageHandler>();
            app.MapWebSocketManager("/notifications", notificationsMessageHandler);

            app.UseCors("CorsPolicy");

            ConfigureAuth(app);
            app.UseMvc();
        }
    }
}
