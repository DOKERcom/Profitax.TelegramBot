using AutoMapper;
using TelegramBot.Application.Models;
using TelegramBot.Persistence.Entities;

namespace TelegramBot.Application.AutoMapper.Profiles;

public class AppMappingProfile : Profile
{

    public AppMappingProfile()
    {
        CreateMap<UserModel, UserEntity>().ReverseMap();
    }
}