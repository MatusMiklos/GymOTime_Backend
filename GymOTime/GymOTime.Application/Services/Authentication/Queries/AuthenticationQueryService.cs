using ErrorOr;
using GymOTime.Application.Common.Interfaces.Authentication;
using GymOTime.Application.Common.Interfaces.Persistance;
using GymOTime.Application.Services.Authentication.Common;
using GymOTime.Domain.Common.Errors;
using GymOTime.Domain.Entities;

namespace GymOTime.Application.Services.Authentication.Queries;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationQueryService(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Login(string email, string Password)
    {
        if (_userRepository.GetUserByEmail(email) is not User user){
            return Errors.Authentication.InvalidCredentials;
        }

        if (Password != user.Password){
            return Errors.Authentication.InvalidCredentials;
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}