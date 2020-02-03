using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Wba.Oefening.Movies.Domain
{
    public class MovieRepository
    {
        protected readonly DirectorRepository directorRepository;
        protected readonly ActorRepository actorRepository;
        protected Movie[] movies;

        public MovieRepository()
        {
            directorRepository = new DirectorRepository();
            actorRepository = new ActorRepository();
            InitMovies();
        }
        protected void InitMovies()
        {
            var AllActors = actorRepository.GetActors();
            var AllDirectors = directorRepository.GetDirectors();

            //fill the movie array here
            movies = new[]
            {
                new Movie{
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Title ="It",
                    Directors = AllDirectors.Where(d => d.SurName == "Spielberg"),
                    Actors = AllActors.Where(   a => a.SurName == "De Niro" ||
                                                a.SurName == "Pitt"),
                    Genre = Genre.Horror,
                    Image = "it.jpg"
                },
                new Movie{
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    Title ="Pulp Fiction",
                    Directors = AllDirectors.Where(d => d.SurName == "Tarantino"),
                    Actors = AllActors.Where(   a => a.SurName == "Willis" ||
                                                a.SurName == "Travolta"),
                    Genre = Genre.Drama,
                    Image = "pulpfiction.jpg"
                },
                new Movie{
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    Title ="Get Shorty",
                    Directors = AllDirectors.Where(d => d.SurName == "Scorsese"),
                    Actors = AllActors.Where(   a => a.SurName == "Pitt" ||
                                                a.SurName == "Travolta"),
                    Genre = Genre.Comedy,
                    Image = "getshorty.jpg"
                },
                new Movie{
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                    Title ="Star Wars",
                    Directors = AllDirectors.Where(d => d.SurName == "Spielberg"),
                    Actors = AllActors.Where(   a => a.SurName == "Jolie" ||
                                                a.SurName == "Capiau"),
                    Genre = Genre.Fantasy,
                    Image = "starwars.jpg"
                }
            };
        }

        public IEnumerable<Movie> GetMovies()
        {
            return movies;
        }
    }
}
