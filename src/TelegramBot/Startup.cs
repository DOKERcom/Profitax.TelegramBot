using TelegramBot.Application.Services.Interfaces;
using TelegramBot.MassTransit.Producers;
using TelegramBot.MassTransit.Producers.Interfaces;
using TelegramBot.Receivers.Interfaces;

namespace TelegramBot;

public class Startup
{
    private readonly IMessageReceiver _messageReceiver;

    private readonly IUklonProducer _uklonProducer;

    public Startup(IMessageReceiver messageReceiver, IUklonProducer uklonProducer)
    {
        _messageReceiver = messageReceiver;

        _uklonProducer = uklonProducer;
    }

    public void Execute()
    {
        _messageReceiver.StartReceiving();

        _uklonProducer.Run();

        //var task = new Task(() =>
        //{
        //    while (true)
        //    {
        //        _uklonProducer.SendMessage("test_meassage");
        //        Thread.Sleep(1000);
        //    }
            
        //});
        //task.Start();
        Console.ReadLine();
    }
}