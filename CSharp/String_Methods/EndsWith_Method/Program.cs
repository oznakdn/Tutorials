/* AÇIKLAMA
 * String EndsWith yöntemi ile string ifadesinin sonundaki karakterlerden başlayarak eşleştirme yapar. Geriye boolean türde değer döner.
 * "bool EndsWith(string value)" sözdizimine sahiptir. "value" değeri string ifadesi içerisinde arama yapılacak olan değeri ifade eder.
 * Eşleştirme olursa "true" olmazsa "false" geriye döner.
*/

string value1 = "Merhaba Dünya";
string value2 = "nya";
string value3 = "Uzay";
Console.WriteLine(value1.EndsWith(value2));
Console.WriteLine(value1.EndsWith(value3));
