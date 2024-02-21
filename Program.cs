using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using assignment1.Data;
using assignment1.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<assignment1Context>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("assignment1Context") ?? throw new InvalidOperationException("Connection string 'assignment1Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Error Handling
// Send error page to browser, not just code (i.e. 404)
app.UseStatusCodePages();

app.Use(async (context, next) =>
{
    await next();

    if (context.Response.StatusCode == 404)
    {
        context.Request.Path = "/Home/CustomNotFound";
        await next();
    }
});

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
