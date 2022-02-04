using System;
namespace Core.Domain.Models
{
    public class Movie
    {
        private readonly string title;

        public Movie(string title)
        {
            this.title = title;
        }

        public void AddScreening(MovieScreening screening)
        {

        }
    }
}
