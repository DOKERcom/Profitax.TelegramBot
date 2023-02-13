using TelegramBot.Application.Models;
using TelegramBot.Application.Processors.UserActions.Interfaces;

namespace TelegramBot.Application.Processors.Interfaces;

public interface IUserActionProcessor
{
    Task<ResultMessageModel> HandleAction(IUserAction userAction);
}
