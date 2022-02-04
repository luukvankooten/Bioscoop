using System;
using System.Collections.Generic;

namespace Core.Domain.Models
{
    public class Order
    {
        private readonly int orderNr;

        private readonly bool isStudentOrder;

        private ICollection<MovieScreening> movieTickets;

        public Order(int orderNr, bool isStudentOrder)
        {
            this.orderNr = orderNr;
            this.isStudentOrder = isStudentOrder;
        }

        public int GetOrder()
        {
            return orderNr;
        }

        public void AddSeatReservation(MovieTicket ticket)
        {
            var dateTime = ticket.MovieScreening.GetDateTime();


            //TODO: In het weekend betaal je als niet-student de volle prijs, tenzij de bestelling uit 6 kaartjes of meer bestaat, dan krijg je 10% groepskorting.

            //TODO: Elk 2e ticket is gratis voor studenten (elke dag van de week) of als het een voorstelling betreft op een doordeweekse dag (ma/di/wo/do) voor iedereen.

            //TODO: Een premium ticket is voor studenten 2,- duurder dan de standaardprijs per stoel van de voorstelling, voor niet-studenten 3,-.
            //  Deze worden in de kortingen verrekend (dus bij een 2e ticket dat gratis is, ook geen extra kosten; bij 10% korting ook 10% van de extra kosten).
        }

        public double CalculatePrice()
        {
            return 0;
        }

        public void Export(TicketExportFormat exportFormat)
        {

        }


    }
}
