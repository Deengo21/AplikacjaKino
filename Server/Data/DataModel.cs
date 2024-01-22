﻿namespace Projekt_Programowanie.Data
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public int Length { get; set; }
        public string FilmGenre { get; set; }
        public List<Reservation> Reservations { get; set; }

        public List<Screening> Screenings { get; set; }
        public bool IsAvailable { get; internal set; }
        public object Id { get; internal set; }
    }

    public class Screening
    {
        public int ScreeningId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public List<Reservation> Reservations { get; set; }
        public object Id { get; internal set; }
        public object DateTime { get; internal set; }
        public int RoomId { get; internal set; }
        public int Duration { get; internal set; }
        public int RoomNumber { get; internal set; }
    }

    public class Reservation
    {
        public int ReservationId { get; set; }

        public int ScreeningId { get; set; }
        public Screening Screening { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }

        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
        public object Seat { get; internal set; }
        public object Customer { get; internal set; }
        public object SeatNumber { get; internal set; }
        public bool IsAvailable { get; internal set; }
        public object ReservationDateTime { get; internal set; }
    }

    public class User
    {
        public int UserId { get; set; }
        public int Privilege { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public List<Reservation> Reservations { get; set; }
        public string Email { get;  set; }
        public string PasswordHash { get; set; }
        public object Id { get; internal set; }
        public object Name { get; internal set; }
    }

    public class Room
    {
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public int Row { get; set; }
        public int Seat { get; set; }
        public int TotalSeats { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<Projekt_Programowanie.Screening> Screenings { get; internal set; }
    }

    public class Payment
    {
        public int PaymentId { get; set; }
        public decimal Cost { get; set; }
        public string PaymentMethod { get; set; }

        public DateTime PaymentDate { get; set; }

        public bool IsConfirmed { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}