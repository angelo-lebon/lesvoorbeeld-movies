using System.Collections.Generic;

namespace Wba.Oefening.Movies.Domain
{
    public class ActorRepository
    {
        protected static Actor[] Actors =
        {
            new Actor{FirstName="Brad",SurName="Pitt", Id = 1},
            new Actor{FirstName="Robert",SurName="De Niro", Id = 2 },
            new Actor{FirstName="Walter",SurName="Capiau", Id = 3},
            new Actor{FirstName="Angelina",SurName="Jolie", Id = 4},
            new Actor{FirstName="John",SurName="Travolta", Id = 5},
            new Actor{FirstName="Samuel",SurName="Jackson", Id = 6},
            new Actor{FirstName="Bruce",SurName="Willis", Id = 7},
        };

        public IEnumerable<Actor> GetActors()
        {
            return Actors;
        }
    }
}
