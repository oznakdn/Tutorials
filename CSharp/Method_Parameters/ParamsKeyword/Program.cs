/********************** Params **********************/
/*
  - params deyimi ile metot içerisinde birden fazla değer alır. 
  - Parametre bildiriminde belirtilen türde bağımsız değişkenleri virgül ile ayrılmış bir liste olarak gönderilir.
  - params deyimi ile bağımsız türde değişkenler gönderilebilir. Eğer params deyimi içerisinde herhangi bir değer 
    gönderilmez ise sıfır listesi olarak döner.
  - Ek parametre olarak tanımlanabilen params deyimi birden fazla tanımlanamaz.
 */


int result =ParamsKeyword.Sum(10,20,30);
Console.WriteLine($"Sum = {result}");

public class ParamsKeyword
{
    public static int Sum (params int[] numbers)
    {
        int result =0;
         Array.ForEach(numbers, item =>
         {
             result+=item;
         });

        return result;
    }
}
