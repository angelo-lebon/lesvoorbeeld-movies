using System;
using System.Collections.Generic;
using System.Text;

namespace Wba.Oefening.Movies.Domain
{
    public class DirectorRepository
    {
        protected static List<Director> Directors = new List<Director>
        {
            new Director{FirstName="Steven",SurName="Spielberg" },
            new Director{FirstName="George", SurName="Lucas" },
            new Director{FirstName="Martin",SurName="Scorsese" },
            new Director{FirstName="Quentin",SurName="Tarantino" }
        };
        

        public IEnumerable<Director> GetDirectors()
        {
            return Directors;
        }
    }


}
