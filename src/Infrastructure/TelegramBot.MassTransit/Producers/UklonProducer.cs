using System.Runtime.CompilerServices;
using MassTransit.RabbitMqTransport;
using MassTransit;
using TelegramBot.MassTransit.Producers.Interfaces;
using TelegramBot.MassTransit.Publishers.Interfaces;
using TelegramBot.MassTransit.SharedModels;

namespace TelegramBot.MassTransit.Producers;

public class UklonProducer : IUklonProducer
{
    private readonly IBusControl _busControl;
    private readonly IUklonNumberActivatePublisher _publisher;

    public UklonProducer(IBusControl busControl, IUklonNumberActivatePublisher publisher)
    {
        _busControl = busControl;
        _publisher = publisher;
    }

    public async Task Run()
    {
        await _busControl.StartAsync();

        Console.WriteLine("Application started. Press any key to exit.");
        Console.ReadKey();

        await _busControl.StopAsync();
    }

    public async Task ReceiveMessage(IUklonNumberActivateModel message)
    {
        Console.WriteLine("Received message: " + message.Text);
    }

    public async Task SendMessage(string text)
    {
        await _publisher.Publish(text);
    }
}