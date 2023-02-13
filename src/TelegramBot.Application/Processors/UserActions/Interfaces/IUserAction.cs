using TelegramBot.Application.Models;

namespace TelegramBot.Application.Processors.UserActions.Interfaces;

public interface IUserAction
{
    Task<ResultMessageModel> Process();
}