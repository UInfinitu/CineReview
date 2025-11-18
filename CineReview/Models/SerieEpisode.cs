namespace CineReview.Models
{
    public class SerieEpisode
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public SerieSeason Season { get; set; }
        public int SeasonId { get; set; }
    }
}
