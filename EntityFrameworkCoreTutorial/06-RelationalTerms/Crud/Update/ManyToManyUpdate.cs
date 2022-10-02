using _06_RelationalTerms.Data;
using _06_RelationalTerms.Entities;
using Microsoft.EntityFrameworkCore;

namespace _06_RelationalTerms.Crud.Update
{
    public class ManyToManyUpdate
    {
        // Project and Employee has many to many relationship 
        public void EmployeeProjectUpdate(int employeeId, Project updateProject)
        {
            using var context = new AppDbContext();
            updateProject.Id = 2;
            var employee = context.Employees.Where(e => e.Id == employeeId).Include(e => e.Projects).FirstOrDefault();

            var project = employee.Projects.FirstOrDefault(p => p.Id == updateProject.Id);
            project.Title = updateProject.Title;
            project.StartDate = updateProject.StartDate;
            project.EndDate = updateProject.EndDate;
            context.SaveChanges();

        }
    }
}