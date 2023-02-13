using TelegramBot.Application.Models;
using TelegramBot.Application.Models.Uklon;
using TelegramBot.Application.Processors.UserActions.Interfaces;
using TelegramBot.Application.Services.Interfaces;
using TelegramBot.Core.Common.Enums;

namespace TelegramBot.Application.Processors.UserActions.Uklon;

public class GetSms : IUserAction
{
    private readonly UserModel _user;

    private readonly IUsersService _usersService;

    public GetSms(IUsersService usersService, UserModel user)
    {
        _user = user;

        _usersService = usersService;
    }

    public async Task<ResultMessageModel> Process()
    {
        switch (_user.Message)
        {
            case UklonMessageModel.GetSms:
            {
                await _usersService.UpdateMenuStatus(_user, MenuStatus.GetSms, _user.Message);

                return new ResultMessageModel(UklonMenuModel.GetSms, $"GetSms: You already in {_user.Message}.");
            }
            case UklonMessageModel.Restart:
            {
                await _usersService.UpdateMenuStatus(_user, MenuStatus.Start, _user.Message);

                return new ResultMessageModel(UklonMenuModel.Start, $"GetSms: You wrote {_user.Message}.");
            }
            default:
            {
                return new ResultMessageModel(UklonMenuModel.GetSms,
                    $"GetSms: You wrote {_user.Message}, unknown command");
            }
        }
    }
}