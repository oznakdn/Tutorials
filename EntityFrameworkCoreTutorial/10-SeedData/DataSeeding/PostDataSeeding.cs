using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _10_SeedData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _10_SeedData.DataSeeding
{
    public class PostDataSeeding : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(

                new Post
                {
                    Id = 1,
                    BlogId = 1,
                    Title = "This is first title",
                    Content = "This is first content"
                },
                new Post
                {
                    Id = 2,
                    BlogId = 1,
                    Title = "This is second title",
                    Content = "This is second content"
                },

                new Post
                {
                    Id = 3,
                    BlogId = 2,
                    Title = "This is third title",
                    Content = "This is third content"
                },
                new Post
                {
                    Id = 4,
                    BlogId = 2,
                    Title = "This is fourth title",
                    Content = "This is fourth content"
                }

            );
        }
    }
}