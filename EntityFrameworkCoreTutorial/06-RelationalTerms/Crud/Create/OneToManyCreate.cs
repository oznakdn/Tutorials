using _06_RelationalTerms.Data;
using _06_RelationalTerms.Entities;

namespace _06_RelationalTerms.Crud.Create
{
    public class OneToManyCreate
    {

        // Dependent Entity Uzerinden Principal entitiy verisi ekleme
        public void AddEmployeeWithDepartment(Employee employee)
        {
            using var context = new AppDbContext();
            context.Employees.Add(employee);
            //context.SaveChanges();
        }


        // Principal Entity Uzerinden Dependent entitiy verisi ekleme
        public void AddDepartmentWithEmployess(Department department)
        {
            using var context = new AppDbContext();
            context.Departments.Add(department);
            //context.SaveChanges();
            
        }

        // ForeignKey uzerinden veri ekleme
        public void AddEmployee(Employee employee, int departmentId)
        {
            employee.DepartmentId = departmentId;
            using var context = new AppDbContext();
            context.Employees.Add(employee);
            //context.SaveChanges();
        }
    }
}