namespace ReviewApp.API.Types.DataLoaders;



// public class StudioByIdDataLoader(
//     IDbContextFactory<ReviewContext> dbContextFactory,
//     IBatchScheduler batchScheduler,
//     DataLoaderOptions options
// ) : BatchDataLoader<Guid, Studio>(batchScheduler, options)
// {
//     protected override async Task<IReadOnlyDictionary<Guid, Studio>> LoadBatchAsync(
//         IReadOnlyList<Guid> keys,
//         CancellationToken ct
//     )
//     {
//         await using var dbContext = await dbContextFactory.CreateDbContextAsync(ct);
//
//         return await dbContext
//             .Studios.Where(s => keys.Contains(s.Id))
//             .ToDictionaryAsync(t => t.Id, ct);
//     }
// }
