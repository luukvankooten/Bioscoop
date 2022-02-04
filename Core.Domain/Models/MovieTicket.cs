using System;
namespace Core.Domain.Models
{
    public class MovieTicket
    {
        public MovieScreening MovieScreening { get; }

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


        public bool IsPremiumTicket()
        {
            return isPremium;
        }


        public double GetPrice()
        {
            return 0.0;
        }

        
    }
}
