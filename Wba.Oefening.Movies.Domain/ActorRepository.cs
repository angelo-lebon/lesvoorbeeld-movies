using System;
using System.Collections.Generic;
using System.Text;

namespace Wba.Oefening.Movies.Domain
{
    public class ActorRepository
    {
        protected static Actor[] Actors = 
        {
            new Actor{FirstName="Brad",SurName="Pitt"},
            new Actor{FirstName="Robert",SurName="De Niro"},
            new Actor{FirstName="Walter",SurName="Capiau"},
            new Actor{FirstName="Angelina",SurName="Jolie"},
            new Actor{FirstName="John",SurName="Travolta"},
            new Actor{FirstName="Samuel",SurName="Jackson"},
            new Actor{FirstName="Bruce",SurName="Willis"},
        };

        public IEnumerable<Actor> GetActors()
        {
            return Actors;
        }
    }
}
