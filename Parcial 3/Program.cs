
using Microsoft.EntityFrameworkCore;
using OficinaPasaportesWeb.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(name:"default", pattern:"{controller=Home}/{action=Index}/{id?}");
app.Run();
