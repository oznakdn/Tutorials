
using _06_RelationalTerms.Crud.Create;
using _06_RelationalTerms.Crud.Update;
using _06_RelationalTerms.Entities;



#region One To One
var oneToOneCreate = new OneToOneCreate();
#region Create
//Principal Entity
oneToOneCreate.AddEmployeeWithContact(
   new Employee
   {
       FullName = "Ahmet Kartal",
       Gender = false,
       DepartmentId = 1,
       Contact = new()
       {
           Email = "ahmetkartal@mail.com",
           Phone = "05935534344",
           Address = "Merkez No:20"
       }
   });

// Dependent Entity
oneToOneCreate.AddContaxtWithEmployee(new Contact
{
    Email = "semiharslan@mail.com",
    Phone = "05846462175",
    Address = "Uzun mahalle no:25",
    Employee = new()
    {
        FullName = "Semih Arslan",
        Gender = false,
        DepartmentId = 1
    }
});

#endregion
#region Update
var oneToOneUpdate = new OneToOneUpdate();
//Principal Entity
var contact = new Contact();
contact.Email = "gezer@mail.com";
contact.Address="Merkez meydan";
contact.Phone = "05153435456";
oneToOneUpdate.UpdateEmployeeContact2(2,contact);
#endregion

#endregion

#region One To Many
var oneToManyCreate = new OneToManyCreate();
#region Create
// Dependent entity ile
oneToManyCreate.AddEmployeeWithDepartment(
    new Employee
    {
        FullName = "Ali Yurur",
        Gender = true,
        Department = new()
        {
            Name = "Marketing"
        }
    }
);

//Principal entity ile
oneToManyCreate.AddDepartmentWithEmployess(
    new Department
    {
        Name = "Accounting",
        Employees = new HashSet<Employee>()
        {
            new Employee {FullName="Sevda Serce", Gender = true},
            new Employee {FullName="Zerrin Kartal", Gender = true},
            new Employee {FullName="Ahu Sahin", Gender = true}
        }
    }
);

//ForeignKey ile
var employee = new Employee();
employee.FullName = "Naciye Sever";
employee.Gender = true;
oneToManyCreate.AddEmployee(employee,2);
#endregion
#region Update
OneToManyUpdate update = new();
var departments = update.GetDepartments();
foreach (var item in departments)
{
    Console.WriteLine($"ID: {item.Id} Department: {item.Name}");
}

update.EmployeeDepartmentUpdate(1, 2);

//
var oneToManyUpdate = new OneToManyUpdate();
oneToManyUpdate.DepartmentEmployeeUpdate(1, new Employee());

#endregion
#endregion

#region Many To Many
var manyToManyCreate = new ManyToManyCreate();
#region Create
 manyToManyCreate.AddNewEmployeeWithProjects(new Employee
 {
    FullName = "Berke Okur",
    Gender = false,
    DepartmentId = 2,
    Projects = new HashSet<Project>()
    {
        new Project {Title = "Project4", StartDate=new DateTime(2021,11,9), EndDate = new DateTime(2025,12,31)},
        new Project {Title = "Project5", StartDate=new DateTime(2021,11,9),EndDate = new DateTime(2025,12,31)}
    }
 });


 manyToManyCreate.AddProjectToEmployee(10,1);
 // With fluent Api
 var project = new Project
 {
    Id=5,
    Title = "Project",
    Employees = new HashSet<Employee>()
    {
        new (){Id =3},
        new (){Contact = new(){Address = "Merkez",Email="aliyurur@mail.com", Phone = "05997959545"}}
    }
    
 };
 manyToManyCreate.AddProjectEmployeeWithFluentApi(5);
#endregion
#region Update

var manyToManyUpdate = new ManyToManyUpdate();
manyToManyUpdate.EmployeeProjectUpdate(1,new Project{Title="Management Project", StartDate = new DateTime(2022,02,12), EndDate=new DateTime(2023,02,12)});
#endregion 
#endregion




