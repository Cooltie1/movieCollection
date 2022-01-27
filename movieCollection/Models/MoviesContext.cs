using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieCollection.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base (options)
        {

        }

        public DbSet<Movie> movies { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Movie>().HasData(

                new Movie
                {
                    movieID = 1,
                    title = "Batman",
                    category = "Action/Adventure",
                    year = 1989,
                    director = "Tim Burton",
                    rating = "PG-13",
                    edited = false,
                    lentTo = "",
                    notes = ""
                },
                new Movie
                {
                    movieID = 2,
                    title = "Batman & Robin",
                    category = "Action/Adventure",
                    year = 1997,
                    director = "Joel Schumacher",
                    rating = "PG-13",
                    edited = false,
                    lentTo = "",
                    notes = ""
                },
                new Movie
                {
                    movieID = 3,
                    title = "Batman Begins",
                    category = "Action/Adventure",
                    year = 2005,
                    director = "Christopher Nolan",
                    rating = "PG-13",
                    edited = false,
                    lentTo = "",
                    notes = ""
                }
                );
        }
    }
}
