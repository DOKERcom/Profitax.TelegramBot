using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using TelegramBot.Core;
using TelegramBot.Persistence.Entities;

namespace TelegramBot.Persistence.DbContexts;

public sealed class TelegramBotDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }

    public TelegramBotDbContext(DbContextOptions<TelegramBotDbContext> options) : base(options)
    {
        //Database.EnsureDeleted();

        Database.EnsureCreated();
    }
}