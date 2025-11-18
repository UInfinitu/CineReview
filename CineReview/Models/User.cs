namespace CineReview.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Media> FavoriteList { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
