using System;
namespace Core.Domain.Models
{
    public class Order
    {
        private readonly int orderNr;

        private readonly bool isStudentOrder;

        public Order(int orderNr, bool isStudentOrder)
        {
            this.orderNr = orderNr;
            this.isStudentOrder = isStudentOrder;
        }
    }
}
