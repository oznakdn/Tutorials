/* AÇIKLAMA
 * String CopyTo yöntemi ile belirtilen sayıdaki karakterin, belirtildiği index numarasından itibaren kopyalanması için kullanılır.
 * CopyTo(int sourceIndex,char[] destination,int destinationIndex,int count) söz dizimine sahiptir.
   - sourceIndex - Kopyalanacak olan değerin ilk karakterin index numarası. 
   - destination - Kopyalanacak olan dizi değişkeni. 
   - destinationIndex - Kopyalama işleminin başlayacağı index numarası.  
   - count - Kopyalanacak olan karakter sayısı.

 * Ortaya çıkan kopyalama işlemi sonucu bir diziye kopyalanır.
*/

string value = "Merhaba Nasılsın?";
char[] ch = new char[20];
value.CopyTo(5, ch, 1, 7);
Console.WriteLine(ch);
