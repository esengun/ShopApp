using Microsoft.Extensions.FileProviders;
using ShopApp.Data.Abstract;
using ShopApp.Data.Concrete.EFCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductRepository, EfCoreProductRepository>(); // DI IProductRepository represents EFCore.... If you want to use ex. MySQL then inject MySQLProductRepository

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapRazorPages();

//app.MapGet("/", () => "Hello World!");


// This maps the controllers that fits to pattern automatically
// this supports urls like
// localhost:5000/
// localhost:5000/home
// localhost:5000/home/index
// localhost:5000/product
// localhost:5000/product/details
// localhost:5000/product/details/2

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); 

app.Run();
