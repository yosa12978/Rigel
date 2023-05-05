using System.Net.Http.Headers;
using System.Security.AccessControl;
using System.ComponentModel.Design.Serialization;
using Microsoft.EntityFrameworkCore;
using Rigel.EFCore.Data;
using Rigel.EFCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddEFCoreRepositories(builder.Configuration.GetConnectionString("Sqlite") ?? "Data source = data.db");
builder.Services.AddBasicServices();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => { options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/user/login"); });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
