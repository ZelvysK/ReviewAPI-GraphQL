using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using ReviewApp.API;
using ReviewApp.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<ResolverContext>();

builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddDbContextPool<ReviewContext>(options =>
    options.UseNpgsql(builder.Configuration["Database:ConnectionString"])
);

builder.Services.AddScoped<SecretManager>();

builder
    .Services.AddGraphQLServer()
    .AddQueryType()
    .AddMutationType()
    .AddMutationConventions()
    .AddAPITypes()
    .AddHttpRequestInterceptor<HttpRequestInterceptor>()
    .RegisterService<ResolverContext>()
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
