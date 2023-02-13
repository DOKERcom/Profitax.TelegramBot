using TelegramBot.Persistence.Entities;

namespace TelegramBot.Persistence.Repositories.Interfaces;

public interface IUsersRepository
{
    Task<UserEntity?> GetUserById(long id);

    Task<bool> IsUserExists(long id);

    Task<List<UserEntity>> GetAllUsers();

    Task UpdateUser(UserEntity user);

    Task CreateUser(UserEntity user);

    Task DeleteUserById(long id);
}