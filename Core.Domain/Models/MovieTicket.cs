using System;
namespace Core.Domain.Models
{
    public class MovieTicket
    {
        private readonly MovieScreening movieScreening;

        private readonly int rowNr;

        private readonly int seatNr;

        private readonly bool isPremium;

        public MovieTicket(MovieScreening movieScreening, int rowNr, int seatNr, bool isPremium)
        {
            this.movieScreening = movieScreening;
            this.rowNr = rowNr;
            this.seatNr = seatNr;
            this.isPremium = isPremium;
        }
    }
}
