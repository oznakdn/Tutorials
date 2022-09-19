/* AÇIKLAMA
* String ToCharArray yöntemi ile string ifadesi içerisindeki değerin karakterlerine ayrılmasını sağlar.
* "char[] ToCharArray()" sözdizimine sahiptir. Herhangi bir parametre almaz.
* Geriye string ifadenin karakterleri dizi olarak geri döner.
*/

string value = "Merhaba Dünya";
char[] array = value.ToCharArray();
foreach (var item in array)
{
    Console.WriteLine(item);
}
