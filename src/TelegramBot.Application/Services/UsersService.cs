using AutoMapper;
using Telegram.Bot.Types;
using TelegramBot.Application.Models;
using TelegramBot.Application.Services.Interfaces;
using TelegramBot.Core.Common.Enums;
using TelegramBot.Persistence.Entities;
using TelegramBot.Persistence.Repositories.Interfaces;

namespace TelegramBot.Application.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;

    private readonly IMapper _mapper;

    public UsersService(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;

        _mapper = mapper;
    }

    public async Task<UserModel?> GetUserById(long id)
    {
        return _mapper.Map<UserModel>(await _usersRepository.GetUserById(id));
    }

    public async Task<bool> IsUserExists(long id)
    {
        return await _usersRepository.IsUserExists(id);
    }

    public async Task<List<UserModel>> GetAllUsers()
    {
        return _mapper.Map<List<UserModel>>(await _usersRepository.GetAllUsers());
    }

    public async Task UpdateMenuStatus(UserModel user, MenuStatus status, string message)
    {
        user.Status = status;

        user.Message = message;

        await UpdateUser(user);
    }

    public async Task UpdateUser(UserModel user)
    {
        await _usersRepository.UpdateUser(_mapper.Map<UserEntity>(user));
    }

    public async Task CreateUser(UserModel user)
    {
        await _usersRepository.CreateUser(_mapper.Map<UserEntity>(user));
    }

    public async Task DeleteUserById(long id)
    {
        await _usersRepository.DeleteUserById(id);
    }
}