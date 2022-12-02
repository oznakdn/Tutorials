/* Explicit Loading
 * Uretilen sorguda iliskisel verilerin eklenip eklenmeyecegi daha sonra sartlara bagli olarak belirlenecekse explicit loading kullanilir
 * Veriler ihtiyaca istinaden eklenip sorgulanmaktadir
*/

using _18_ExplicitLoading.Context;
using _18_ExplicitLoading.Entities;

using AppDbContext dbContext = new();


#region Reference

// Olusturan sorguya eklenecek olan tablonun navigation property'si tekil ise (collection degil ise) iliskili tablo Reference fonksiyonu ile sorguya dahil edilir.

Customer customer1 = dbContext.Customers.FirstOrDefault(c => c.Id == 1);
dbContext.Entry(customer1).Reference(c => c.Region).Load();

Console.WriteLine($"{customer1.FirstName} {customer1.LastName} {customer1.Salary} {customer1.Region.RegionName}");

#endregion

#region Collection

// Olusturan sorguya eklenecek olan tablonun navigation property'si cogul ise (collection ise) iliskili tablo Reference fonksiyonu ile sorguya dahil edilir.
Customer customer2 = dbContext.Customers.FirstOrDefault(c => c.Id == 1);
dbContext.Entry(customer2).Collection(c => c.Orders).Load();

Console.WriteLine($"{customer2.FirstName} {customer2.LastName} {customer2.Salary}");
foreach (var item in customer2.Orders)
{
    Console.WriteLine($"{item.CustomerId} {item.Id} {item.OrderDate}");
}

#region Aggregate

Customer customer3 = dbContext.Customers.FirstOrDefault(c => c.Id == 1);

dbContext.Entry(customer3).Collection(c => c.Orders).Query().Count();

#endregion

#region Filter

Customer customer4 = dbContext.Customers.FirstOrDefault(c => c.Id == 1);

dbContext.Entry(customer4).Collection(c => c.Orders).Query().Where(c => c.OrderDate == DateTime.Now);


#endregion

#endregion

