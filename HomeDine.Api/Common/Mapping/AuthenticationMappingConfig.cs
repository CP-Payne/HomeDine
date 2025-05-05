using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeDine.Application.Authentication.Commands.Register;
using HomeDine.Application.Authentication.Common;
using HomeDine.Application.Authentication.Queries.Login;
using HomeDine.Contracts.Authentication;
using Mapster;

namespace HomeDine.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, LoginQuery>();

            config
                .NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest, src => src.User);
        }
    }
}
