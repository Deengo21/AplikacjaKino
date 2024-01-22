using Microsoft.EntityFrameworkCore;
using Projekt_Programowanie.Data;
using System.Text;

namespace Projekt_Programowanie
{
    public class Admin
    {
        private readonly CinemaContext _dbContext;

        public Admin(CinemaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Login(string email, string password)
        {
            var x = new Customer(_dbContext);
            var admin = await _dbContext.Users.FirstOrDefaultAsync(a => a.Email == email);

            if (admin == null || !x.VerifyPassword(password, admin.PasswordHash))
            {
                throw new Exception("Nieprawidłowy adres e-mail lub hasło.");
            }
        }

        // Zarządzanie kontami użytkowników
        public async Task ManageAccounts()
        {
            // Wyświetl listę wszystkich użytkowników do zarządzania
            var users = await _dbContext.Users.ToListAsync();

            // Tutaj można dodać kod obsługi zarządzania kontami użytkowników
            // Na przykład, wyświetlanie, edycja, usuwanie kont itp.

            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}, Imię: {user.Name}, Email: {user.Email}");
                Console.WriteLine("------------------------------");
            }
        }

        // Zarządzanie filmami
        public async Task ManageMovies()
        {
            // Wyświetl listę wszystkich filmów do zarządzania
            var movies = await _dbContext.Movies.ToListAsync();

            // Tutaj można dodać kod obsługi zarządzania filmami
            // Na przykład, dodawanie nowych filmów, edycja informacji o filmach, usuwanie filmów itp.

            foreach (var movie in movies)
            {
                Console.WriteLine($"ID: {movie.Id}, Tytuł: {movie.Title}, Dostępność: {movie.IsAvailable}");
                Console.WriteLine("------------------------------");
            }
        }

        // Zarządzanie seansami
        public async Task ManageScreenings()
        {
            // Wyświetl listę wszystkich seansów do zarządzania
            var screenings = await _dbContext.Screenings.ToListAsync();

            // Tutaj można dodać kod obsługi zarządzania seansami
            // Na przykład, dodawanie nowych seansów, edycja informacji o seansach, usuwanie seansów itp.

            foreach (var screening in screenings)
            {
                Console.WriteLine($"ID: {screening.Id}, Film: {screening.Movie.Title}, Data i godzina: {screening.DateTime}");
                Console.WriteLine("------------------------------");
            }
        }

        // Raportowanie
        public async Task GenerateReport()
        {
            // Tutaj można dodać kod obsługi generowania raportów
            // Na przykład, wyciągi zakupionych miejsc, błędy w oprogramowaniu itp.

            var purchasedSeatsReport = await GeneratePurchasedSeatsReport();
            var softwareErrorsReport = await GenerateSoftwareErrorsReport();

            // Wypisz raporty
            Console.WriteLine("Raport wyciągu zakupionych miejsc:");
            Console.WriteLine(purchasedSeatsReport);
            Console.WriteLine("------------------------------");

            Console.WriteLine("Raport błędów w oprogramowaniu:");
            Console.WriteLine(softwareErrorsReport);
        }

        private async Task<string> GeneratePurchasedSeatsReport()
        {
            // Tutaj można dodać kod generowania raportu wyciągu zakupionych miejsc
            // Przykład: Pobierz informacje o zarezerwowanych miejscach i przygotuj raport

            var reservedSeatsInfo = await _dbContext.Reservations
                .GroupBy(r => r.Seat)
                .Select(g => new
                {
                    SeatNumber = g.Key,
                    ReservedCount = g.Count()
                })
                .ToListAsync();

            var reportBuilder = new StringBuilder();
            reportBuilder.AppendLine("Raport wyciągu zakupionych miejsc:");
            foreach (var reservedSeat in reservedSeatsInfo)
            {
                reportBuilder.AppendLine($"Miejsce {reservedSeat.SeatNumber}: {reservedSeat.ReservedCount} zakupionych biletów");
            }

            return reportBuilder.ToString();
        }

        private async Task<string> GenerateSoftwareErrorsReport()
        {
            // Tutaj można dodać kod generowania raportu błędów w oprogramowaniu
            // Przykład: Pobierz informacje o błędach zapisanych w bazie danych i przygotuj raport

           // var softwareErrors = await _dbContext.SoftwareErrors.ToListAsync();

            var reportBuilder = new StringBuilder();
            reportBuilder.AppendLine("Raport błędów w oprogramowaniu:");
            //foreach (var error in softwareErrors)
            //{
            //    reportBuilder.AppendLine($"Data i godzina błędu: {error.Timestamp}");
            //    reportBuilder.AppendLine($"Opis błędu: {error.Description}");
            //    reportBuilder.AppendLine("------------------------------");
            //}

            return reportBuilder.ToString();
        }
    }
}
