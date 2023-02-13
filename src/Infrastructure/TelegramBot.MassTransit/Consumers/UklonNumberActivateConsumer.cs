using MassTransit;
using TelegramBot.MassTransit.Producers.Interfaces;
using TelegramBot.MassTransit.SharedModels;
using static System.Net.Mime.MediaTypeNames;

namespace TelegramBot.MassTransit.Consumers;

public class UklonNumberActivateConsumer : IConsumer<IUklonNumberActivateModel>
{
    private readonly IUklonProducer _uklonProducer;

    public UklonNumberActivateConsumer(IUklonProducer uklonProducer)
    {
        _uklonProducer = uklonProducer;
    }

    public async Task Consume(ConsumeContext<IUklonNumberActivateModel> context)
    {
        await _uklonProducer.ReceiveMessage(context.Message);
    }
}