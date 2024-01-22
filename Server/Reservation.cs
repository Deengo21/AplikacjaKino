﻿using Projekt_Programowanie;
using Projekt_Programowanie.Data;
using Microsoft.EntityFrameworkCore;
using Movie = Projekt_Programowanie.Movie;

public class Reservation
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int MovieId { get; set; }
    public DateTime ReservationDateTime { get; set; }

    public virtual Customer Customer { get; set; }
    public virtual Movie Movie { get; set; }

    private readonly CinemaContext _dbContext;

    public Reservation(CinemaContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task BookTicket(int customerId, int movieId, DateTime reservationDateTime)
    {
        // Sprawdź, czy film o podanym identyfikatorze istnieje i jest dostępny
        var selectedMovie = await _dbContext.Movies
            .FirstOrDefaultAsync(m => m.MovieId == movieId && m.IsAvailable);

        if (selectedMovie == null)
        {
            throw new Exception("Film o podanym identyfikatorze nie istnieje lub nie jest dostępny.");
        }

        // Utwórz nową rezerwację
        var newReservation = new Reservation(_dbContext)
        {
            CustomerId = customerId,
            MovieId = movieId,
            ReservationDateTime = reservationDateTime
        };

        //_dbContext.Reservations.Add(newReservation);
        await _dbContext.SaveChangesAsync();
    }

    public async Task CancelReservation(int reservationId)
    {
        // Znajdź rezerwację do anulowania
        var reservation = await _dbContext.Reservations.FindAsync(reservationId);

        if (reservation == null)
        {
            throw new Exception("Rezerwacja o podanym identyfikatorze nie istnieje.");
        }

        // Usuń rezerwację
        _dbContext.Reservations.Remove(reservation);
        await _dbContext.SaveChangesAsync();
    }

    //public async Task<Reservation> GetReservationDetails(int reservationId)
    //{
    //    // Pobierz szczegóły rezerwacji
    //    var reservation = await _dbContext.Reservations
    //        .Include(r => r.Customer)
    //        .Include(r => r.Movie)
    //        .FirstOrDefaultAsync(r => r.ReservationId == reservationId);

    //    if (reservation == null)
    //    {
    //        throw new Exception("Rezerwacja o podanym identyfikatorze nie istnieje.");
    //    }

    //    //return reservation;
    //}
}