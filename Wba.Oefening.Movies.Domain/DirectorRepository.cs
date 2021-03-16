using System.Collections.Generic;

namespace Wba.Oefening.Movies.Domain
{
    public class DirectorRepository
    {
        protected static List<Director> Directors = new List<Director>
        {
            new Director{FirstName="Steven",SurName="Spielberg", Id = 1 },
            new Director{FirstName="George", SurName="Lucas", Id = 2 },
            new Director{FirstName="Martin",SurName="Scorsese", Id =3 },
            new Director{FirstName="Quentin",SurName="Tarantino", Id = 4 }
        };


        public IEnumerable<Director> GetDirectors()
        {
            return Directors;
        }
    }


}
