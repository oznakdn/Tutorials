// Const = Degistirilemeyen degerler icin kullanilir ve degisken tanimlanirken degeri de tanimlamak zorunludur.
// Read only = Sadece okunma ozelligine sahip degiskendir. Sadece constructor'da ilk deger atanabilir. Daha sonra herhangi bir deger set edilemez.

Example example = new();
//example.ExampleTitle = "dfdfd";  Deger atanamaz.
Console.WriteLine(example.ExampleTitle);



class Example
{

    public Example()
    {
        ExampleTitle = "A example";
    }
    public const double PI = 3.14;
    public readonly string ExampleTitle;

}
