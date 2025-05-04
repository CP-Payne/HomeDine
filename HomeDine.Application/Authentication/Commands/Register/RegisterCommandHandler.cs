using ErrorOr;
using HomeDine.Application.Authentication.Common;
using HomeDine.Application.Common.Interfaces.Authentication;
using HomeDine.Application.Common.Interfaces.Persistence;
using HomeDine.Domain.Common;
using HomeDine.Domain.Entities;
using MediatR;

namespace HomeDine.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler
        : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(
            IJwtTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository
        )
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(
            RegisterCommand command,
            CancellationToken cancellationToken
        )
        {
            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            var user = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password,
            };
            _userRepository.Add(user);

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
