
/* 
    * Tabloda gorunmesi istenmeyen yada islem yapilmayacak alanlar icin kullanilirlar.

*/

#region ForeignKey alanlarinda kullanimi

public class Employee
{
    public int Id { get; set; }
    public string EmployeeName { get; set; }

    // public int ProjectId { get; set; } alanini girmedigimizde EF Core arka planda kendi Shadow olarak olusturur.
    public Project Project{get;set;}
}

public class Project
{
    public int Id { get; set; }
    public string ProjectTitle { get; set; }
    public ICollection<Employee>Employees{get;set;}
}
#endregion