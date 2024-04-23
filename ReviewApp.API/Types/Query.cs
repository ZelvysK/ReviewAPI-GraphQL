namespace ReviewApp.API.Types;

public class Query
{
    [UseOffsetPaging]
    public IQueryable<Studio> GetStudios(ReviewContext context) => context.Studios.AsQueryable();

    [UseOffsetPaging]
    public IQueryable<Media> GetMedia(ReviewContext context) => context.Media.AsQueryable();
}
