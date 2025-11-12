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
        public DbSet<Classification> Classifications { get; set; }
        // No relational tables //

        // More complicated entities with relationships //
        public DbSet<Person> People { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomOfCinema> RoomOfCinemas { get; set; }
        public DbSet<PersonRole> PersonRoles { get; set; }

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
            modelBuilder.Entity<Classification>().ToTable("Classification");
            // No relational tables //

            // More complicated entities with relationships //
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Address>().ToTable("Address");
            modelBuilder.Entity<Street>().ToTable("Street");
            modelBuilder.Entity<Film>().ToTable("Film");
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<RoomOfCinema>().ToTable("RoomOfCinema");
            modelBuilder.Entity<PersonRole>().ToTable("PersonRole");
        }
    }
}
