using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace Client.Auth
{
    public class FakeAuthenticationProvider : AuthenticationStateProvider
    {
        public static ClaimsPrincipal User => new(new ClaimsIdentity());
        public static ClaimsPrincipal Administrator => new(new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, "Fake Administrator"),
            new Claim(ClaimTypes.Email, "fake-administrator@gmail.com"),
            new Claim(ClaimTypes.Role, "Administrator"),
        }, "Fake Authentication"));

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(new AuthenticationState(Administrator));
        }
    }
}

