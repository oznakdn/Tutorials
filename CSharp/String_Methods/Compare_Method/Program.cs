/* AÇIKLAMA
 String Compare yöntemi belirtilen iki string değerinin karşılaştırılmasını sağlar. Alfabetik sıraya göre geriye int türünde değer döner.

Compare(string strA,string strB,bool ignoreCase) söz dizimine sahiptir. 
strA : kontrol edilecek olan birinci değer.
strB : kontrol edilecek olan ikinci değer.
ignoreCase : default değeri false'dir.
Return: Geriye dönecek olan değer int türündedir.

Geriye dönen sonuç;

sıfırdan küçükse ise strA,strB den küçüktür, sıfır ise strA,strB' ye eişittir, sıfırdan büyükse strB,strA den büyüktür anlamına gelir.
Karşılaştırma sırasında büyük küçük harf kurallarına göre ve tüm karakterlerin tek tek alfabetik sıralaması kontrol edilir.

        String Compare yöntemi ile iki tane string değer karşılaştırılır.  Karşılaştırma da büyük küçük harf kontrolü ile sıralaması kontrol edilir.

        Karşılaştırma sonucu olarak geriye int türünde değerler döner.

        resultA < 0 olarak geriye döner. valueA değerinin sıralaması valueB değeri sıralamasından küçüktür.    
        resultB = 0 olarak geriye döner. valueC değeri sıralaması ile valueD değeri sıralamasına eşittir.    
        resultC > 0 olarak geriye döner. valueC değeri sıralaması valueA değeri sıralamasından büyüktür.
        Aşağıdaki örnek, String.Compare yönteminin nasıl kullanılacağını gösterir.

*/

string A = "This is a string";
string B = "This is a string charachters";
int result1 = string.Compare(B, A, false); // 1
int result2 = string.Compare(A, B, false); // -1


Console.WriteLine(result1);
Console.WriteLine(result2);

