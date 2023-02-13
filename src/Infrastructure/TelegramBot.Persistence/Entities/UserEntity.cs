using TelegramBot.Core.Common.Enums;

namespace TelegramBot.Persistence.Entities;

public class UserEntity
{
    public long Id { get; set; }

    public MenuStatus Status { get; set; } = MenuStatus.None;

    public string? Numder { get; set; }

    public string? Sms { get; set; }

    public string? City { get; set; }

    public string? DepartureAddress { get; set; }

    public string? DestinationAddress { get; set; }

    public string? Message { get; set; }

    public string? MessageValidationType { get; set; }
}