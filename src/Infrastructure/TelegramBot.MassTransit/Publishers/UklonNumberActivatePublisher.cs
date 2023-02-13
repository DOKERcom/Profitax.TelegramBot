using MassTransit;
using TelegramBot.MassTransit.Publishers.Interfaces;
using TelegramBot.MassTransit.SharedModels;

namespace TelegramBot.MassTransit.Publishers;

public class UklonNumberActivatePublisher : IUklonNumberActivatePublisher
{
    private readonly IPublishEndpoint _publishEndpoint;

    public UklonNumberActivatePublisher(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task Publish(string text)
    {
        await _publishEndpoint.Publish<IUklonNumberActivateModel>(new { Text = text });
    }
}