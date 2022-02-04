using System;
using System.Collections.Generic;

namespace Core.Domain.Models
{
    public class Movie
    {
        private readonly string title;


        private ICollection<MovieScreening> movieScreenings;

        public Movie(string title)
        {
            this.title = title;
        }

        public void AddScreening(MovieScreening screening)
        {
            movieScreenings.Add(screening);
        }
    }
}
