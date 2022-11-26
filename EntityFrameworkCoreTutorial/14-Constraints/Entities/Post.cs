namespace _14_Constraints.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string BlogUrl { get; set; }

        public Blog Blog { get; set; }

    }
}