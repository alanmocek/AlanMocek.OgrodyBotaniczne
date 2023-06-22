using AlanMocek.OgrodyBotaniczne.Mvc.Db;
using AlanMocek.OgrodyBotaniczne.Mvc.Domain.BotanicGardenAggregate;
using Microsoft.EntityFrameworkCore;

namespace AlanMocek.OgrodyBotaniczne.Mvc.Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<Program>());
            builder.Services.AddDbContext<OgrodyBotaniczneContext>(c => c.UseInMemoryDatabase("Db"));

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<OgrodyBotaniczneContext>();
                context.Database.EnsureDeleted();

                if(!context.BotanicGardens.Any())
                {
                    var botanicGarden = new BotanicGarden(2)
                    {
                        AllowedTripsPerDay = 2
                    };

                    botanicGarden.AddZone("A", 5, 5);
                    botanicGarden.AddZone("B", 15, 5);
                    botanicGarden.AddZone("C", 50, 30);

                    //botanicGarden.RegisterTrip(6, new DateOnly(2023, 6, 24), "Komentarz",
                    //    new List<TripZone>()
                    //    {
                    //    new TripZone(botanicGarden.Zones.First(zone => zone.Label == "A"), "Komentarz 2")
                    //    });

                    //botanicGarden.RegisterTrip(10, new DateOnly(2023, 6, 22), comment: "Komentarz2",
                    //    new List<TripZone>()
                    //    {
                    //    new TripZone(botanicGarden.Zones.First(zone => zone.Label == "B"), "Komentarz 2"),
                    //    new TripZone(botanicGarden.Zones.First(zone => zone.Label == "C"), "Komentarz 3"),
                    //    });

                    context.BotanicGardens.Add(botanicGarden);
                    context.SaveChanges();
                }
            }

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
        }
    }
}