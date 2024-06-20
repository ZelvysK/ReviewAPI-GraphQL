using System.Security.Claims;
using ReviewApp.API.Errors;
using ReviewApp.API.Types.Base;

namespace ReviewApp.API.Extensions;

public class ResolverContext(IHttpContextAccessor accessor)
{
    public Guid GetUserId()
    {
        var userId = accessor.HttpContext?.User.FindFirstValue("id");

        if (Guid.TryParse(userId, out var parsedUserId))
        {
            return parsedUserId;
        }

        throw new EntityNotFoundException(nameof(User));
    }
}
