using HotChocolate.Authorization;
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
}
