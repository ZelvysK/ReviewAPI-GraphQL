using System.Security.Claims;
using HotChocolate.AspNetCore;
using HotChocolate.Execution;
using Microsoft.EntityFrameworkCore;

namespace ReviewApp.API.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static string? GetUserId(this ClaimsPrincipal principal) =>
        principal.FindFirstValue("user_id");
}

// public class CustomClaimsTransformer(ReviewContext context) : IClaimsTransformation
// {
//     public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
//     {
//         if (principal.Identity is not ClaimsIdentity { IsAuthenticated: true } identity)
//             return principal;
//
//         var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
//
//         if (userId is null)
//             return principal;
//
//         var user = await context
//             .Users.Select(x => new { x.RemoteId, x.Role })
//             .FirstOrDefaultAsync(x => x.RemoteId == userId);
//
//         if (user?.Role is UserRole.Admin)
//         {
//             identity.AddClaim(new Claim("IsAdmin", "true"));
//         }
//
//         return principal;
//     }
// }

public class HttpRequestInterceptor : DefaultHttpRequestInterceptor
{
    public override async ValueTask OnCreateAsync(
        HttpContext context,
        IRequestExecutor requestExecutor,
        IQueryRequestBuilder requestBuilder,
        CancellationToken cancellationToken
    )
    {
        var userId = context.User.GetUserId();

        if (userId is not null)
        {
            await using var db = context.RequestServices.GetRequiredService<ReviewContext>();

            var user = await db.Users.FirstOrDefaultAsync(
                x => x.RemoteId == userId,
                cancellationToken: cancellationToken
            );

            if (user is not null)
            {
                var identity = new ClaimsIdentity();

                identity.AddClaim(new Claim(ClaimTypes.Role, user.Role.ToString()));

                context.User.AddIdentity(identity);
            }
        }

        await base.OnCreateAsync(context, requestExecutor, requestBuilder, cancellationToken);
    }
}
