using TelegramBot.Application.Models;
using TelegramBot.Application.Models.Uklon;
using TelegramBot.Application.Processors.UserActions.Interfaces;
using TelegramBot.Application.Services.Interfaces;
using TelegramBot.Core.Common.Enums;

namespace TelegramBot.Application.Processors.UserActions.Uklon;

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
            case UklonMessageModel.GetNumber:
            {
                await _usersService.UpdateMenuStatus(_user, MenuStatus.GetNumber, _user.Message);

                

                return new ResultMessageModel(UklonMenuModel.GetNumber, $"UklonStart: You wrote {_user.Message}.");
            }
            case UklonMessageModel.Restart:
            {
                await _usersService.UpdateMenuStatus(_user, MenuStatus.Uklon, _user.Message);

                return new ResultMessageModel(UklonMenuModel.Start, $"UklonStart: You wrote {_user.Message}.");
            }
            case UklonMessageModel.MainMenu:
            {
                await _usersService.UpdateMenuStatus(_user, MenuStatus.Start, _user.Message);

                return new ResultMessageModel(MenuModel.Start, $"UklonStart: You wrote {_user.Message}.");
            }
            default:
            {
                return new ResultMessageModel(UklonMenuModel.Start, $"UklonStart: You wrote {_user.Message}, unknown command");
            }
        }
    }
}