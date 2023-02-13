using TelegramBot.Application.Models;
using TelegramBot.Core.Common.Enums;

namespace TelegramBot.Application.Services.Interfaces;

public interface IUsersService
{
    Task<UserModel?> GetUserById(long id);

    Task<bool> IsUserExists(long id);

    Task<List<UserModel>> GetAllUsers();

    Task UpdateMenuStatus(UserModel user, MenuStatus status, string message);

    Task UpdateUser(UserModel user);

    Task CreateUser(UserModel user);

    Task DeleteUserById(long id);
}