using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using ShopApp.Business.Abstract;
using ShopApp.Business.Concrete;
using ShopApp.Data.Abstract;
using ShopApp.Data.Concrete.EFCore;
using ShopApp.WebUI.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer("Data Source=MUSTAFA;Initial Catalog=ShopDB;Integrated Security=SSPI;TrustServerCertificate=True;"));
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(options =>
{
	// password
	options.Password.RequireDigit = true;
	options.Password.RequireLowercase = true;
	options.Password.RequireUppercase = true;
	options.Password.RequiredLength = 6;
	options.Password.RequireNonAlphanumeric = true;

	// Lockout
	options.Lockout.MaxFailedAccessAttempts = 5;
	options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
	options.Lockout.AllowedForNewUsers = true;

	// options.User.AllowedUserNameCharacters = "";
	options.User.RequireUniqueEmail = true;
	options.SignIn.RequireConfirmedEmail = false;
	options.SignIn.RequireConfirmedPhoneNumber	= false;
});

builder.Services.ConfigureApplicationCookie(options =>
{
	options.LoginPath = "/account/login";
	options.LogoutPath = "/account/logout";
	options.AccessDeniedPath = "/account/accessdenied";
	options.SlidingExpiration = true; // if user does not do any action for ExpireTimeSpan, their cookie will be invalid so user needs to login again
	options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // It resets the timer when a request is made within 60 mins
	options.Cookie = new CookieBuilder
	{
		HttpOnly = true,
		Name = ".ShopApp.Security.Cookie"
	};
});


builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductRepository, EfCoreProductRepository>(); // DI IProductRepository represents EFCore.... If you want to use ex. MySQL then inject MySQLProductRepository
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>(); 
builder.Services.AddScoped<ICategoryService, CategoryManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
SeedDatabase.Seed();
app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
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

// the order of these routes are important as it checks given url 
// one by one and calls the matched controller

app.MapControllerRoute(
	name: "products",
	pattern: "products/{category?}",
	defaults: new { controller = "Shop", action = "list" });

app.MapControllerRoute(
	name: "admincategorylist",
	pattern: "admin/categories",
	defaults: new { controller = "Admin", action = "CategoryList" });

app.MapControllerRoute(
	name: "admincategorylist",
	pattern: "admin/categories/{id?}",
	defaults: new { controller = "Admin", action = "EditCategory" });

app.MapControllerRoute(
	name: "admincategorylist",
	pattern: "admin/categories/delete/{id?}",
	defaults: new { controller = "Admin", action = "DeleteCategory" });

app.MapControllerRoute(
	name: "adminproductlist",
	pattern: "admin/products",
	defaults: new { controller = "Admin", action = "ProductList" });

app.MapControllerRoute(
	name: "adminproductlist",
	pattern: "admin/products/{id?}",
	defaults: new { controller = "Admin", action = "EditProduct" });

app.MapControllerRoute(
	name: "adminproductlist",
	pattern: "admin/products/delete/{id?}",
	defaults: new { controller = "Admin", action = "DeleteProduct" });

app.MapControllerRoute(
	name: "search",
	pattern: "search",
	defaults: new { controller = "Shop", action = "search" });

app.MapControllerRoute(
	name: "productdetails",
	pattern: "{url}",
	defaults: new { controller = "Shop", action = "details" });



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); 

app.Run();
