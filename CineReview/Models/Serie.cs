namespace CineReview.Models
{
    public class Serie : Media
    {
        public List<SerieSeason> Seasons { get; set; }
    }
}
