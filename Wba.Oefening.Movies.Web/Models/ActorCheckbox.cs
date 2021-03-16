namespace Wba.Oefening.Movies.Web.Models
{
    public class ActorCheckbox
    {
        public string ActorName { get; set; }
        public long ActorId { get; set; }
        public bool IsSelected { get; set; } = false;
    }
}
