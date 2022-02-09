using Core.DomainServices;
using System;
using System.Linq;

namespace Core.Domain.Models.Infrastructure
{
    public class OrderHandler
    {
        private ICalculateTo _calculateBehaviour;
        private IExportTo _exportBehaviour;
        private readonly Order _order;

        public OrderHandler(Order order)
        {
            _order = order;
        }

        public void AddSeatReservation(MovieTicket ticket)
        {
            //ONLY Add the price.
            _order.MovieTickets.Add(ticket);

            //TODO: In het weekend betaal je als niet-student de volle prijs, tenzij de bestelling uit 6 kaartjes of meer bestaat, dan krijg je 10% groepskorting.

            //TODO: Elk 2e ticket is gratis voor studenten (elke dag van de week) of als het een voorstelling betreft op een doordeweekse dag (ma/di/wo/do) voor iedereen.

            //TODO: Een premium ticket is voor studenten 2,- duurder dan de standaardprijs per stoel van de voorstelling, voor niet-studenten 3,-.
            //  Deze worden in de kortingen verrekend (dus bij een 2e ticket dat gratis is, ook geen extra kosten; bij 10% korting ook 10% van de extra kosten).
        }

        public double PerformCalculate()
        {
            _order.SetOrderPrice(_calculateBehaviour.Calculate(_order));
            return _order.OrderPrice;
        }

        public bool PerformExport()
        {
            return _exportBehaviour.Export(_order);
        }

        public void SetExportBehaviour(IExportTo exportBehaviour)
        {
            _exportBehaviour = exportBehaviour;
        }

        public void SetCalculateBehaviour(ICalculateTo calculateBehaviour)
        {
            _calculateBehaviour = calculateBehaviour;
        }
    }
}