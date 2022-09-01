using _06_RelationalTerms.Data;
using _06_RelationalTerms.Entities;

namespace _06_RelationalTerms.Crud.Create
{

    /* Employee ile Contact arasindaki crud islemleri */

    public class OneToOneCreate
    {

        // Principal Entity Uzerinden Dependent entitiy verisi eklemek
        public void AddEmployeeWithContact(Employee employee)
        {
            using var context = new AppDbContext();
            context.Employees.Add(employee);
            //context.SaveChanges();
        }

        // Dependent Entity Uzerinden Principal entitiy verisi eklemek
        public void AddContaxtWithEmployee(Contact contact)
        {
            using var context = new AppDbContext();
            context.Contacts.Add(contact);
            //context.SaveChanges();
        }
    }



}