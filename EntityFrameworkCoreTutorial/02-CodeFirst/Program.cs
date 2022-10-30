/* Code First 
   - Yazilacak olan projede veritabani yoksa yani sifirdan modellenip olusturulacaksa code first yaklasimi kullanilabilinir.
   - Olusturulmak istenen veri tabani class'lar yardimiyla modellenerek migrate edilir ve veri tabani olusturulur.
*/

/* Paketler
   dotnet add package Microsoft.EntityFrameworkCore.Tools
   dotnet add package Microsoft.EntityFrameworkCore.Design
   dotnet add package Microsoft.EntityFrameworkCore.SqlServer
*/

/* Migration Komutlar 
    Detay : https://docs.microsoft.com/tr-tr/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
    Package Manager Console    Add-Migration [Migration Name]
                               Update-Database
                               remove-migration

   .Net CLI                    dotnet ef migrations add [Migration Name]
                               dotnet ef database update
                               dotnet ef migrations remove

                               Birden fazla context sınıfı için
                               dotnet ef migrations add Init --context IdentityContext --startup-project ../../Client/CrmApp.WebMvc
                               dotnet ef database update --context IdentityContext --startup-project ../../Client/CrmApp.WebMvc

                               Project not found hatasinda
                               dotnet ef migrations add Init --project "C:\Users\USER\Desktop\Practices\Asp.Net Core MVC\Advanced_AjaxCrud\Advanced_AjaxCrud"
                               dotnet ef database update --project "C:\Users\USER\Desktop\Practices\Asp.Net Core MVC\Advanced_AjaxCrud\Advanced_AjaxCrud"
*/

using _02_CodeFirst.Data;
using _02_CodeFirst.Entities;

using var context = new ApplicationDbContext();


#region AddRange
/*
context.Teachers.AddRange(
 new List<Teacher>()
   {
        new Teacher {Firstname = "Ali", Lastname = "Gezer", DateOfBird = new DateTime(1985,02,15), Branch = "Geography"},
        new Teacher {Firstname = "Veli", Lastname = "Sever", DateOfBird = new DateTime(1982,05,02), Branch = "Maths"},
        new Teacher {Firstname = "Sevda", Lastname = "Bilir", DateOfBird = new DateTime(1980,11,12), Branch = "Biology"}
   }
 );
context.SaveChanges();
Console.WriteLine("Kayitlar Basarili");
*/
#endregion

#region DeleteRange

/*
var firstTeacher = context.Teachers.SingleOrDefault(x => x.Id == 7);
var secondTeacher = context.Teachers.SingleOrDefault(x => x.Id == 8);
var thirdTeacher = context.Teachers.SingleOrDefault(x => x.Id == 9);

context.Teachers.RemoveRange(firstTeacher, secondTeacher, thirdTeacher);
context.SaveChanges();
*/
#endregion

#region Update
var updateTeacher = context.Teachers.Where(x => x.Id == 5).SingleOrDefault();
updateTeacher.Firstname = "Ali";
context.SaveChanges();
Console.WriteLine("Guncelleme basarili");
#endregion

#region GetAll

var teachers = context.Teachers.ToList();
foreach (Teacher teacher in teachers)
{
    Console.WriteLine($"{teacher.Firstname} {teacher.Lastname} {teacher.DateOfBird.Year} {teacher.Branch}");
}
Console.WriteLine("-------------------------");
#endregion

#region GetByFirstname
var getTeacher = context.Teachers.Where(x => x.Firstname == "Ali").SingleOrDefault();
Console.WriteLine(getTeacher.Firstname + " " + getTeacher.Lastname + " " + getTeacher.DateOfBird.Year + " " + getTeacher.Branch);

#endregion

