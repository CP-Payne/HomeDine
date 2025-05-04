using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using HomeDine.Application.Authentication.Common;
using HomeDine.Application.Common.Interfaces.Authentication;
using HomeDine.Application.Common.Interfaces.Persistence;
using HomeDine.Domain.Common;
using HomeDine.Domain.Entities;
using MediatR;

namespace HomeDine.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(
            IJwtTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository
        )
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(
            LoginQuery query,
            CancellationToken cancellationToken
        )
        {
            if (_userRepository.GetUserByEmail(query.Email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            if (user.Password != query.Password)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(user, token);
        }
    }
}
