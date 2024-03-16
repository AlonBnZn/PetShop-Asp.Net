using Microsoft.EntityFrameworkCore;
using Pet_Shop_Application.Data;
using Pet_Shop_Application.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IPetShopRepository, PetShopRepository>();
string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"]!;
builder.Services.AddDbContext<PetShopContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));
builder.Services.AddControllersWithViews();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<PetShopContext>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{id?}");

app.Run();
