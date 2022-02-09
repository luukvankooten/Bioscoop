using System;
using Core.Domain.Models;
using Core.Domain.Models.Infrastructure;
using Main.Infrastructure.Calculation;
using Main.Infrastructure.Export;

namespace Bioscoop
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var movieScreen = new MovieScreening(new Movie("Johnny Wick chapter 3."), new DateTime(2020, 02, 01, 20, 0, 0), 13.0);
            OrderHandler order = new OrderHandler(new Order(0, true));

            MovieTicket ticket1 = new MovieTicket(movieScreen, 1, 27, true);
            MovieTicket ticket2 = new MovieTicket(movieScreen, 1, 27, true);
            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);

            order.SetCalculateBehaviour(new CalculateOrderPrice());
            order.PerformCalculate();

            order.SetExportBehaviour(new ExportToJSON());
            order.PerformExport();
            order.SetExportBehaviour(new ExportToTXT());
            order.PerformExport();

            Console.WriteLine("Press a key to exit...");
            Console.ReadKey();
        }
    }
}
