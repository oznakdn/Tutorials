using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _10_SeedData.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public Blog Blog { get; set; }
    }
}