/* AÇIKLAMA
 * C# String Replace yöntemi ile string ifade içerisindeki karakterlerin değiştirilmesini sağlar. 
 * Geriye eski karakterin yerine yeni karakterlerin aldığı string döner.
 * Replace(char oldChar, char newChar)
   - oldChar: değiştirilecek olan karakter.
   - newChar: oldChar yerine gelecek olan karakter.
   - Returns: Mevcut örnekte oldChar bulunmazsa, yöntem geçerli örneği değiştirmeden geriye döndürür.

 * Replace(String oldValue, String? newValue)
   - oldValue : Değiştirilecek string değer.
   - newValue : OldValue değerinin tümünün yerini alacak string değer.
   - Returns : Tüm oldValue örneklerinin newValue değerine dönüştürülmüş değeri verir. 
     oldValue değeri bulunmazsa ise geçerli değeri değiştirmeden döndürür.
   - Exceptions : oldValue değeri null olmamalıdır.  oldValue değeri null ise geriye hata mesajı döner. 
     oldValue is the empty string ("").
*/


string value1 = "Merhaba Tünya";
string value2 = value1.Replace('T', 'D'); // Merhaba Dünya
Console.WriteLine(value2);