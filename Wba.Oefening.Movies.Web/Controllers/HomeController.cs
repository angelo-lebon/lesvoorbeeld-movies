using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            foreach(var movie in movieRepository.GetMovies())
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
