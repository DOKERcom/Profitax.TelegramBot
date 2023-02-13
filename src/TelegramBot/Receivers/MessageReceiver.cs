using MediatR;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBot.Application.Models;
using TelegramBot.Application.Requests;
using TelegramBot.Application.Services;
using TelegramBot.Application.Services.Interfaces;
using TelegramBot.Core;
using TelegramBot.Receivers.Interfaces;

namespace TelegramBot.Receivers;

public class MessageReceiver : IMessageReceiver
{
    private readonly ITelegramBotClient _botClient;

    private readonly IMediator _mediator;

    private readonly IMessageSender _messageSender;

    private readonly CancellationTokenSource _cancellationToken;

    public MessageReceiver(IMediator mediator, IMessageSender messageSender)
    {
        _botClient = new TelegramBotClient(AppConfiguration.TelegramBotToken ??
                         throw new InvalidOperationException(
                             "MessageReceiver: TelegramBotToken can't be null or empty"));

        _cancellationToken = new CancellationTokenSource();

        _mediator = mediator;

        _messageSender = messageSender;
    }

    public void StartReceiving()
    {
        ReceiverOptions receiverOptions = new()
        {
            AllowedUpdates = Array.Empty<UpdateType>()
        };

        _botClient.StartReceiving(
            updateHandler: HandleUpdateAsync,
            pollingErrorHandler: HandlePollingErrorAsync,
            receiverOptions: receiverOptions,
            cancellationToken: _cancellationToken.Token
        );
    }

    private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message is not { } message)
            return;

        if (message.Text is not { } messageText)
            return;

        Console.WriteLine($"MessageReceiver: Received '{messageText}' message in chat {message.Chat.Id}.");

        var resultMessage = await _mediator.Send(new UserMessageRequest(message.Chat.Id, messageText), new CancellationToken());

        await _messageSender.SendMessageAsync(message.Chat.Id, resultMessage.Message, resultMessage.Menu, cancellationToken);
    }

    private Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        var ErrorMessage = exception switch
        {
            ApiRequestException apiRequestException
                => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };

        Console.WriteLine(ErrorMessage);
        return Task.CompletedTask;
    }
}