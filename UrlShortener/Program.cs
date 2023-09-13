using BusinessLogicLayer.Config.Automapper;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.AboutServices;
using BusinessLogicLayer.Services.AboutServices.Impls;
using BusinessLogicLayer.Services.AuthServices;
using BusinessLogicLayer.Services.AuthServices.Impls;
using BusinessLogicLayer.Services.RedirectServices;
using BusinessLogicLayer.Services.RedirectServices.Impls;
using BusinessLogicLayer.Services.RoleServices;
using BusinessLogicLayer.Services.RoleServices.Impls;
using BusinessLogicLayer.Services.UrlServices;
using BusinessLogicLayer.Services.UrlShortenerServices;
using BusinessLogicLayer.Services.UrlShortenerServices.Impls;
using BusinessLogicLayer.Services.UserServices;
using BusinessLogicLayer.Services.UserServices.Impls;
using DataAccessLayer.DbSettings;
using DataAccessLayer.Repos.RoleRepos;
using DataAccessLayer.Repos.RoleRepos.Impls;
using DataAccessLayer.Repos.UrlsRepos;
using DataAccessLayer.Repos.UrlsRepos.Impl;
using DataAccessLayer.Repos.UserRepos;
using DataAccessLayer.Repos.UserRepos.Impls;
using JwtAuthManager;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region DbContext

builder.Services.AddDbContext<UrlShortenerDbContext>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SQLServer"),
    migration => migration.MigrationsAssembly(typeof(UrlShortenerDbContext).Assembly.FullName)),
    ServiceLifetime.Singleton);

#endregion

#region Cors

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:44417")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

#endregion

#region Injections

builder.Services.AddAutoMapper(p => p.AddProfile(new AutoMapperProfile()));
builder.Services.AddSingleton<JwtTokenHandler>();

builder.Services.AddSingleton<IUrlShortenerDbContext, UrlShortenerDbContext>();
builder.Services.AddScoped<IUrlService, UrlService>();
builder.Services.AddScoped<IUrlRepo, UrlRepo>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepo, UserRepo>();

builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IRoleRepo, RoleRepo>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUtilsService, UtilsService>();

builder.Services.AddScoped<IUrlShortenerService, UrlShortenerService>();
builder.Services.AddScoped<IRedirectService, RedirectService>();
builder.Services.AddScoped<IAboutService, AboutService>();

builder.Services.AddHttpContextAccessor();

#endregion

builder.Services.AddControllersWithViews();

builder.Services.AddCustomJwtAuthentication();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
}

#region Routing

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Redirect}/{action=Index}/{id?}");
});

app.MapFallbackToFile("index.html"); ;

#endregion


app.Run();
