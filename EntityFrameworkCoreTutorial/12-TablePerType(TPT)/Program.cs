
using _12_TablePerType_TPT_.Context;
using _12_TablePerType_TPT_.Entities;

using AppDbContext dbContext = new();

#region Create

Technician newTechnician = new()
{
    Name = "John",
    LastName = "Doe",
    Department = "IT",
    Branch = "Electric"
};

dbContext.Technicians.Add(newTechnician);
dbContext.SaveChanges();
#endregion

#region Read
var technicians = dbContext.Technicians.ToList();
foreach (var technician in technicians)
{
    Console.Write(technician.Name + "\n");
    Console.Write(technician.LastName + "\n");
    Console.Write(technician.Department + "\n");
    Console.Write(technician.Branch + "\n");

}
#endregion

#region Delete

var existTechnician = dbContext.Technicians.Find(3);
dbContext.Technicians.Remove(existTechnician);
dbContext.SaveChanges();

#endregion

#region Update
var oneTechnicioan = dbContext.Technicians.Find(5);
oneTechnicioan.Name = "Jack";
dbContext.SaveChanges();
#endregion