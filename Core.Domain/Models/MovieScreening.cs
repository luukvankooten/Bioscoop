using System;
namespace Core.Domain.Models
{
    public class MovieScreening
    {
        public Movie Movie { get; }

        private readonly DateTime dateAndTime;

        private readonly double pricePerSeat;

        public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
        {
            Movie = movie;
            this.dateAndTime = dateAndTime;
            this.pricePerSeat = pricePerSeat;
        }

        public DateTime GetDateTime()
        {
            return dateAndTime;
        }

        public double GetPrice()
        {
            return pricePerSeat;
        }

        public override string ToString()
        {
            return $"dateAndTime: {this.dateAndTime}\tpricePerSeat: {this.pricePerSeat}\nmovie: {Movie}";
        }
    }
}