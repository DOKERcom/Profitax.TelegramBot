using MediatR;
using TelegramBot.Application.Models;

namespace TelegramBot.Application.Requests;

public class UserMessageRequest : IRequest<ResultMessageModel>
{
    public long UserId { get; }

    public string Message { get; }

    public UserMessageRequest(long userId, string message)
    {
        UserId = userId;

        Message = message;
    }
}