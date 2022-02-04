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
