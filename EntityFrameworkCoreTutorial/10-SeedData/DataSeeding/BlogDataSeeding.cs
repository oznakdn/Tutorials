using _10_SeedData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _10_SeedData.DataSeeding;

public class BlogDataSeeding : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.HasData(
            new Blog
            {
                Id = 1,
                Url = "www.myblog.com",
            },
            new Blog
            {
                Id = 2,
                Url = "www.ourblog.com",
            }
        );
    }
}
