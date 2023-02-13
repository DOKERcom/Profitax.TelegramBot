using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.Application.Services.Interfaces;
using TelegramBot.Core;

namespace TelegramBot.Application.Services;

public class MessageSender : IMessageSender
{
    private readonly ITelegramBotClient _botClient;
    public MessageSender()
    {
        _botClient = new TelegramBotClient(AppConfiguration.TelegramBotToken ?? 
                                           throw new InvalidOperationException(
                                               "MessageReceiver: TelegramBotToken can't be null or empty"));
    }

    public async Task<Message> SendMessageAsync(ChatId chatId, string text, CancellationToken cancellationToken)
    {
        var sentMessage = await _botClient.SendTextMessageAsync(
            chatId: chatId,
            text: text,
            parseMode: ParseMode.Html,
            cancellationToken: cancellationToken);

        return sentMessage;
    }

    public async Task<Message> SendMessageAsync(ChatId chatId, string text, ReplyKeyboardMarkup replyKeyboardMarkup, CancellationToken cancellationToken)
    {
        var sentMessage = await _botClient.SendTextMessageAsync(
            chatId: chatId,
            text: text,
            replyMarkup: replyKeyboardMarkup,
            parseMode: ParseMode.Html,
            cancellationToken: cancellationToken);

        return sentMessage;
    }
}