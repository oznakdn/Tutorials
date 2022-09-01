/* Database First 
   - Yazilacak olan projede veritabani hali hazirda mevcutsa ilgili veritabani ile baglanti kurularak islemler gerceklestirilmektedir.
   - Ornek olarak veritabanimizda bulunan Northwind veri tabanini Database First yaklasimi ile kullanabiliriz.
*/

/* Paketler
   dotnet add package Microsoft.EntityFrameworkCore.Tools
   dotnet add package Microsoft.EntityFrameworkCore.Design
   dotnet add package Microsoft.EntityFrameworkCore.SqlServer
*/

/* Komutlar 
    Detay : https://docs.microsoft.com/tr-tr/ef/core/cli/dotnet
    Package Manager Console    Scaffold-DbContext [Connection String] Microsoft.EntityFrameworkCore.[Provider]
   .Net CLI                    dotnet ef dbcontext scaffold "[Connection String]" Microsoft.EntityFrameworkCore.[Provider]     yada
                               dotnet ef dbcontext scaffold "[Connection String]" Microsoft.EntityFrameworkCore.[Provider] -o Model 

   Path Belirterek;
   Scaffold-DbContext "[Connection String]" Microsoft.EntityFrameworkCore.[Provider] -ContextDir Data -OutputDir Entities
   dotnet ef dbcontext scaffold "[Connection String]" Microsoft.EntityFrameworkCore.[Provider] --context-dir Data --output-dir Entities


   Sadece Belli Tablolarla;
                               dotnet ef dbcontext scaffold "Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;" 
                               Microsoft.EntityFrameworkCore.SqlServer -o Models -t Blogs -t Posts --context-dir Context -c BlogContext --context-namespace New.Namespace

   Degisiklikleri guncellemek icin;
   Scaffold-DbContext "[Connection String]" Microsoft.EntityFrameworkCore.[Provider] -Force
   dotnet ef dbcontext scaffold "[Connection String]" Microsoft.EntityFrameworkCore.[Provider] --force
*/



using _01_DatabaseFirst.Data;

using var context = new NorthwindContext();


#region EntityFramework
var categories = context.Categories.ToList();
foreach (var category in categories)
{
    System.Console.WriteLine(category.CategoryName);
}
#endregion


#region Linq

var result = (from product in context.Products
              join category in context.Categories
              on product.CategoryId equals category.CategoryId
              select new ProductListDto
              {
                  ProductName = product.ProductName,
                  Category = category.CategoryName,
                  UnitInStock = product.UnitsInStock,
                  UnitPrice = product.UnitPrice
              }).ToList();

foreach (ProductListDto item in result)
{
    Console.WriteLine($"{item.ProductName}  {item.Category} {item.UnitInStock} {item.UnitPrice}");
}

public class ProductListDto
{
    public string ProductName { get; set; }
    public string Category { get; set; }
    public decimal? UnitPrice { get; set; }
    public short? UnitInStock { get; set; }

}
#endregion

