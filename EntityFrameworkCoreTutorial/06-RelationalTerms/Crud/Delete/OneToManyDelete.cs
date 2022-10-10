using _06_RelationalTerms.Data;
using Microsoft.EntityFrameworkCore;

namespace _06_RelationalTerms.Crud.Delete
{
    public class OneToManyDelete
    {
        public void DeleteDepartmentAllEmployees(int departmentId)
        {
            using var context = new AppDbContext();
            var department = context.Departments.Include(dep => dep.Employees).SingleOrDefault(dep => dep.Id == departmentId);
            context.Employees.RemoveRange(department.Employees);
            context.SaveChanges();
        }

        public void DeleteDepartmentOneEmployee(int departmentId, int employeeId)
        {
            using var context = new AppDbContext();
            var department = context.Departments.Include(dep => dep.Employees).SingleOrDefault(dep => dep.Id == departmentId);
            context.Employees.Remove(department.Employees.SingleOrDefault(x => x.Id == employeeId));
            context.SaveChanges();
        }
    }
}