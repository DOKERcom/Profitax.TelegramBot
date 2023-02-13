using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TelegramBot.Core;

namespace TelegramBot.Persistence.DbContexts;

public class TelegramBotDbContextFactory : IDesignTimeDbContextFactory<TelegramBotDbContext>
{
    public TelegramBotDbContext CreateDbContext(string[] args)
    {
        //For Migrations
        //var connectionString = "Server=localhost;Port=5432;Database=ProfitaxTelegramBot;User Id=postgres;Password=2288228";

        var optionsBuilder = new DbContextOptionsBuilder<TelegramBotDbContext>();

        optionsBuilder.UseNpgsql(AppConfiguration.DbPostgresqlConnectionString);

        return new TelegramBotDbContext(optionsBuilder.Options);
    }
}