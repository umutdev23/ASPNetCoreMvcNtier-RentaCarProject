using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RentACar.DataAccess.Contexts;
using RentACar.DataAccess.Identity;
using RentACar.DataAccess.Repositories;
using RentACar.DataAccess.UnitOfWorks;
using RentACar_Entity.Repositories;
using RentACar_Entity.Services;
using RentACar_Entity.UnitOfWorks;
using RentACar_Service.Mapping;
using RentACar_Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_Service.Extensions
{
	public static class DependencyExtensions
	{
		public static void AddExtensions(this IServiceCollection services)
		{
			services.AddIdentity<AppUser, AppRole>(
				opt =>
				{
					opt.Password.RequireNonAlphanumeric = false;
					opt.Password.RequiredLength = 3;
					opt.Password.RequireLowercase = false;
					opt.Password.RequireUppercase = false;
					opt.Password.RequireDigit = false;

					opt.User.RequireUniqueEmail = true;  //aynı email adresinin girilmesine izin vermez.

					//opt.User.AllowedUserNameCharacters = "abcdefghjklmnoprstuvyzqw0123456789";  //Kullanıcı adı girilirken sadece bu karakterlere izin verir.

					opt.Lockout.MaxFailedAccessAttempts = 3; //default=5
					opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1); //default=5
				}
			).AddEntityFrameworkStores<RentACarDbContext>();

			services.ConfigureApplicationCookie(opt =>
			{
				opt.LoginPath = new PathString("/Account/Login");
				opt.LogoutPath = new PathString("/Account/Logout");
				//opt.AccessDeniedPath = new PathString("Account/AccesDenied");
				opt.ExpireTimeSpan = TimeSpan.FromMinutes(10);
				opt.SlidingExpiration = true; // 10 dk dolmadan kullanıcı yeniden login olursa süre baştan başlar.

				opt.Cookie = new CookieBuilder()
				{
					Name = "Identity.App.Cookie",
					HttpOnly = true
				};
			}
			);
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IReservationService, ReservationService>();
			



            //services.AddScoped<ICategoryService, CategoryService>();


            services.AddAutoMapper(typeof(MappingProfile));
		}
	}
}
