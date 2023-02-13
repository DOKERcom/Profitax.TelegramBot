using TelegramBot.Application.Models;
using TelegramBot.Application.Models.Uklon;
using TelegramBot.Application.Processors.UserActions.Interfaces;
using TelegramBot.Application.Services.Interfaces;
using TelegramBot.Core.Common.Enums;

namespace TelegramBot.Application.Processors.UserActions;

public class Start : IUserAction
{
    private readonly UserModel _user;

    private readonly IUsersService _usersService;

    public Start(IUsersService usersService, UserModel user)
    {
        _user = user;

        _usersService = usersService;
    }

    public async Task<ResultMessageModel> Process()
    {
        switch (_user.Message)
        {
            case MessageModel.Start:
            {
                await _usersService.UpdateMenuStatus(_user, MenuStatus.Start, _user.Message);

                return new ResultMessageModel(MenuModel.Start, $"Start: You already in {_user.Message}.");
            }
            case MessageModel.Uklon:
            {
                await _usersService.UpdateMenuStatus(_user, MenuStatus.Uklon, _user.Message);

                return new ResultMessageModel(UklonMenuModel.Start, $"Start: Go to {_user.Message}.");
            }
            case MessageModel.Restart:
            {
                await _usersService.UpdateMenuStatus(_user, MenuStatus.Start, _user.Message);
                    
                return new ResultMessageModel(MenuModel.Start, $"Start: You wrote {_user.Message}.");
            }
            default:
            {
                return new ResultMessageModel(MenuModel.Start, $"Start: You wrote {_user.Message}, unknown command");
            }
        }
    }
}