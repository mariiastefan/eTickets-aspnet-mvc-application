using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;

namespace eTickets.Data
{
    public class AppDbContext: DbContext
    {
        //readonly IConfiguration _configuration;
        //private string connectionString;
        //public AppDbContext(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
            //GetData();
        }

        //void GetData()
        //{
        //    connectionString = _configuration.GetConnectionString("DefaultConnectionString");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });

            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.ActorId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }


    }
}
