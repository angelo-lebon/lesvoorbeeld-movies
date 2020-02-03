using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wba.Oefening.Movies.Domain
{
    public class GenreRepository
    {
        //Returns all available Genres
        public IEnumerable<Genre> GetGenres()
        {
            return Enum.GetValues(typeof(Genre)).Cast<Genre>();
        }
    }
}
