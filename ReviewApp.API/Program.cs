using FirebaseAdmin;
using FirebaseAdminAuthentication.DependencyInjection.Extensions;
using Google.Apis.Auth.OAuth2;
using Microsoft.EntityFrameworkCore;
using ReviewApp.API;
using ReviewApp.API.Types;
using ReviewApp.API.Types.Mutations;
using ReviewApp.API.Types.Queries;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddPooledDbContextFactory<ReviewContext>(options =>
    options.UseNpgsql(builder.Configuration["Database:ConnectionString"])
);

builder.Services.AddScoped<SecretManager>();

builder
    .Services.AddGraphQLServer()
    .RegisterDbContext<ReviewContext>(DbContextKind.Pooled)
    .AddQueryType(d => d.Name(Constants.Query))
    .AddTypeExtension<StudioQueries>()
    .AddTypeExtension<MediaQueries>()
    .AddMutationConventions()
    .AddMutationType(d => d.Name(Constants.Mutation))
    .AddTypeExtension<AuthMutations>()
    .AddTypeExtension<StudioMutations>()
    .AddTypeExtension<MediaMutations>()
    .AddAuthorization();

builder.Services.AddSingleton(
    FirebaseApp.Create(
        new AppOptions
        {
            Credential = GoogleCredential.FromJson(
                builder.Configuration.GetValue<string>("FIREBASE_CFG")
            )
        }
    )
);

builder.Services.AddFirebaseAuthentication();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors(o => o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthentication();

app.MapGraphQL();

app.Run();
