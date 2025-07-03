using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using zQuitSmoking.Repositories.ThinhTHP;

public class CustomAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly SystemUserAccountRepository _userRepo;

    public CustomAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, SystemUserAccountRepository userRepo)
        : base(options, logger, encoder)
    {
        _userRepo = userRepo;
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Path.StartsWithSegments("/Account"))
        {
            var username = Request.Cookies["Username"];
            var role = Request.Cookies["Role"];

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(role))
            {
                return Task.FromResult(AuthenticateResult.Fail("Not authenticated"));
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role)
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }

        return Task.FromResult(AuthenticateResult.NoResult());
    }

    protected override Task HandleChallengeAsync(AuthenticationProperties properties)
    {
        Context.Response.Redirect("/Account/Login");
        return Task.CompletedTask;
    }

    protected override Task HandleForbiddenAsync(AuthenticationProperties properties)
    {
        Context.Response.Redirect("/Account/Forbidden");
        return Task.CompletedTask;
    }


}