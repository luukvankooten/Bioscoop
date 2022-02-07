using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Domain.Models
{
    public class Order
    {
        private readonly int orderNr;

        private readonly bool isStudentOrder;

        private IList<MovieTicket> movieTickets;

        public Order(int orderNr, bool isStudentOrder)
        {
            this.orderNr = orderNr;
            this.isStudentOrder = isStudentOrder;
            this.movieTickets = new List<MovieTicket>();
        }

        public int GetOrder()
        {
            return orderNr;
        }

        public void AddSeatReservation(MovieTicket ticket)
        {
            //ONLY Add the price.
            movieTickets.Add(ticket);

            //TODO: In het weekend betaal je als niet-student de volle prijs, tenzij de bestelling uit 6 kaartjes of meer bestaat, dan krijg je 10% groepskorting.

            //TODO: Elk 2e ticket is gratis voor studenten (elke dag van de week) of als het een voorstelling betreft op een doordeweekse dag (ma/di/wo/do) voor iedereen.

            //TODO: Een premium ticket is voor studenten 2,- duurder dan de standaardprijs per stoel van de voorstelling, voor niet-studenten 3,-.
            //  Deze worden in de kortingen verrekend (dus bij een 2e ticket dat gratis is, ook geen extra kosten; bij 10% korting ook 10% van de extra kosten).
        }

        public double CalculatePrice()
        {
            double sumPrice = movieTickets.Aggregate(0d, (sum, movieTicket) => {
                var day = movieTicket.MovieScreening.GetDateTime().DayOfWeek;

                var ticketPrice = movieTicket.GetPrice();

                //Subtract one for students because student discount
                if (isStudentOrder)
                {
                    ticketPrice -= 1d;
                }

                if(new[] { DayOfWeek.Sunday, DayOfWeek.Saturday, DayOfWeek.Friday }.Contains(day))
                {
                    return ticketPrice;
                }

                var index = movieTickets.IndexOf(movieTicket);

                if (isStudentOrder && index % 2 == 0)
                {
                    return 0;
                }

                return ticketPrice;
            });

            if (!this.isStudentOrder && this.movieTickets.Count >= 6)
            {
                DateTime screeningTime = this.movieTickets.First().MovieScreening.GetDateTime();
                if (new[] { DayOfWeek.Saturday, DayOfWeek.Sunday }.Contains(screeningTime.DayOfWeek))
                    sumPrice -= sumPrice * 0.1d;
            }
            return sumPrice;
        }

        public void PerformExport(TicketExportFormat exportFormat)
        {
            if (exportFormat == TicketExportFormat.PLAINTEXT)
            {

            }
            else if (exportFormat == TicketExportFormat.JSON)
            {

            }
        }

        public override string ToString()
        {
            string movieTickets = string.Join(Environment.NewLine, this.movieTickets.Select(x => "\n"+ x.ToString()));
            return $"orderPrice: {this.CalculatePrice()}\torderNr: {this.orderNr}\tisStudentOrder: {this.isStudentOrder}\nmovieTickets: {movieTickets}";
        }
    }
}