using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot.Application.Models;

public static class MenuModel
{
    public static readonly ReplyKeyboardMarkup Start = new(new KeyboardButton[][]
    {
        new KeyboardButton[]
        {
            new(MessageModel.Uklon),
            new(MessageModel.Ontaxi),
        },
        new KeyboardButton[]
        {
            new(MessageModel.Restart),
        },
    })
    {
        ResizeKeyboard = true
    };
}