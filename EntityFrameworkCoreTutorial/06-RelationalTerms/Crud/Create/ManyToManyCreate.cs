using System.Collections.Generic;
using _06_RelationalTerms.Data;
using _06_RelationalTerms.Entities;

namespace _06_RelationalTerms.Crud.Create
{
    public class ManyToManyCreate
    {
        // Default convertion ile tasarlanmasi durumunda

        public void AddNewEmployeeWithProjects(Employee employee)
        {
            using var context = new AppDbContext();
            context.Employees.Add(employee);
            //context.SaveChanges();


        }


        // Var ona bir projeye  var olan bir personeli eklemek 
        public void AddProjectToEmployee(int employeeId, int projectId)
        {
            using var context = new AppDbContext();
            var employee = context.Employees.SingleOrDefault(x => x.Id == employeeId);
            var project = context.Projects.SingleOrDefault(x => x.Id == projectId);
            project.Employees.Add(employee);
            context.SaveChanges();
        }

        // Var olan bir projeye var olan birden fazla personel ekleme
        public void AddEmployessToProject(int projectId, List<Employee> employees)
        {
            using var context = new AppDbContext();
            var project = context.Projects.SingleOrDefault(x => x.Id == projectId);
            foreach (var employee in employees)
            {
                project.Employees.Add(employee);
            }
            context.SaveChanges();
        }

        // Fluent Api ile tasarlanmasi durumunda

        public void AddProjectEmployeeWithFluentApi(int projectId)
        {
            using var context = new AppDbContext();
            var project = context.Projects.SingleOrDefault(x => x.Id == projectId);
            context.Projects.Add(project);
            context.SaveChanges();
        }
    }
}