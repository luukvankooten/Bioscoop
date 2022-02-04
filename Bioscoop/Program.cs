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

            var ticket = new MovieTicket(movieScreen, 1, 27, true);

            order.AddSeatReservation(ticket);



        }
    }
}
