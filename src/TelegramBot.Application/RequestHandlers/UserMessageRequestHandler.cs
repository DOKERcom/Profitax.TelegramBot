using MediatR;
using TelegramBot.Application.Models;
using TelegramBot.Application.Processors.Interfaces;
using TelegramBot.Application.Requests;
using TelegramBot.Application.Services.Interfaces;
using TelegramBot.Core.Common.Enums;

namespace TelegramBot.Application.RequestHandlers;

public class UserMessageRequestHandler : IRequestHandler<UserMessageRequest, ResultMessageModel>
{

    private readonly IUserStatusProcessor _statusHandler;

    private readonly IUsersService _usersService;
    public UserMessageRequestHandler(IUserStatusProcessor statusHandler, IUsersService usersService)
    {
        _statusHandler = statusHandler;

        _usersService = usersService;
    }

    public async Task<ResultMessageModel> Handle(UserMessageRequest request, CancellationToken cancellationToken)
    {
        if(!await _usersService.IsUserExists(request.UserId))
            await _usersService.CreateUser(new UserModel()
            {
                Id = request.UserId,
                Status = MenuStatus.None,
                Message = request.Message
            });

        var user = await _usersService.GetUserById(request.UserId);

        if (user != null)
        {
            user.Message = request.Message;

            var resultMessage = await _statusHandler.HandleUserStatus(user);

            return resultMessage;
        }

        else throw new InvalidOperationException(
            "UserMessageRequestHandler: user can't be null");
    }

    
}