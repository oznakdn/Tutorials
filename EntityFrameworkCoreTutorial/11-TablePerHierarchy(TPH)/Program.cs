
using _11_TablePerHierarchy_TPH_.Context;
using _11_TablePerHierarchy_TPH_.Entities;




using AppDbContext dbContext = new();

Employee newEmployee = new()
{
    Name = "Ahmet",
    LastName = "Kartal",
    Department = "IT"
};

Customer newCustomer = new()
{
    Name = "Burcu",
    LastName = "Aslan",
    CompanyName = "ABC Holding"
};

Technician newTechnician = new()
{
    Name = "Cemil",
    LastName = "Sahin",
    Department = "Production",
    Branch = "Electric"
};




#region Create

dbContext.Employees.Add(newEmployee);
dbContext.Customers.Add(newCustomer);
dbContext.Technicians.Add(newTechnician);
dbContext.SaveChanges();

#endregion

#region Delete

Customer customer = dbContext.Customers.Find(1);
dbContext.Customers.Remove(customer);
dbContext.SaveChanges();

#endregion

#region Update

Employee employee = dbContext.Employees.Find(5);
employee.Department = "HR";
dbContext.SaveChanges();

#endregion

#region Read

List<Technician> technicians = dbContext.Technicians.ToList();
foreach (var technician in technicians)
{
    Console.Write($"{technician.Name} {technician.LastName} {technician.Department} {technician.Branch}");
}

#endregion

