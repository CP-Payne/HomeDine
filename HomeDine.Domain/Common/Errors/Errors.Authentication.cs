using ErrorOr;

namespace HomeDine.Domain.Common
{
    public static partial class Errors
    {
        public static class Authentication
        {
            public static Error InvalidCredentials =>
                Error.Validation(code: "Auth.InvalidCred", description: "Invalid credentials.");
        }
    }
}
