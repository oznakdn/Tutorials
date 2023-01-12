/* Class
 * Miras alinabilirler.
 * Reference type dir. Verilerin Isaretcileri (adresleri) Stack' de tutulurken degerleri Heap'de tutulur.
 * Abstract ve Virtural metot yada propery'ler tanimlabilir.
 * Destructor tanimlanabilir.
 * Interface implamentasyonu yapilabilir.
*/


/* Struct
 * Miras alinamazlar
 * Value type dir. Verilerin adresleri ve degerleri Stack' de tutulur. Daha az maliyetli ve hizlidir.
 * Abstract ve Virtural metot yada propery'ler tanimlanamaz.
 * Destructor tanimlanamaz.
 * Interface implamentasyonu yapilabilir.
*/

using Class_Struct;

OurClass ourClass = new();
OurClass ourClass2 = new(1);

NestedClass.Nested nested = new();
nested.Name = "John";


MyClass myClass = new(1);

MyStruct myStruct = new(2);




class MyClass
{
    public MyClass(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}

struct MyStruct
{
    public MyStruct(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
