/* AÇIKLAMA
 * String Remove yöntemi ile string ifade içerisinde belirtilen index numarasından başlayıp son karaktere kadar olan kısmı siler. 
 * "string Remove(int startIndex)" sözdizimine sahiptir. "startIndex" string ifade içerisinde başlanacak olan index numarasını belirtir. 
 * "startIndex" değeri sıfır olarak tanımlanırsa string ifade içerisindeki tüm karakterler silinir ve geriye boş bir string döner. 
 * Geriye başlama index numarasına göre karakterleri silinen string ifade döner.
*/

string value1 = "Merhaba Dünya";
string value2 = value1.Remove(5);
Console.WriteLine(value2);
