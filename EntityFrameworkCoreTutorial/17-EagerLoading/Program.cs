/* Eager Loading
 * Iliskisel tablolari sorgu icerisine parca parca dahil etmeye eager loading denir.
 * Include fonksiyonu eager loading yapilmasini saglayan fonksiyondur.
 * ThenInclude fonksiyonu, Include ile eklenen tablonun iliskili tablolarini sorguya ekleyen fonksiyondur.
 * Filtered Include, belirli verilere gore sorgu olusturmaya yarayan fonksiyondur.

*/

using _17_EagerLoading.Context;
using Microsoft.EntityFrameworkCore;

using AppDbContext dbContext = new();


#region Include
var customers = dbContext.Customers
.Include(c => c.Region)
.Include(c => c.Orders)
.ToList();

foreach (var customer in customers)
{
    Console.WriteLine
    (
        $"ID : {customer.Id} Name : {customer.FirstName} Surname : {customer.LastName} Region : {customer.Region.RegionName}"
    );

    var orders = dbContext.Orders.Where(x => x.CustomerId == customer.Id).ToList();
    foreach (var order in orders)
    {
        Console.WriteLine("ID: " + order.Id);
        Console.WriteLine("Order Date: " + order.OrderDate);

    }
}


#region Join

// var regions = from r in dbContext.Regions
//               join c in dbContext.Customers
//               on r.Id equals c.RegionId
//               select new
//               {
//                   r.RegionName,
//                   c.FirstName,
//                   c.LastName,
//                   c.Salary
//               };

// foreach (var region in regions)
// {
//     Console.WriteLine(region.RegionName);
//     Console.WriteLine(region.FirstName);
//     Console.WriteLine(region.LastName);
//     Console.WriteLine(region.Salary);
// }

#endregion

#endregion

#region ThenInclude

Console.WriteLine("-------------ThenInclude---------------");

var regions = dbContext.Regions.Include(x => x.Customers).ThenInclude(x => x.Orders).ToList();

foreach (var region in regions)
{
    Console.WriteLine(region.RegionName);

    foreach (var customer in region.Customers)
    {
        Console.WriteLine(customer.FirstName);
        Console.WriteLine(customer.LastName);
        Console.WriteLine(customer.Salary);

        foreach (var order in customer.Orders)
        {
            Console.WriteLine(order.Id);
            Console.WriteLine(order.OrderDate);

        }


    }
}

#endregion

#region Filtered Include
var regionsList = dbContext.Regions.Include(r => r.Customers.Where(x => x.FirstName.Contains('a'))).ToList();
#endregion
