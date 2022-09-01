using _06_RelationalTerms.Data;
using _06_RelationalTerms.Entities;
using Microsoft.EntityFrameworkCore;

namespace _06_RelationalTerms.Crud.OneToOne
{
    public class CrudOperation
    {
        public void Add(Employee employee)
        {
            using var context = new AppDbContext();
            context.Add(employee);
            //context.SaveChanges();
        }


        #region Add
        /*
        var added = new CrudOperation();
        added.Add(new Employee
        {
            FullName = "Sedat Gezer",
            Gender = false,
            Department = new Department
            {
                Name = "HR"
            },
            Contact = new Contact
            {
                Email = "sedat@mail.com",
                Phone = "0600",
                Address = "Street disrict city country no:15"
            },
            Projects = new List<Project>()
            {
                new Project{Title = "project1", StartDate=new DateTime(2022,9,12)},
                new Project{Title = "project2", StartDate=new DateTime(2021,9,12)},
                new Project{Title = "project3", StartDate=new DateTime(2020,9,12)},
            }
        });
        Console.WriteLine("Ekleme Basarili");
        */
        #endregion

    }
}