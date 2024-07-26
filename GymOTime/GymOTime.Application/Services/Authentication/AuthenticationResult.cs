using GymOTime.Domain.Entities;

namespace GymOTime.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token
);