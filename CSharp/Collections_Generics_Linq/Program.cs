using Collections_Generics_Linq;


#region Collections
#region Array

var myArray = new MyArray();
Console.WriteLine(myArray.names == null ? "Names is null" : "Names is not null");
myArray.names = new string []{"John"};
Console.WriteLine(myArray.names == null ? "Names is null" : "Names is not null");
Console.WriteLine(myArray.numbers.Length);

#endregion
#endregion
