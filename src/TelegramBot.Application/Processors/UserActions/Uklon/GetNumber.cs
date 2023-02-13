using TelegramBot.Application.Models;
using TelegramBot.Application.Models.Uklon;
using TelegramBot.Application.Processors.UserActions.Interfaces;
using TelegramBot.Application.Services.Interfaces;
using TelegramBot.Core.Common.Enums;

namespace TelegramBot.Application.Processors.UserActions.Uklon;

public class GetNumber : IUserAction
{
    private readonly UserModel _user;

    private readonly IUsersService _usersService;

    public GetNumber(IUsersService usersService, UserModel user)
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

                return new ResultMessageModel(UklonMenuModel.GetNumber, $"GetNumber: You already in {_user.Message}.");
            }
            case UklonMessageModel.GetSms:
            {
                await _usersService.UpdateMenuStatus(_user, MenuStatus.GetSms, _user.Message);

                return new ResultMessageModel(UklonMenuModel.GetSms, $"GetNumber: You wrote {_user.Message}.");
            }
            case UklonMessageModel.Restart:
            {
                await _usersService.UpdateMenuStatus(_user, MenuStatus.Uklon, _user.Message);

                return new ResultMessageModel(UklonMenuModel.Start, $"GetNumber: You wrote {_user.Message}.");
            }
            case UklonMessageModel.MainMenu:
            {
                await _usersService.UpdateMenuStatus(_user, MenuStatus.Start, _user.Message);

                return new ResultMessageModel(MenuModel.Start, $"GetNumber: You wrote {_user.Message}.");
            }
            default:
            {
                return new ResultMessageModel(UklonMenuModel.GetNumber,
                    $"GetNumber: You wrote {_user.Message}, unknown command");
            }
        }
    }
}