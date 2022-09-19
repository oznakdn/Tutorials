/* AÇIKLAMA
 * String Equals yöntemi iki string değerin aynı değere sahip olup olmadıklarını kontrol eder. 
 * "bool Equals(Object obj)" sözdizimine sahiptir. "obj" değeri karşılaştırılacak olan değeri ifade eder. Geriye boolean türde değer döner.  
 * Değerler birbirlerine eşitse "true", eşit değilse "false" olarak geriye döner.
*/

string value1 = "Uzay";
string value2 = "Dünya";
string value3 = "Uzay";

Console.WriteLine(value1.Equals(value2)); // false
Console.WriteLine(value1.Equals(value3)); // true