using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot.Application.Models;

public class ResultMessageModel
{
    public ReplyKeyboardMarkup Menu { get; }

    public string Message { get; }

    public ResultMessageModel(ReplyKeyboardMarkup? menu, string? message)
    {
        Menu = menu ?? new ReplyKeyboardMarkup(new KeyboardButton[][]{});

        Message = message ?? "";
    }

}