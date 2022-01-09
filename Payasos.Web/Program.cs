using System.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Payasos.Core.Entities;
using Payasos.Core.Repositories;
using Payasos.Core.Services;
using Payasos.Infrastructure;
using Payasos.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
string connectionString = null;

string envVar = Environment.GetEnvironmentVariable("DATABASE_URL");

if (string.IsNullOrEmpty(envVar))
{
    connectionString = config.GetConnectionString("Default");
}
else
{
    //parse database URL. Format is postgres://<username>:<password>@<host>/<dbname>
    var uri = new Uri(envVar ?? String.Empty);
    var db = uri.LocalPath.TrimStart('/');
    var userInfo = uri.UserInfo.Split(':', StringSplitOptions.RemoveEmptyEntries);
    var username = uri.UserInfo.Split(':')[0];
    var password = uri.UserInfo.Split(':')[1];
    connectionString = $"User ID={userInfo[0]};Password={userInfo[1]};Host={uri.Host};Port={uri.Port};Database={db};Pooling=true;SSL Mode=Require;Trust Server Certificate=True;";
}

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseNpgsql(connectionString);
    opt.EnableSensitiveDataLogging();
});
builder.Services.AddControllersWithViews();

builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
        {
            opt.Password.RequireDigit = false;
            opt.Password.RequiredLength = 5;
            opt.Password.RequireLowercase = false;
            opt.Password.RequireUppercase = false;
            opt.Password.RequiredUniqueChars = 0;
            opt.Password.RequireNonAlphanumeric = false;
        }
    )
    .AddSignInManager<SignInManager<AppUser>>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = new PathString("/login");
    opt.LogoutPath = new PathString("/logout");
});

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<OrganisationService>();
builder.Services.AddScoped<PromotionService>();
builder.Services.AddScoped<IOrganisationRepository, OrganisationRepository>();
builder.Services.AddScoped<IPromotionRequestRepository, PromotionRequestRepository>();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var serviceProvider = builder.Services.BuildServiceProvider();
try
{
    var dbContext = serviceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}
catch
{
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();