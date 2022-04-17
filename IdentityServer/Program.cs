using IdentityServer;
using IdentityServerHost.Quickstart.UI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddIdentityServer()
   .AddInMemoryClients(Config.Clients)
   .AddInMemoryApiScopes(Config.ApiScopes)
   .AddInMemoryIdentityResources(Config.IdentityResources)
   //.AddInMemoryApiResources(Config.ApiResources)
   .AddTestUsers(TestUsers.Users)
   .AddDeveloperSigningCredential();

var app = builder.Build();


//app.MapGet("/", () => "Hello World!");

app.UseStaticFiles();
app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.Run();
