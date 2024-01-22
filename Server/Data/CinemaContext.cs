using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Npgsql;

namespace Projekt_Programowanie.Data
{
    public class CinemaContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Movie> Movies { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Screening> Screenings { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Reservation> Reservations { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<User> Users { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Room> Rooms { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Payment> Payments { get; set; }
        public object SoftwareErrors { get; internal set; }
        public object Employees { get; internal set; }
        public object Customers { get; internal set; }

        private readonly IConfiguration _configuration;

        public CinemaContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konfiguracja tabeli Movies
            modelBuilder.Entity<Movie>()
                .HasKey(m => m.MovieId);

            modelBuilder.Entity<Movie>()
                .Property(m => m.Title)
                .HasColumnName("title")
                .HasMaxLength(50);

            modelBuilder.Entity<Movie>()
                .Property(m => m.Director)
                .HasColumnName("director")
                .HasMaxLength(40);

            modelBuilder.Entity<Movie>()
                .Property(m => m.Length)
                .HasColumnName("length");

            modelBuilder.Entity<Movie>()
                .Property(m => m.FilmGenre)
                .HasColumnName("film_genre")
                .HasMaxLength(20);

            // Konfiguracja tabeli Screening
            modelBuilder.Entity<Screening>()
                .HasKey(s => s.ScreeningId);

            modelBuilder.Entity<Screening>()
                .Property(s => s.Date)
                .HasColumnName("date");

            modelBuilder.Entity<Screening>()
                .Property(s => s.Time)
                .HasColumnName("time");

            // Konfiguracja tabeli Reservations
            modelBuilder.Entity<Reservation>()
                .HasKey(r => r.ReservationId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Payment)
                .WithMany(p => p.Reservations)
                .HasForeignKey(r => r.PaymentId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Screening)
                .WithMany(s => s.Reservations)
                .HasForeignKey(r => r.ScreeningId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Movie)
                .WithMany(m => m.Reservations)
                .HasForeignKey(r => r.MovieId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Room)
                .WithMany(ro => ro.Reservations)
                .HasForeignKey(r => r.RoomId);

            // Konfiguracja tabeli Users
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<User>()
                .Property(u => u.Privilege)
                .HasColumnName("privilege");

            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .HasColumnName("username")
                .HasMaxLength(25);

            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .HasColumnName("password");

            // Konfiguracja tabeli Rooms
            modelBuilder.Entity<Room>()
                .HasKey(ro => ro.RoomId);

            modelBuilder.Entity<Room>()
                .Property(ro => ro.Row)
                .HasColumnName("row");

            modelBuilder.Entity<Room>()
                .Property(ro => ro.Seat)
                .HasColumnName("seat");

            // Konfiguracja tabeli Payments
            modelBuilder.Entity<Payment>()
                .HasKey(p => p.PaymentId);

            modelBuilder.Entity<Payment>()
                .Property(p => p.Cost)
                .HasColumnName("cost");

            modelBuilder.Entity<Payment>()
                .Property(p => p.PaymentMethod)
                .HasColumnName("payment_method")
                .HasMaxLength(20);
        }
    }
}

