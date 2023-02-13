namespace TelegramBot.MassTransit.Publishers.Interfaces;

public interface IUklonNumberActivatePublisher
{
    Task Publish(string text);
}