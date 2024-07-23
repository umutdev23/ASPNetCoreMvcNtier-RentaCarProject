using Microsoft.EntityFrameworkCore;
using RentACar.DataAccess.Contexts;
using RentACar_Service.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<RentACarDbContext>(
		options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr"))
	);

builder.Services.AddExtensions();

var app = builder.Build();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
	  name: "admin",
	  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
	);


app.Run();
