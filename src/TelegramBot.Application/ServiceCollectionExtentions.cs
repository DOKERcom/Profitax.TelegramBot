using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using TelegramBot.Application.Processors;
using TelegramBot.Application.Processors.Interfaces;
using TelegramBot.Application.Services;
using TelegramBot.Application.Services.Interfaces;

namespace TelegramBot.Application;

public static class ServiceCollectionExtentions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddTransient<IMessageSender, MessageSender>();

        services.AddTransient<IUserActionProcessor, UserActionProcessor>();

        services.AddTransient<IUserStatusProcessor, UserStatusProcessor>();

        services.AddTransient<IUsersService, UsersService>();

        return services;
    }
}