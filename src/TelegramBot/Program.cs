using System.Reflection;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using TelegramBot.Application;
using TelegramBot.Application.Services.Interfaces;
using TelegramBot.Core;
using TelegramBot.MassTransit;
using TelegramBot.Persistence;
using TelegramBot.Receivers;
using TelegramBot.Receivers.Interfaces;

namespace TelegramBot;

public class Program
{
    static void Main(string[] args)
    {

        var configuration = GetAppConfiguration();

        var serviceProvider = RegisterServices(configuration, args);

        serviceProvider.GetService<Startup>()?.Execute();
    }

    private static IServiceProvider RegisterServices(IConfiguration configuration, string[] args)
    {
        var services = new ServiceCollection();

        services.AddSingleton(configuration);

        services.AddSingleton<Startup>();

        services.AddSingleton<IMessageReceiver, MessageReceiver>();

        services.AddApplication();

        services.AddPersistence();

        services.AddMassTransitServices();

        return services.BuildServiceProvider();
    }

    private static IConfiguration GetAppConfiguration()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(AppContext.BaseDirectory))
            .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: false)
            .AddEnvironmentVariables()
            .Build();

        configuration.GetRequiredSection("Configuration").Get<AppConfiguration>();

        return configuration;
    }
}