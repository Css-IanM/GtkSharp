using System;
using Gtk;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GtkNamespace
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var app = host.Services.GetService<Startup>();
            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            new HostBuilder()
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: true);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddLogging(options =>
                        options.AddConfiguration(hostContext.Configuration.GetSection("Logging"))
                    );
                    // Register Dependencies with IoC.
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<Startup>();
                })
                .ConfigureLogging((hostContext, logging) =>
                {
                    logging.AddConsole();
                })
                .UseConsoleLifetime();
    }
}
