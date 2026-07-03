using BlogProjesi.Context;
using BlogProjesi.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BlogDbContext>();


builder.Services.AddDbContext<BlogIdentityDbContext>(options =>
{
    var configuration = builder.Configuration;
    var ConnectionString = configuration.GetConnectionString("Defaultconnection");
    options.UseSqlServer(ConnectionString);
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => {
        options.LoginPath = "Blogs/Index";
        });

builder.Services.AddIdentity<BlogIdentityUser, BlogIdentityRole>()
    .AddEntityFrameworkStores<BlogIdentityDbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Admin}/{action=Index}/{id?}");

app.Run();
