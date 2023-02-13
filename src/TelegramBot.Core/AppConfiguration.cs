namespace TelegramBot.Core;

public class AppConfiguration
{
    public static string? TelegramBotToken { get; set; }

    public static string? DbPostgresqlConnectionString { get; set; }
}