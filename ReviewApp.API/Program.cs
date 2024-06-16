using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using ReviewApp.API;
using ReviewApp.API.Extensions;
using ReviewApp.API.Types;
using ReviewApp.API.Types.Mutations;
using ReviewApp.API.Types.Queries;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddDbContextPool<ReviewContext>(options =>
    options.UseNpgsql(builder.Configuration["Database:ConnectionString"])
);

builder.Services.AddScoped<SecretManager>();

builder
    .Services.AddGraphQLServer()
    .AddQueryType(d => d.Name(Constants.Query))
    .AddTypeExtension<MeQueries>()
    .AddTypeExtension<StudioQueries>()
    .AddTypeExtension<MediaQueries>()
    .AddMutationConventions()
    .AddMutationType(d => d.Name(Constants.Mutation))
    .AddTypeExtension<AuthMutations>()
    .AddTypeExtension<StudioMutations>()
    .AddTypeExtension<MediaMutations>()
    .AddHttpRequestInterceptor<HttpRequestInterceptor>()
    .RegisterDbContext<ReviewContext>()
    .AddAuthorization();

FirebaseApp.Create(
    new AppOptions { Credential = GoogleCredential.FromFile("firebase-config.json") }
);

builder
    .Services.AddAuthentication()
    .AddJwtBearer(
        JwtBearerDefaults.AuthenticationScheme,
        options =>
        {
            options.Authority = builder.Configuration["Authentication:Issuer"];
            options.Audience = builder.Configuration["Authentication:Audience"];
            options.TokenValidationParameters.ValidIssuer = builder.Configuration[
                "Authentication:Issuer"
            ];
        }
    );

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors(o => o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthentication();

app.UseAuthorization();

app.MapGraphQL();

app.Run();
