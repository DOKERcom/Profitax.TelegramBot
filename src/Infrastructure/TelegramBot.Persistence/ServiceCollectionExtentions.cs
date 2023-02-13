using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TelegramBot.Core;
using TelegramBot.Persistence.DbContexts;
using TelegramBot.Persistence.Repositories;
using TelegramBot.Persistence.Repositories.Interfaces;

namespace TelegramBot.Persistence;

public static class ServiceCollectionExtentions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContextFactory<TelegramBotDbContext>(
            options =>
                options.UseNpgsql(AppConfiguration.DbPostgresqlConnectionString));

        services.AddTransient<IUsersRepository, UsersRepository>();

        return services;

    }
}