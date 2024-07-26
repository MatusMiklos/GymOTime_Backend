using GymOTime.Domain.Entities;

namespace GymOTime.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}