using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

public class JwtAuthorizeAttribute : AuthorizeAttribute
{
    public JwtAuthorizeAttribute()
    {
        AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;
    }
}
