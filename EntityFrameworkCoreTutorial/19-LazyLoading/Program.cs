/* Lazy Loading 
 * Iliskisel tablolari temsil eden navigation property'ler uzerinde islem yapmak istedigimiz anda sorgular arka planda olusturulup calistirilir.
*/


using _19_LazyLoading.Context;

using AppDbContext dbContext = new();

var customer = dbContext.Customers.FirstOrDefault(c => c.Id == 2);

#region Proxy ile
// Microsoft.EntityFrameworkCore.Proxies nuget paketi yuklenmeli,
// Proxy uzerinden lazy loading yapabilmek icin navigation property'ler virtual olarak isaretlenmeli,
// Context sinifinda  optionsBuilder.UseLazyLoadingProxies(); tanimlamasi yapilmalidir.

Console.WriteLine(customer.Region.RegionName);

#endregion

#region Proxy olmadan
// Microsoft.EntityFrameworkCore.Abstractions nuget paketi yuklenmeli,
// Entity'lere ILazyLoading interface'ini parametre olarak alan bir contructor olustumak gerekir,
// lazy loading yapabilmek icin navigation property'ler virtual olarak isaretlemeye gerek yoktur.

var region = dbContext.Regions.FirstOrDefault(r => r.Id == 2);
Console.WriteLine(region.Customers.FirstOrDefault());

#endregion

