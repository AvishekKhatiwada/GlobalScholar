using GlobalScholar.Data;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<DbContext, ApplicationDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Database Connection
builder.Services.AddDbContext<ApplicationDbContext>(x => {
    x.UseMySQL(builder.Configuration.GetConnectionString("MyServer"));
});

var app = builder.Build();
app.Services.CreateScope().ServiceProvider.GetService<DbContext>()!.Database.Migrate();

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
