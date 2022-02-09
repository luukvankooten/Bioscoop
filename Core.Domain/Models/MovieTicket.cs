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
            MovieScreening = movieScreening;
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
            var price = MovieScreening.GetPrice();

            if(IsPremiumTicket())
            {
                price += 3d;
            }

            return price;
        }

        public override string ToString()
        {
            return $"rowNr: {this.rowNr}\tseatNr: {this.seatNr}\tisPremium: {this.isPremium}\nmovieScreening: {MovieScreening}";
        }
    }
}