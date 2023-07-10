using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace SportsStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices
            .CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                new Product
                {
                    Name = "Boat",
                    Description = "A boat for one person",
                    Category = "Watersports",
                    Price = 299
                },
                new Product
                {
                    Name = "Helmet",
                    Description = "Protective and fashionable",
                    Category = "Outdoor activities",
                    Price = 59.95m
                },
                new Product
                {
                    Name = "Knee pads",
                    Description = "Protective knee pads for kids",
                    Category = "Outdoor activities",
                    Price = 29.50m
                },
                new Product
                {
                    Name = "Volleyball ball",
                    Description = "Approved size and weight",
                    Category = "Outdoor activities",
                    Price = 34.95m
                },
                new Product
                {
                    Name = "Swimsuit",
                    Description = "New, fashionable model for women",
                    Category = "Watersports",
                    Price = 99.99m
                },
                new Product
                {
                    Name = "Swimming googles",
                    Description = "With anti-fog coating",
                    Category = "Watersports",
                    Price = 45
                },
                new Product
                {
                    Name = "Swimming fins",
                    Description = "Match from 36-39 size",
                    Category = "Watersports",
                    Price = 35.95m
                },
                new Product
                {
                    Name = "Trekking shoes",
                    Description = "Waterproof and fashionable men shoes",
                    Category = "Outdoor activities",
                    Price = 75
                },
                new Product
                {
                    Name = "Bike",
                    Description = "New 2023 Kross model",
                    Category = "Outdoor activities",
                    Price = 1100
                }
                );
                context.SaveChanges();
            }
        }
    }
}
