/* AÇIKLAMA
 * String Split yöntemi string ifade içerisinde bulunan karakterleri temel alarak, alt diziye böler.
 * string[] Split(params char[] separator) söz dizimine sahiptir.
   - separator : string'in parçalanması için belirlenen char karakteri ifade eder.
   - Return : Geriye dizi döner.
*/

string value1 = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. ";
string[] value2 = value1.Split(' ');
foreach (string item in value2)
{
    Console.WriteLine(item);
}