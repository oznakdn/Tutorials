/********************** Out **********************/
/*
  - out deyimi, tanımlanan değişkene değer atanması için kullanılır. Bu değişkenin herhangi bir değer alması zorunlu değildir. 
  - out anahtar sözcüğü tanımlandığı metotda herhangi bir değer alması zorunlu değildir. 
  - out anahtar sözcüğünün tanımlandığı metot içerisinde değer atanması gerekir. 
  - int türünde tanımlanan value değişkenine herhangi bir değer atanmadı. TestMethod() metodunda değişkene değer ataması yapılıyor 
    ve TestMethod() içerisinde verilen değer atanmış olur ve program içerisinde kullanılır.
 */


int value;
int result = OutKeyword.TestMethod(out value);
Console.WriteLine(result);
Console.WriteLine(value);



class OutKeyword
{
    public static int TestMethod(out int value)
    {
        value =10;
        return value;
    }
}
