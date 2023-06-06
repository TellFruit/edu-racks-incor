using System.Security.Claims;

public static class HttpContextExtension
{
    public static string GetTokenClaim(this HttpContext httpContext, string claimName)
    {
        var identity = httpContext.User.Identity as ClaimsIdentity;

        var idClaim = identity?.FindFirst(claimName);

        return idClaim?.Value;
    }
}
