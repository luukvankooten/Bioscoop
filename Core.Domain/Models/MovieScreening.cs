using System;
namespace Core.Domain.Models
{
    public class MovieScreening
    {
        private readonly Movie movie;

        private readonly DateTime dateAndTime;

        private readonly double pricePerSeat;

        public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
        {
            this.movie = movie;
            this.dateAndTime = dateAndTime;
            this.pricePerSeat = pricePerSeat;
        }
    }
}
