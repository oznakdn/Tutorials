/* AÇIKLAMA
 * String GetEnumerator yöntemi string ifadesi içerisinde karakterlerin tek tek alınmasını sağlar. 
 * "CharEnumerator GetEnumerator()" söz dizimine sahiptir. Geriye CharEnumerator olarak döner. 
 * while-loop döngüsü içerisinde MoveNext yöntemi ile karakterlere ve karakter numaralarına erişim sağlanır.
*/


string value = "Merhaba Dünya";
CharEnumerator charEnumerator = value.GetEnumerator();
while (charEnumerator.MoveNext())
{
    Console.WriteLine(charEnumerator.Current);
}