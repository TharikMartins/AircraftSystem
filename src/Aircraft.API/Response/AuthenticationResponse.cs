using System;

namespace Aircraft.API.Response
{
    public class AuthenticationResponse
    {
        public AuthenticationResponse(Guid userId, string token)
        {
            UserId = userId;
            Token = token;
        }

        public Guid UserId { get; }
        public string Token { get; }


    }
}
