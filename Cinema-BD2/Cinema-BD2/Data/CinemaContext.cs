using Cinema_BD2.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema_BD2.Data
{
    public class CinemaContext :DbContext
    {
        public CinemaContext(DbContextOptions<CinemaContext> options)
            : base(options)
        {
        }
        // No relational tables //
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<TypeOfRoom> TypeOfRooms { get; set; }
        // No relational tables //


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // No relational tables //
            modelBuilder.Entity<Genre>().ToTable("Genre");
            modelBuilder.Entity<Language>().ToTable("Language");
            modelBuilder.Entity<Gender>().ToTable("Gender");
            modelBuilder.Entity<District>().ToTable("District");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Studio>().ToTable("Studio");
            modelBuilder.Entity<TypeOfRoom>().ToTable("TypeOfRoom");
            // No relational tables //


        }
    }
}
