
using _21_SqlQueries.Context;
using Microsoft.EntityFrameworkCore;

/*
 * Sorgular LINQ ile ifade edilemiyorsa
 * LINQ ile elde edilen sorgudan daha optimize bir sorgu elde edilmek isteniyorsa ve EF Core uzerinden execute etmek isteniyorsa kullanilir.
*/

using AppDbContext dbContext = new();

#region FromSqlInterpolated
var persons = dbContext.Person.FromSqlInterpolated($"SELECT * FROM Person").ToList();

#endregion

#region FromSql (EF Core 7.0)
//var persons2 = dbContext.Person.FromSql($"SELECT * FROM Person").ToList();

#endregion

