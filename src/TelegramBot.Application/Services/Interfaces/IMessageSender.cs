using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot.Application.Services.Interfaces;

public interface IMessageSender
{
    Task<Message> SendMessageAsync(ChatId chatId, string text,
        CancellationToken cancellationToken);

    Task<Message> SendMessageAsync(ChatId chatId, string text,
        ReplyKeyboardMarkup replyKeyboardMarkup, CancellationToken cancellationToken);
}