using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot.Application.Models.Uklon;

public static class UklonMenuModel
{
    public static readonly ReplyKeyboardMarkup Start = new(new KeyboardButton[][]
    {
        new KeyboardButton[]
        {
            new(UklonMessageModel.GetNumber),
            new(UklonMessageModel.MyUsedNumbers),
        },
        new KeyboardButton[]
        {
            new(UklonMessageModel.MainMenu),
        },
    })
    {
        ResizeKeyboard = true
    };

    public static readonly ReplyKeyboardMarkup GetNumber = new(new KeyboardButton[][]
    {
        new KeyboardButton[]
        {
            new(UklonMessageModel.GetSms),
            new(UklonMessageModel.Restart),
        },
    })
    {
        ResizeKeyboard = true
    };

    public static readonly ReplyKeyboardMarkup GetSms = new(new KeyboardButton[][]
    {
        new KeyboardButton[]
        {
            new(UklonMessageModel.Restart),
        },
    })
    {
        ResizeKeyboard = true
    };
}