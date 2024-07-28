using ErrorOr;
using GymOTime.Application.Services.Authentication.Common;

namespace GymOTime.Application.Services.Authentication.Commands;

public interface IAuthenticationCommandService
{
    ErrorOr<AuthenticationResult> Register(
        string firstName,
        string lastName,
        string email,
        string password);
}