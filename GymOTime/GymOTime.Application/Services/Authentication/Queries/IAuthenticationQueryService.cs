using ErrorOr;
using GymOTime.Application.Services.Authentication.Common;

namespace GymOTime.Application.Services.Authentication.Queries;

public interface IAuthenticationQueryService
{
    ErrorOr<AuthenticationResult> Login(
        string email,
        string Password);
}