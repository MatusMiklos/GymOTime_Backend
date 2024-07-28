using GymOTime.Domain.Entities;

namespace GymOTime.Application.Services.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
);