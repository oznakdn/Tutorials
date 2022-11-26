namespace _14_Constraints.Entities
{
    public class Blog
    {

        public Blog()
        {
            Posts = new HashSet<Post>();
        }
        public int Id { get; set; }
        public string BlogName { get; set; }
        public string Url { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}