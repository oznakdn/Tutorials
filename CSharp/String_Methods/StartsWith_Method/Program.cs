/* AÇIKLAMA
 *  String StartsWith yöntemi ile string ifadesinin başlangıç karakterinden itibaren belirtilen değerin eşleşip eşleşmediğini kontrol eder.
 * "bool StartsWith(string value)" sözdizimine sahiptir.  "value" karşılaştırılacak olan string değeridir..
 * Geriye boolean türde değer döner.  Eşleşme sağlanırsa "true", sağlanmaz ise "false" geriye döner.
*/


string value1 = "Merhaba Dünya";
Console.WriteLine(value1.StartsWith("a")); // false
Console.WriteLine(value1.StartsWith("m")); // false
Console.WriteLine(value1.StartsWith("M")); // true