using GymOTime.Domain.Entities;

namespace GymOTime.Application.Common.Interfaces.Persistance;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}