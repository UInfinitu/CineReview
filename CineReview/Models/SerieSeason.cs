namespace CineReview.Models
{
    public class SerieSeason
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<SerieEpisode> Episodes { get; set; }
        public Serie Serie { get; set; }
        public int SerieId { get; set; }
    }
}
