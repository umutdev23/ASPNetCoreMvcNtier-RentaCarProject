using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentACar.DataAccess.Identity;
using RentACar_Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DataAccess.Contexts
{
    public class RentACarDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public RentACarDbContext(DbContextOptions<RentACarDbContext> options) : base(options)
        { }
        public DbSet<CustomerUser> CustomerUsers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        
        public DbSet<Location> Locations { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin<int>>().HasKey(x => new { x.LoginProvider, x.ProviderKey });
            modelBuilder.Entity<IdentityUserRole<int>>().HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserToken<int>>().HasKey(x => new { x.UserId, x.LoginProvider, x.Name });


            modelBuilder.Entity<Car>()
        .Property(m => m.Price)
        .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Reservation>()
                .Property(r => r.TotalPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Reservation>()
            .HasOne(r => r.CustomerUser)
            .WithMany()
            .HasForeignKey(r => r.CustomerUserId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CustomerUser>().Property(u => u.IsDeleted).HasDefaultValue(false);

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Location)
                .WithMany(l => l.Cars)
                .HasForeignKey(c => c.LocationId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Model>()
                .HasOne(m => m.Brand)
                .WithMany(b => b.Models)
                .HasForeignKey(m => m.BrandId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<VehicleType>().HasData(

                new VehicleType() { Id = 1, Name = "Sedan" },
                new VehicleType() { Id = 2, Name = "Hatchback" },
                new VehicleType() { Id = 3, Name = "Suv" },
                new VehicleType() { Id = 4, Name = "Sport" }
                );

            modelBuilder.Entity<Brand>().HasData(

                new Brand() { Id = 1, Name = "Bmw" },
                new Brand() { Id = 2, Name = "Mercedes" },
                new Brand() { Id = 3, Name = "Audi" },
                new Brand() { Id = 4, Name = "DS" },
                new Brand() { Id = 5, Name = "Porsche" }


                );

            modelBuilder.Entity<Model>().HasData(

                new Model() { Id = 1, Name = "3.20 i", BrandId = 1, FuelType = "Benzin", GearBoxType = "Otomatik", Description = "BMW 3 Serisi 320d Luxury Line, 3 Serisi serisinin en üst modelidir ve bu modelin en hızlı versiyonudur. 3 Serisi'nin en üst modeli 20.37 km/l yakıt tüketimi sağlar. BMW 3 Serisi 320d Luxury Line, Otomatik (TC) şanzımanla sunulmaktadır ve 3 renk seçeneği mevcuttur: Akdeniz Mavi Metalik, Siyah Safir Metalik ve Alpin Beyaz.", VehicleTypeId = 1 },
                new Model() { Id = 2, Name = "C200", BrandId = 2, FuelType = "Dizel", Description = "Bir dizi kompakt yönetici arabası", GearBoxType = "Otomatik", VehicleTypeId = 1 },
                new Model() { Id = 3, Name = "A4", BrandId = 3, FuelType = "Benzin", GearBoxType = "Otomatik", Description = "Bir dizi kompakt yönetici arabası", VehicleTypeId = 1 },
                new Model() { Id = 4, Name = "Ds-7", BrandId = 4, FuelType = "Dizel", GearBoxType = "Otomatik", Description = "Güvenilir, şık bir suv", VehicleTypeId = 3 },
                new Model() { Id = 5, Name = "Taycan", BrandId = 5, FuelType = "Benzin", GearBoxType = "Otomatik", Description = "Bir spor arabadan beklenen her şey", VehicleTypeId = 4 }


                );
            modelBuilder.Entity<Car>().HasData(

                new Car() { Id = 1, ModelId = 1, Price = 2000, PictureUrl = "/images/bmw-320.jpg", LocationId = 1 },
                new Car() { Id = 2, ModelId = 2, Price = 2850, PictureUrl = "/images/mercedes-c200.jpg", LocationId = 1 },
                new Car() { Id = 3, ModelId = 3, Price = 2500, PictureUrl = "/images/audi-a4.jpg", LocationId = 2 },
                new Car() { Id = 4, ModelId = 4, Price = 3000, PictureUrl = "/images/ds-7.jpg", LocationId = 3 },
                new Car() { Id = 5, ModelId = 5, Price = 4500, PictureUrl = "/images/porsche-taycan.jpg", LocationId = 3 }


                );
            modelBuilder.Entity<Location>().HasData(

                new Location() { Id = 1, City = "Istanbul", Region = "Besiktas" },
                new Location() { Id = 2, City = "Istanbul", Region = "Bakırkoy" },
                new Location() { Id = 3, City = "Istanbul", Region = "Kadıkoy" }


                );
            modelBuilder.Entity<Reservation>().HasData(

                new Reservation() { Id = 1, LocationId = 1, CarId = 1, StartDay = new DateTime(2024, 7, 19), EndDay = new DateTime(2024, 8, 19), TotalPrice = 19000 });


            base.OnModelCreating(modelBuilder); //sonradan ekledim model
        }
    }
}