using _06_RelationalTerms.Data;
using Microsoft.EntityFrameworkCore;

namespace _06_RelationalTerms.Crud.Delete
{
    public class OneToOneDelete
    {
        public void DeleteContactByEmployee(int employeeId)
        {
             using var context = new AppDbContext();
             var deletedContact = context.Contacts.SingleOrDefault(x=>x.EmployeeId == employeeId);
             context.Contacts.Remove(deletedContact);
             //context.SaveChanges();
        }

        public void DeleteContaxtWithEmployee(int employeeId)
        {
             using var context = new AppDbContext();
             var employee = context.Employees.Include(emp=>emp.Contact).SingleOrDefault(emp=>emp.Id == employeeId);
             context.Contacts.Remove(employee.Contact);
             //context.SaveChanges();
        }
    }
}