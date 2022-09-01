using MethodsEventsDelegates;


#region Methods
// Calls Method
var method = new Method();
double sumResult = method.Sum(1.5, 2.5);
System.Console.WriteLine(sumResult);


// With Params keyword
var withoutParameter = method.MultipleSum();
Console.WriteLine(withoutParameter); // result = 0;

var withParameter = method.MultipleSum(10, 20, 30, 40, 50);
Console.WriteLine(withParameter); // result= 150

// Without Params keyword
string[] lessons = { "Maths", "Science", "History", "Geography" };
var lessonResult = method.Lessons(lessons);
foreach (string lesson in lessonResult)
{
    System.Console.WriteLine(lesson);
}

// Out
string save = method.Save(out string UniversityName, "John", "Walker", "2022");
System.Console.WriteLine(save);

// Ref
string name = "John";
method.Hello(ref name);
#endregion


#region Delegates

DelegateAbout delege = new DelegateAbout();

var delegateHandler = new DelegateAbout.CalculateHandler(delege.Add);
delege.Calculate(10, 5, delegateHandler);

#endregion

#region Events
var eventAbout = new EventAbout();
eventAbout.Enrolled += (sender, args) =>Console.WriteLine("I'm now enrolled for the year " + args.YearEnrolled);

eventAbout.Enroll();
#endregion







