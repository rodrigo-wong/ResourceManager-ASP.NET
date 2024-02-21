using assignment1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
namespace assignment1.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new assignment1Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<assignment1Context>>()))
            {
                // Look for any movies.
                if (context.Game.Any())
                {
                    return;   // DB has been seeded
                }
                context.Game.AddRange(
                    new Game
                    {
                        Title = "Valorant",
                        Developer = "Riot",
                        Genre = "fps",
                        ReleaseYear = 2020,
                        PurchaseDate = DateTime.Now,
                        Rating = 80
                    },
                    new Game
                    {
                        Title = "Tomb Raider",
                        Developer = "Crystal Dynamics",
                        Genre = "adventure",
                        ReleaseYear = 2001,
                        PurchaseDate = DateTime.Parse("2020-2-23"),
                        Rating = 60
                    },
                    new Game
                    {
                        Title = "Phasmophobia",
                        Developer = "Kinetic Games",
                        Genre = "horror",
                        ReleaseYear = 2020,
                        PurchaseDate = DateTime.Parse("2021-1-10"),
                        Rating = 60
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
