using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("ocelot.json");
});
//    .ConfigureWebHostDefaults(webBuilder =>
//{
//    webBuilder.UseStartup<Program>();
//});

var authenticationProviderKey = "IdentityApiKey";

// NUGET - Microsoft.AspNetCore.Authentication.JwtBearer
builder.Services.AddAuthentication()
 .AddJwtBearer(authenticationProviderKey, x =>
 {
     x.Authority = "https://localhost:5005"; // IDENTITY SERVER URL
     x.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateAudience = false
     };
     //x.RequireHttpsMetadata = false;
 });

builder.Services.AddOcelot();

var app = builder.Build();

app.MapControllers();

await app.UseOcelot();

app.Run();
