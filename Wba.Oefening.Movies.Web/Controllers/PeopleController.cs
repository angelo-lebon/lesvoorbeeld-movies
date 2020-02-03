using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Movies.Domain;
using Wba.Oefening.Movies.Web.ViewModels;

namespace Wba.Oefening.Movies.Web.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ActorRepository actorRepository;
        private readonly DirectorRepository directorRepository;

        public PeopleController()
        {
            actorRepository = new ActorRepository();
            directorRepository = new DirectorRepository();
        }

        [Route("directors")]
        public IActionResult ShowDirectors()
        {
            ViewBag.Title = "Directors";

            //get data
            var directors = directorRepository.GetDirectors();

            //populate view model
            var viewModel = new PeopleShowDirectorsVM();
            viewModel.DirectorNames = directors.Select(d => $"{d.SurName}, {d.FirstName}");

            //return view model
            return View(viewModel);
        }

        [Route("actors")]
        public IActionResult ShowActors()
        {
            ViewBag.Title = "Actors";

            //get data
            var actors = actorRepository.GetActors();

            //populate view model
            var viewModel = new PeopleShowActorsVM();
            viewModel.ActorNames = actors.Select(a => $"{a.SurName}, {a.FirstName}");

            //return view model
            return View(viewModel);
        }
    }
}