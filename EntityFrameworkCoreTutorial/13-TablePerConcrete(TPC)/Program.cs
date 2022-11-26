using _13_TablePerConcrete_TPC_.Context;
using _13_TablePerConcrete_TPC_.Entities;

using AppDbContext dbContext = new();

#region Create

Customer newCustomer = new()
{
    Name = "John",
    LastName = "Doe",
    CompanyName = "ABC Holding"
};

dbContext.Customers.Add(newCustomer);
dbContext.SaveChanges();
#endregion

#region Read
var customers = dbContext.Customers.ToList();
foreach (var customer in customers)
{
    Console.WriteLine(customer.Id);
    Console.WriteLine(customer.Name);
    Console.WriteLine(customer.LastName);
    Console.WriteLine(customer.CompanyName);
}
#endregion

#region Delete

var deleteCustomer = dbContext.Customers.Find(0);
dbContext.Customers.Remove(deleteCustomer);
dbContext.SaveChanges();

#endregion

#region Update
var updateCustomer = dbContext.Customers.Find(1);
updateCustomer.Name = "Jack";
dbContext.SaveChanges();
#endregion