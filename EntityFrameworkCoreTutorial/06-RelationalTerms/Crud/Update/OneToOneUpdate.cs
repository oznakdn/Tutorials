using _06_RelationalTerms.Data;
using _06_RelationalTerms.Entities;
using Microsoft.EntityFrameworkCore;

namespace _06_RelationalTerms.Crud.Update
{
    public class OneToOneUpdate
    {
        // Principal Entity Uzerinden Dependent entitiy verisi eklemek
        public void UpdateEmployeeContact(int employeeId, Contact contact)
        {
            using var context = new AppDbContext();
            var employee = context.Employees.Include(e => e.Contact).FirstOrDefault(e => e.Id == employeeId);
            employee.Contact.Address = contact.Address == default || contact.Address == null ? employee.Contact.Address : contact.Address;
            employee.Contact.Email = contact.Email == default || contact.Email == null ? employee.Contact.Email : contact.Email;
            employee.Contact.Phone = contact.Phone == default || contact.Phone == null ? employee.Contact.Phone : contact.Phone;
            context.SaveChanges();
        }

        public void UpdateEmployeeContact2(int employeeId, Contact contact)
        {
            using var context = new AppDbContext();
            var employee = context.Employees.Include(e => e.Contact).FirstOrDefault(e => e.Id == employeeId);
            context.Contacts.Remove(employee.Contact);
            context.Contacts.Add(new Contact
            {
                EmployeeId = employeeId,
                Email = contact.Email,
                Address = contact.Address,
                Phone = contact.Phone
            });
            context.SaveChanges();
        }

        public void UpdateEmployeeContact3(int employeeId, Contact contact)
        {
            using var context = new AppDbContext();
            var employee = context.Employees.Include(e => e.Contact).FirstOrDefault(e => e.Id == employeeId);
            context.Contacts.Update(new Contact
            {
                EmployeeId = employeeId,
                Email = contact.Email == default || contact.Email == string.Empty || contact.Email == null ? default : contact.Email,
                Address = contact.Address == default || contact.Address == string.Empty || contact.Address == null ? default : contact.Address,
                Phone = contact.Phone == default || contact.Phone == string.Empty || contact.Phone == null ? default : contact.Phone
            });
            context.SaveChanges();
        }

        // Dependent Entity Uzerinden Principal entitiy verisi eklemek

    }
}