using Linq_Keywords.Data;

using var context = new AppDbContext();


var productsWithCategory = (from p in context.Products
                           join c in context.Categories
                           on p.CategoryId equals c.Id
                           select new 
                           {
                                ID = p.Id,
                                Brand = p.Brand,
                                Price = p.Price,
                                Category = c.CategoryTitle
                           }).ToList();

Console.WriteLine("-----------------------------------------------------------------------");
Console.WriteLine("\t\t\tProducts with Category\t\t\t");
Console.WriteLine("-----------------------------------------------------------------------");
Console.WriteLine("\t ID\t\t Brand\t\t Price\t\t Category\t\t");
Console.WriteLine("-----------------------------------------------------------------------");

foreach (var item in productsWithCategory)
{
    Console.Write($"\t  {item.ID}\t-----\t{item.Brand}\t-----\t{item.Price}\t-----\t{item.Category}\t\t\n");
}


var productsPrice = (from p in context.Products
                    orderby p.Brand where(p.Price>=20000)
                    select new 
                    {
                        ID = p.Id,
                        Brand = p.Brand,
                        Price = p.Price
                    }).ToList();

Console.WriteLine("-----------------------------------------------------------------------");
Console.WriteLine("\t\t\tProducts Price>=20.000\t\t\t");
Console.WriteLine("-----------------------------------------------------------------------");
Console.WriteLine("\t ID\t\t Brand\t\t Price\t\t");
Console.WriteLine("-----------------------------------------------------------------------");

foreach (var item in productsPrice)
{
    Console.Write($"\t  {item.ID}\t-----\t{item.Brand}\t-----\t{item.Price}\t\t\n");
}



var resul = (from p in context.Products
             join c in context.Categories
             on p.CategoryId equals c.Id
             where(p.Category.CategoryTitle.Contains("P"))
             orderby p.Brand ascending
             select new 
             {
                    ID = p.Id,
                    Brand = p.Brand,
                    Price = p.Price,
                    Category = c.CategoryTitle
             }).ToList();


Console.WriteLine("-----------------------------------------------------------------------");
Console.WriteLine("\t\t\tProducts\t\t\t");
Console.WriteLine("-----------------------------------------------------------------------");
Console.WriteLine("\t ID\t\t Brand\t\t Price\t\t Category\t\t");
Console.WriteLine("-----------------------------------------------------------------------");

foreach (var item in resul)
{
    Console.Write($"\t  {item.ID}\t-----\t{item.Brand}\t-----\t{item.Price}\t-----\t{item.Category}\t\t\n");
}
