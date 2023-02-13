using TelegramBot.Application.Models;
using TelegramBot.Application.Processors.Interfaces;
using TelegramBot.Application.Processors.UserActions;
using TelegramBot.Application.Processors.UserActions.Uklon;
using TelegramBot.Application.Services.Interfaces;
using TelegramBot.Core.Common.Enums;

namespace TelegramBot.Application.Processors;

public class UserStatusProcessor : IUserStatusProcessor
{
    private readonly IUserActionProcessor _actionHandler;
    private readonly IUsersService _usersService;
    public UserStatusProcessor(IUserActionProcessor actionHandler, IUsersService usersService)
    {
        _actionHandler = actionHandler;
        _usersService = usersService;
    }

    public async Task<ResultMessageModel> HandleUserStatus(UserModel user)
    {
        switch (user.Status)
        {
            case MenuStatus.None:
            {
                return await _actionHandler.HandleAction(new None(_usersService, user));
            }
            case MenuStatus.Start:
            {
                return await _actionHandler.HandleAction(new UserActions.Start(_usersService, user));
            }
            case MenuStatus.Uklon:
            {
                return await _actionHandler.HandleAction(new UserActions.Uklon.Start(_usersService, user));
            }
            case MenuStatus.GetNumber:
            {
                return await _actionHandler.HandleAction(new GetNumber(_usersService, user));
            }
            case MenuStatus.GetSms:
            {
                return await _actionHandler.HandleAction(new GetSms(_usersService, user));
            }
            default:
            {
                return await _actionHandler.HandleAction(new None(_usersService, user));
            }
        }

        
    }
}