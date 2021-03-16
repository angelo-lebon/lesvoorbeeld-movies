using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Wba.Oefening.Movies.Domain;
using Wba.Oefening.Movies.Web.Models;
using Wba.Oefening.Movies.Web.ViewModels;

namespace Wba.Oefening.Movies.Web.Controllers
{
    public class HomeController : Controller
    {
        //declare the repositories
        private readonly MovieRepository movieRepository;
        private readonly ActorRepository actorRepository;
        private readonly DirectorRepository directorRepository;

        public HomeController()
        {
            movieRepository = new MovieRepository();
            actorRepository = new ActorRepository();
            directorRepository = new DirectorRepository();
        }

        public IActionResult Index()
        {
            //declaratie ViewModel
            var viewModel = new HomeIndexVm();
            //fill the model
            foreach (var movie in movieRepository.GetMovies())
            {
                viewModel.Movies.Add
                (
                    new HomeShowMovieVM
                    {
                        Movie = movie,
                        ShowBackButton = false
                    }
                );

            }
            //pass the model to the view
            return View(viewModel);
        }

        [Route("movies/{movieId}")]
        public IActionResult ShowMovie(Guid movieId)
        {
            //create the model
            var viewModel = new HomeShowMovieVM();
            //fill the model
            //set BackUrl
            viewModel.Movie = movieRepository.GetMovies().FirstOrDefault(m => m.Id == movieId);
            viewModel.ShowBackButton = true;

            //pass the model
            return View(viewModel);
        }

        [HttpGet]
        [Route("movies/create")]
        public IActionResult AddMovie()
        {
            //create the model
            var viewModel = new HomeCreateMovieVm();
            //fill the model
            ActorRepository actorRepository = new ActorRepository();
            viewModel.ActorCheckboxes = actorRepository.GetActors().Select(actor =>
            {
                ActorCheckbox checkbox = new ActorCheckbox();
                checkbox.ActorName = $"{actor.FirstName} {actor.SurName}";
                checkbox.ActorId = actor.Id;
                return checkbox;
            }).ToList();
            viewModel.Directors = new List<SelectListItem>
                {
                new SelectListItem{Value="1",Text="Spielberg" },
                new SelectListItem{Value="2", Text="Lucas" },
                new SelectListItem{Value="3",Text="Scorsese" },
                new SelectListItem{Value="4",Text="Tarantino" }
            };

            //pass the model
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [Route("movies/created")]
        public IActionResult CreatedMovieOverview(HomeCreateMovieVm vm)
        {
            ActorRepository actorRepo = new ActorRepository();
            DirectorRepository directorRepo = new DirectorRepository();
            HomeShowMovieVM vmToShow = new HomeShowMovieVM();
            Movie createdMovie = new Movie();
            createdMovie.Actors = vm.ActorCheckboxes.Where(checkbox => checkbox.IsSelected)
                .Select(checkbox =>
                {
                    return actorRepo.GetActors().FirstOrDefault(a => checkbox.ActorId == a.Id);
                }).ToList();
            createdMovie.Title = vm.Title;
            createdMovie.Directors = new List<Director>() {
                directorRepository.GetDirectors().FirstOrDefault(d => d.Id == vm.SelectedDirector)
            };
            vmToShow.Movie = createdMovie;
            return View(vmToShow);
        }
    }
}
