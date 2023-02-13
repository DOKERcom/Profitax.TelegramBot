using TelegramBot.Application.Models;

namespace TelegramBot.Application.Processors.Interfaces;

public interface IUserStatusProcessor
{
    Task<ResultMessageModel> HandleUserStatus(UserModel user);
}