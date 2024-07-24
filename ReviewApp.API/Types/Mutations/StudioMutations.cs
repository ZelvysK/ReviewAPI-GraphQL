using HotChocolate.Authorization;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using ReviewApp.API.Errors;
using ReviewApp.API.Extensions;
using ReviewApp.API.Types.Base;
using ReviewApp.API.Types.Inputs;

namespace ReviewApp.API.Types.Mutations;

[MutationType]
public class StudioMutations
{
    [Authorize]
    [Error<GqException>]
    public async Task<Studio> CreateStudio(
        ReviewContext reviewContext,
        CreateStudioInput input,
        IResolverContext context
    )
    {
        var userId = context.GetUserId();

        var studioByName = await reviewContext.Studios.FirstOrDefaultAsync(s =>
            s.Name == input.Name
        );

        if (studioByName is not null)
        {
            throw new GqException(GqErrors.Entity.AlreadyExists);
        }

        var studio = new Studio
        {
            Name = input.Name,
            Description = input.Description,
            ImageUrl = input.ImageUrl,
            Headquarters = input.Headquarters,
            Founder = input.Founder,
            StudioType = input.StudioType,
            DateEstablished = input.DateEstablished,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = userId.ToString(),
        };

        reviewContext.Studios.Add(studio);

        await reviewContext.SaveChangesAsync();

        return studio;
    }

    [Authorize]
    [Error<GqException>]
    public async Task<Studio> UpdateStudio(
        ReviewContext reviewContext,
        UpdateStudioInput input,
        IResolverContext context
    )
    {
        var userId = context.GetUserId();

        var studio = await reviewContext.Studios.FirstOrDefaultAsync(s => s.Id == input.Id);

        if (studio is null)
        {
            throw new GqException(GqErrors.Entity.NotFound);
        }

        studio.Name = input.Name;
        studio.Description = input.Description;
        studio.ImageUrl = input.ImageUrl;
        studio.Headquarters = input.Headquarters;
        studio.Founder = input.Founder;
        studio.StudioType = input.StudioType;
        studio.DateEstablished = input.DateEstablished;

        studio.ModifiedAt = DateTime.UtcNow;
        studio.ModifiedBy = userId.ToString();

        await reviewContext.SaveChangesAsync();

        return studio;
    }

    [Authorize]
    [Error<GqException>]
    public async Task<Studio> DeleteStudio(ReviewContext context, Guid id)
    {
        var studio = await context.Studios.FindAsync(id);

        if (studio is null)
        {
            throw new GqException(GqErrors.Entity.NotFound);
        }

        context.Studios.Remove(studio);

        await context.SaveChangesAsync();

        return studio;
    }
}
