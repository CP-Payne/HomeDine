using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeDine.Domain.Entities;

namespace HomeDine.Application.Services.Authentication
{
    public record AuthenticationResult(User user, string Token);
}
