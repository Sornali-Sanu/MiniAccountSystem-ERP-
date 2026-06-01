using Microsoft.EntityFrameworkCore;
using MiniAccountSystem.Application.Interfaces;
using MiniAccountSystem.Application.Services;
using MiniAccountSystem.Infrastructure.Data;
using MiniAccountSystem.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
//Add database:

builder.Services.AddDbContext<ApplicationDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("con")));

// Add services to the container.
builder.Services.AddControllersWithViews();

//DI:
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
