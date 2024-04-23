using Microsoft.EntityFrameworkCore;
using ReviewApp.API;
using ReviewApp.API.Types;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPooledDbContextFactory<ReviewContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder
    .Services.AddGraphQLServer()
    .RegisterDbContext<ReviewContext>(DbContextKind.Pooled)
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGraphQL();

app.Run();
