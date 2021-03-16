using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wba.Oefening.Movies.Web.Models;

namespace Wba.Oefening.Movies.Web.ViewModels
{
    public class HomeCreateMovieVm
    {
        [Required(ErrorMessage = "Must have title!")]
        public string Title { get; set; }
        public long SelectedDirector { get; set; }
        public List<SelectListItem> Directors { get; set; }
        public List<ActorCheckbox> ActorCheckboxes { get; set; }
    }

}
