using TelegramBot.Application.Models;
using TelegramBot.Application.Processors.Interfaces;
using TelegramBot.Application.Processors.UserActions.Interfaces;

namespace TelegramBot.Application.Processors;

public class UserActionProcessor : IUserActionProcessor
{
    public async Task<ResultMessageModel> HandleAction(IUserAction userAction) => await userAction.Process();
}
