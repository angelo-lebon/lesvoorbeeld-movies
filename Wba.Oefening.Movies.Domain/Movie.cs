using System;
using System.Collections.Generic;

namespace Wba.Oefening.Movies.Domain
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public Genre Genre { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
        public IEnumerable<Director> Directors { get; set; }
    }
}
