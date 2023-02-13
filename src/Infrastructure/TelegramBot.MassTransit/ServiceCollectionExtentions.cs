using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using TelegramBot.MassTransit.Consumers;
using TelegramBot.MassTransit.Producers;
using TelegramBot.MassTransit.Producers.Interfaces;
using TelegramBot.MassTransit.Publishers;
using TelegramBot.MassTransit.Publishers.Interfaces;
using TelegramBot.MassTransit.SharedModels;

namespace TelegramBot.MassTransit;

public static class ServiceCollectionExtentions
{
    public static IServiceCollection AddMassTransitServices(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<UklonNumberActivateConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ReceiveEndpoint("uklon_number_activate_consumer", e =>
                {
                    e.ConfigureConsumer<UklonNumberActivateConsumer>(context);
                });

                cfg.Publish<IUklonNumberActivateModel>(x => x.ExchangeType = ExchangeType.Direct);
            });
        });

        services.AddScoped<IUklonNumberActivatePublisher, UklonNumberActivatePublisher>();

        services.AddScoped<IUklonProducer, UklonProducer>();

        return services;
    }
}