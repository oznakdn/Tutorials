using _06_RelationalTerms.Data;
using _06_RelationalTerms.Entities;
using Microsoft.EntityFrameworkCore;

namespace _06_RelationalTerms.Crud.Update
{
    public class OneToManyUpdate
    {

        public List<Department>GetDepartments()
        {
            using var context = new AppDbContext();
            return context.Departments.ToList();
        }
        public void EmployeeDepartmentUpdate(int employeeId, int departmentId)
        {
            using var context = new AppDbContext();
            var employee =context.Employees.Single(employee => employee.Id == employeeId);
            employee.DepartmentId = departmentId;
            context.SaveChanges();
        }

        public void DepartmentEmployeeUpdate(int departmentId, Employee updateEmployee)
        {
            
            using var context = new AppDbContext();
            var department = context.Departments.Include(d=>d.Employees).FirstOrDefault(d=>d.Id == departmentId);
            var employee =  department.Employees.FirstOrDefault(e=>e.Id == updateEmployee.Id);
            employee.FullName = employee.FullName;
            employee.Gender = employee.Gender;
            
            context.Departments.Update(department);
            context.SaveChanges();

        }
    }
}