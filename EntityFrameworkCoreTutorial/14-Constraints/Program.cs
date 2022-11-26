using _14_Constraints.Context;
using _14_Constraints.Entities;

using AppDbContext dbContext = new();

Console.WriteLine("Create a New Blog");
string? blogName = Console.ReadLine();
string? url = Console.ReadLine();

Blog newBlog = new()
{
    BlogName = blogName,
    Url = url
};

if (dbContext.Blogs.Where(b => b.BlogName == blogName).Any())
{
    Console.Write("Blog name is exists");
}
else
{
    dbContext.Blogs.Add(newBlog);
    dbContext.SaveChanges();
    Console.Write("Blog was created.");

}


