using TelegramBot.Core.Common.Enums;

namespace TelegramBot.Application.Models;

public class UserModel
{
    public long Id { get; set; }

    public MenuStatus Status { get; set; }

    public string? City { get; set; }

    public string? DepartureAddress { get; set; }

    public string? DestinationAddress { get; set; }

    public string? Message { get; set; }

    public string? MessageValidationType { get; set; }
}