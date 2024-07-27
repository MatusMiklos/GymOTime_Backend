using ErrorOr;
using GymOTime.Application.Common.Errors;
using GymOTime.Application.Common.Interfaces.Authentication;
using GymOTime.Application.Common.Interfaces.Persistance;
using GymOTime.Domain.Common.Errors;
using GymOTime.Domain.Entities;

namespace GymOTime.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        // Check if user already exists
        if (_userRepository.GetUserByEmail(email) is not null){
            return Errors.User.DuplicateEmail;
        }

        // Create user (generate unique id)
        var user = new User {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        // Create JWT token
        Guid userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
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