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
        public DbSet<Category> categories { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Category>().HasData(
                new Category
                {
                    categoryID = 1,
                    categoryName = "Action/Adventure"
                }, 
                new Category
                {
                    categoryID = 2,
                    categoryName = "Comedy"
                },
                new Category
                {
                    categoryID = 3,
                    categoryName = "Drama"
                }
                );

            mb.Entity<Movie>().HasData(

                new Movie
                {
                    movieID = 1,
                    title = "Batman",
                    categoryID = 1,
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
                    categoryID = 1,
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
                    categoryID = 1,
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
