using _06_RelationalTerms.Data;
using Microsoft.EntityFrameworkCore;

namespace _06_RelationalTerms.Crud.Delete
{
    public class ManyToManyDelete
    {
        public void DeleteEmployeeProject(int employeeId, int projectId)
        {
            using var context = new AppDbContext();
            var employee = context.Employees.Include(emp=>emp.Projects).SingleOrDefault(emp=>emp.Id == employeeId);
            var deleteProject =  employee.Projects.SingleOrDefault(proj=>proj.Id == projectId);
            // context.Projects.Remove(deleteProject);  ====> Yazari siler
            employee.Projects.Remove(deleteProject); // Iliskisini koparir (EmployeeProject tablosundaki iliskisi siler)
            context.SaveChanges();

        }
    }

}