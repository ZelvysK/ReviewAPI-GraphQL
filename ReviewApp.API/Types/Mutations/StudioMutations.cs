using HotChocolate.Authorization;
using Microsoft.EntityFrameworkCore;
using ReviewApp.API.Errors;
using ReviewApp.API.Types.Base;
using ReviewApp.API.Types.Inputs;

namespace ReviewApp.API.Types.Mutations;

[ExtendObjectType(Name = Constants.Mutation)]
public class StudioMutations
{
    [Authorize]
    public async Task<Studio> CreateStudio(ReviewContext context, CreateStudioInput input)
    {
        var studio = new Studio
        {
            Name = input.Name,
            Description = input.Description,
            ImageUrl = input.ImageUrl,
            Headquarters = input.Headquarters,
            Founder = input.Founder,
            DateCreated = input.DateFounded,
            Type = input.Type
        };

        context.Studios.Add(studio);

        await context.SaveChangesAsync();

        return studio;
    }

    [Authorize]
    public async Task<Studio> UpdateStudio(ReviewContext context, UpdateStudioInput input)
    {
        var studio = await context.Studios.FirstOrDefaultAsync(s => s.Id == input.Id);

        if (studio is null)
        {
            throw new StudioNotFoundError();
        }

        studio.Name = input.Name;
        studio.Description = input.Description;
        studio.ImageUrl = input.ImageUrl;
        studio.Headquarters = input.Headquarters;
        studio.Founder = input.Founder;
        studio.DateCreated = input.DateFounded;
        studio.Type = input.Type;

        await context.SaveChangesAsync();

        return studio;
    }

    [Authorize]
    public async Task<Studio> DeleteStudio(ReviewContext context, Guid id)
    {
        var studio = await context.Studios.FirstOrDefaultAsync(s => s.Id == id);

        if (studio is null)
        {
            throw new StudioNotFoundError();
        }

        context.Studios.Remove(studio);

        await context.SaveChangesAsync();

        return studio;
    }
}
