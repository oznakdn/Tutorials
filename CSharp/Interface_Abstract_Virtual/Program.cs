/* Interface
 * Class'larin hangi ozellik ve yeteneklere sahip olabilecegini belirlemeye yarayan yapilardir.
 * Reference type dirler.
 * Kod tekrarlarini ve hatali/eksik metot/property tanimlamalarini onlemek icin kullanilir. Projelerin genislemesine imkan saglarlar.
 * Method ve property tanimlanabilir ancak field tanimlanamaz.
 * New keyword'u ile nesne uretilemez.
 * Constructor olusturulamaz
 * Baska bir interface'e implamente edilebilir.
 * Bir class'a bir  yada birden cok interface implamente edilebilir.
*/

/* Abstract Class
 * Class'larin base'i olarak kullanilmaktadirlar. Bir nesnenin hangi temel ozellikleri ve davranislari sergileyecegini belirlemektedirler.
 * Class'larin temel ozellik ve metotlarini icerdiklerinden new keyword ile abstract class lardan nesne uretilemez. Zaten buna ihtiyac da yoktur.
 * Miras olarak class'lara verilerek onlarin temel yapisini olustururlar.
 * Kod tekrarinin azaltilmasini saglarlar.
 * Propery, method ve field tanimlanabilir.
 * Static olarak isaretlenemezler. Ancak member'lari static olarak isaretlenebilir.
 * Constructor olusturulabilir.
*/

/* Virtual
 * Virtual keyword ile tanimlanan metotlar/properyler tanimlandigi sekilde kullanilabildigi gibi override edilerek farkli sekilde de kullanilabilir.
*/


Manager manager = new("John", "Doe")
{
    Age = 30,
    Authority = "Management",
    Bonus = 20000,
    Salary = 30000
};
Manager.Information = "John Doe";
Manager.GetInformation();
manager.Work();
Console.WriteLine(manager.SalaryCalculate());
Console.WriteLine(manager.WorkPlace);



Worker worker = new("Ahmet", "Aslan")
{
    Age = 25,
    WorkTime = 10,
    Salary = 10000
};
Worker.Information = "Ahmet Aslan";
Worker.GetInformation();
worker.Work();
Console.WriteLine(worker.SalaryCalculate());
Console.WriteLine(worker.WorkPlace);


#region Interface

interface IVehicleMethod
{
    void Go();
}

interface IVehicleProperty
{
    string Color { get; set; }
}


class Car : IVehicleMethod, IVehicleProperty
{
    public string Color { get; set; }

    public void Go()
    {
        Console.WriteLine("Ok");
    }
}

class AirPlane : IVehicleMethod, IVehicleProperty
{
    public string Color { get; set; }

    public void Go()
    {
        Console.WriteLine("Ok");

    }
}

#endregion

#region Abstract

abstract class Employee
{

    public Employee()
    {
        WorkPlace = "ABC Holding";
    }

    public Employee(string name, string surname)
    {
        Name = name;
        Surname = surname;
    }

    private int age;
    public string Name { get; set; }
    public string Surname { get; set; }
    public string WorkPlace { get; set; }

    public static string Information { get; set; }
    public int Age
    {
        get => age;
        set => age = value;

    }
    public int Salary { get; set; }
    public virtual int Bonus { get; set; }

    public static void GetInformation()
    {
        Console.WriteLine(Information);
    }
    public abstract void Work();

    public virtual int SalaryCalculate()
    {
        return Salary + Bonus;
    }
}

class Manager : Employee
{
    public string Authority { get; set; }

    public Manager(string name, string surname) : base(name, surname)
    {

    }

    public override void Work()
    {
        Console.WriteLine("Freetime works");
    }
}
class Worker : Employee
{
    public int WorkTime { get; set; }

    public Worker(string name, string surname) : base(name, surname)
    {

    }
    public override int Bonus { get; set; } = 0;

    public override void Work()
    {
        Console.WriteLine("Works 10 hours in a day.");
    }

    public override int SalaryCalculate()
    {
        return this.Salary;
    }
}

#endregion
