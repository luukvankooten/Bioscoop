using Core.Domain.Behaviour;
using Core.Domain.Models;
using Core.DomainServices;
using System;
using System.Linq;

namespace Main.Infrastructure.Calculation
{
    public class OrderPrice : IPrice
    {
        public double Calculate<T>(Calculable<T> entity)
        {
            double sumPrice = -1;
            Order order = entity as Order;
            sumPrice = order.MovieTickets.Aggregate(0d, (sum, movieTicket) => {
                var day = movieTicket.MovieScreening.GetDateTime().DayOfWeek;

                var ticketPrice = movieTicket.GetPrice();

                //Subtract one for students because student discount
                if (order.IsStudentOrder)
                {
                    ticketPrice -= 1d;
                }

                if (new[] { DayOfWeek.Sunday, DayOfWeek.Saturday, DayOfWeek.Friday }.Contains(day))
                {
                    return ticketPrice;
                }

                var index = order.MovieTickets.IndexOf(movieTicket);

                if (order.IsStudentOrder && index % 2 == 0)
                {
                    return 0;
                }

                return ticketPrice;
            });

            if (!order.IsStudentOrder && order.MovieTickets.Count >= 6)
            {
                DateTime screeningTime = order.MovieTickets.First().MovieScreening.GetDateTime();
                if (new[] { DayOfWeek.Saturday, DayOfWeek.Sunday }.Contains(screeningTime.DayOfWeek))
                    sumPrice -= sumPrice * 0.1d;
            }
            return sumPrice;
        }
    }
}
