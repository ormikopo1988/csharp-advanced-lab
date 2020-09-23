namespace AsyncApiCore.Final.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AppropriateAbove { get; set; }
        public float ImdbRating { get; set; }
    }
}