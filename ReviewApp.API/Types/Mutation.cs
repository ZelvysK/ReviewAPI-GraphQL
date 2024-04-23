using ReviewApp.API.Types.Inputs;

namespace ReviewApp.API.Types;

public class Mutation
{
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

    public async Task<Media> CreateMedia(ReviewContext context, CreateMediaInput input)
    {
        var media = new Media
        {
            MediaType = input.MediaType,
            Genre = input.Genre,
            Name = input.Name,
            CoverImageUrl = input.CoverImageUrl,
            Description = input.Description,
            StudioId = input.StudioId,
            PublishedBy = input.PublishedBy,
            DateCreated = input.DateFounded,
            DatePosted = DateTime.Now
        };

        context.Media.Add(media);

        await context.SaveChangesAsync();

        return media;
    }
}
