using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Data;

namespace MovieApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context =
               new ApplicationDbContext
               (serviceProvider.GetRequiredService<DbContextOptions < ApplicationDbContext >> ()))
            {
                //look for any records, if there are records do nothing
                if (context.Movie.Any())
                {
                    return;
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Lord of the Rings - The Fellowship of the Ring",
                        ReleaseDate = DateTime.Parse("2001 - 12 - 19"),
                        Genre = "Action and Adventure",
                        Price = 8.00m
                    },
                    new Movie
                    {
                        Title = "Lord of the Rings - The Two Towers",
                        ReleaseDate = DateTime.Parse("2002 - 12 - 18"),
                        Genre = "Action and Adventure",
                        Price = 10.00m
                    },
                    new Movie
                    {
                        Title = "Lord of the Rings - The Return of the King",
                        ReleaseDate = DateTime.Parse("2003 - 12 - 17"),
                        Genre = "Action and Adventure",
                        Price = 12.00m
                    }
                    );
                context.SaveChanges();
            }
        }

    }
}
