using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>())) // that stuff has been registered in
                                                           // StartUp.ConfigureServices
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return; // DB has been seeded.
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Commedy",
                        Price = 15.94M,
                        Rating = "A"
                    },

                    new Movie
                    {
                        Title = "Whatever is written Here",
                        ReleaseDate = DateTime.Parse("2015-4-11"),
                        Genre = "Some bullshit",
                        Price = 11.22M,
                        Rating = "B"
                    },

                    new Movie
                    {
                        Title = "The last Movie I write",
                        ReleaseDate = DateTime.Parse("1111-11-11"),
                        Genre = "Drama",
                        Price = 35.99M,
                        Rating = "C"
                    });
                context.SaveChanges();
            }
        }
    }
}