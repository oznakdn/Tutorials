// Is: Bir tipin baska bir tipe donusturulup donusturemeyecegi durumu doner (true-false).
// As: Bir tip baska bir tipe donusturulebiliyorsa donusturur, donusturulemiyorsa 'null' doner.



object[] myArray = new object[] { "hello", 5, 6.5, false, "world", true, 40 };


// Is
foreach (var item in myArray)
{
    if (item is string)
    {
        Console.WriteLine("Item is string");
    }
    else
    {
        Console.WriteLine("Item is not string");
    }
}

/* result

Item is string
Item is not string
Item is not string
Item is not string
Item is string
Item is not string
Item is not string

*/


// As
foreach (var item in myArray)
{
    string data = item as string;
    Console.WriteLine(data);
}

/* result

hello



world

*/