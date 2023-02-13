using TelegramBot.MassTransit.SharedModels;

namespace TelegramBot.MassTransit.Producers.Interfaces;

public interface IUklonProducer
{
    Task Run();

    Task ReceiveMessage(IUklonNumberActivateModel message);

    Task SendMessage(string text);
}