using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Domain.Models
{
    public class Order
    {
        public int OrderNr { get; }
        public double OrderPrice { get; private set; }
        public bool IsStudentOrder { get; }
        public IList<MovieTicket> MovieTickets { get; }

        public Order(int orderNr, bool isStudentOrder)
        {
            this.OrderNr = orderNr;
            this.OrderPrice = 0d;
            this.IsStudentOrder = isStudentOrder;
            this.MovieTickets = new List<MovieTicket>();
        }

        public void SetOrderPrice(double orderPrice)
        {
            this.OrderPrice = orderPrice;
        }

        public override string ToString()
        {
            string movieTickets = string.Join(Environment.NewLine, MovieTickets.Select(x => "\n" + x.ToString()));
            return $"orderPrice: {OrderPrice}\torderNr: {OrderNr}\tisStudentOrder: {IsStudentOrder}\nmovieTickets: {movieTickets}";
        }
    }
}