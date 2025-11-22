namespace CineReview.DTOs
{
    public class MovieCreateDto
    {
        public string Name { get; set; }
        public string Synopsis { get; set; }
        public string Director { get; set; }
        public int ReleaseYear { get; set; }
        public int Duration { get; set; }
    }
}

