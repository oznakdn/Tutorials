/*********** TUPLE ***********/
/*
    - C# Tuple<string, bool, int>() şekinde tanımlanan metot geriye item1, item2, item3 olarak döner.
 */

using System.Data.SqlTypes;

Tuple <int,string,bool> person = new Tuple<int, string, bool> (1,"Ahmet",true);
Console.WriteLine($"ID : {person.Item1} Name: {person.Item2} Gender: {person.Item3}");
