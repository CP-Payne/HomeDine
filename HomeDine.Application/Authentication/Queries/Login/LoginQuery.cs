using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using HomeDine.Application.Authentication.Common;
using MediatR;

namespace HomeDine.Application.Authentication.Queries.Login
{
    public record LoginQuery(string Email, string Password)
        : IRequest<ErrorOr<AuthenticationResult>>;
}
