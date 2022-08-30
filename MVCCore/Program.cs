using Microsoft.EntityFrameworkCore;
using MVCCore.Models;
using MVCCore.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("BookDB");

builder.Services.AddDbContext<BookDBContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddSession(item => {
    item.IdleTimeout=TimeSpan.FromMinutes(1);
});


var app = builder.Build();
app.UseSession();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
