using System.Security.Claims;
using HotChocolate.AspNetCore;
using HotChocolate.Execution;
using Microsoft.EntityFrameworkCore;

namespace ReviewApp.API.Extensions;

public class HttpRequestInterceptor : DefaultHttpRequestInterceptor
{
    public override async ValueTask OnCreateAsync(
        HttpContext context,
        IRequestExecutor requestExecutor,
        IQueryRequestBuilder requestBuilder,
        CancellationToken cancellationToken
    )
    {
        var userId = context.User.FindFirstValue("user_id");

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
                identity.AddClaim(new Claim("id", user.Id.ToString()));

                context.User.AddIdentity(identity);
            }
        }

        await base.OnCreateAsync(context, requestExecutor, requestBuilder, cancellationToken);
    }
}
