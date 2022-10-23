using _09_EntityConfiguration.Context;
using _09_EntityConfiguration.Entities;

using var context = new AppDbContext();
Person person = new()
{
    Id2 = 1,
    FirstName = "Ahmet",
    LastName = "Kartal",
    IdentityNumber = 12334235446,
    WorkingYear = 10,
    Salary = 5000,
    Department = new Department { DepartmentName = "IT" }
};
await context.Persons.AddAsync(person);
await context.SaveChangesAsync();
Console.WriteLine("Person is created.");

