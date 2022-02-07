using System;
using Core.Domain.Models;

namespace Bioscoop
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var movie = new Movie("Johnny Wick chapter 3.");

            var movieScreen = new MovieScreening(movie, new DateTime(2020, 02, 01, 20, 0, 0), 13.0);
            var order = new Order(0, true);

            var ticket1 = new MovieTicket(movieScreen, 1, 27, true);
            var ticket2 = new MovieTicket(movieScreen, 1, 27, true);

            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);

            order.PerformExport(TicketExportFormat.JSON);
            order.PerformExport(TicketExportFormat.PLAINTEXT);

            Console.WriteLine("Press a key to exit...");
            Console.ReadKey();
        }
    }
}
