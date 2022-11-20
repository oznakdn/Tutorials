using _10_SeedData.Context;
using Microsoft.EntityFrameworkCore;

using var dbContext = new AppDbContext();
var blogPosts = dbContext.Blogs.Where(b => b.Id == 1).Include(b => b.Posts).ToList();


foreach (var item in blogPosts)
{
    Console.WriteLine(item.Id);
    Console.Write(item.Url);
    foreach (var post in item.Posts)
    {
        Console.WriteLine(post.Id);
        Console.Write($"Title : {post.Title} Content : {post.Content}");

    }
}
