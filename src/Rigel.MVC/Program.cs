using System.Net.Http.Headers;
using System.Security.AccessControl;
using System.ComponentModel.Design.Serialization;
using Microsoft.EntityFrameworkCore;
using Rigel.EFCore.Data;
using Rigel.EFCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddEFCoreRepositories(builder.Configuration.GetConnectionString("Sqlite") ?? "Data source = data.db");
builder.Services.AddBasicServices();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
