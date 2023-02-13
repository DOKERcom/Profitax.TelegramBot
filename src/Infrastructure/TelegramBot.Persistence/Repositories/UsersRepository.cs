using Microsoft.EntityFrameworkCore;
using TelegramBot.Persistence.DbContexts;
using TelegramBot.Persistence.Entities;
using TelegramBot.Persistence.Repositories.Interfaces;

namespace TelegramBot.Persistence.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly TelegramBotDbContext _db;

    public UsersRepository(TelegramBotDbContext db)
    {
        _db = db;
    }

    public async Task<UserEntity?> GetUserById(long id)
    {
        return await _db.Users.FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<bool> IsUserExists(long id)
    {
        return await GetUserById(id) != null;
    }

    public async Task<List<UserEntity>> GetAllUsers()
    {
        return await _db.Users.ToListAsync();
    }

    public async Task UpdateUser(UserEntity user)
    {
        var _userEntity = await GetUserById(user.Id);

        _userEntity = MapEntity(_userEntity, user);

        _db.Users.Update(_userEntity);

        await _db.SaveChangesAsync();
    }

    public async Task CreateUser(UserEntity user)
    {
        await _db.Users.AddAsync(user);

        await _db.SaveChangesAsync();
    }

    public async Task DeleteUserById(long id)
    {
        var user = await GetUserById(id);

        if (user != null)
        {
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
        }
    }

    private UserEntity MapEntity(UserEntity _userEntity, UserEntity user)
    {
        _userEntity.City = user.City;
        _userEntity.DepartureAddress = user.DepartureAddress;
        _userEntity.DestinationAddress = user.DestinationAddress;
        _userEntity.Message = user.Message;
        _userEntity.MessageValidationType = user.MessageValidationType;
        _userEntity.Status = user.Status;
        _userEntity.Numder = user.Numder;
        _userEntity.Sms = user.Sms;

        return _userEntity;
    }
}