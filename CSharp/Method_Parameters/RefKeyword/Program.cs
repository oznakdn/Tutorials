/********************** Ref **********************/
/*
  - ref deyimi, metot içerisinde tanımlandığı değişkenin değerinin değiştirilebilmesi amacıyla kullanılır. 
  - ref olarak kullanılacak olan değişkene değer atanması gerekir. Aksi halde hata verecektir.
  - ref anahtar sözcüğü tanımlandığı metot içerisinde gönderilen değişkenin değerini değiştirebilme özelliğine sahiptir. 
  - Örnekte verilen değişken değeri, metot içerisinde farklı bir değer atarak değiştirilmiş ve bulunduğu metot içerisinde 
    ilgili değişken yeni değeri ile kullanılmaya devam eder.
 */


string name = "Mehmet";
Console.WriteLine($"Before: {name}");
string result = RefKeyword.WriteName(ref name);
Console.WriteLine($"Ref: {result}");
Console.WriteLine($"After: {name}");

class RefKeyword
{
    public static string WriteName(ref string Name)
    {
        Name = "Ahmet";
        return Name;
    }
}