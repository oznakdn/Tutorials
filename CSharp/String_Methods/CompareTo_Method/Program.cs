/* AÇIKLAMA
* String CompareTo yöntemi tanımlı olan string türündeki değişken değerini, diğer bir string değeri ile karşılaştırır.  
* Karşılaştırma harfleri tek tek olarak numaralandırır ve büyük küçük harf kontrolüne göre sıralama değişir.  
* "int CompareTo(string strB)" sözdizimine sahiptir.  "strB" karşılaştırılacak olan string değerdir. 
* Geriye int türünde değer döner. Geriye dönen sonuç sıfırdan küçükse ise value1,value2 den küçüktür "0" ise value1,value2' ye 
  eişittir ve sıfırdan büyükse value1,value2 den büyüktür anlamına gelir.
* String CompareTo yöntemi ile iki string değer karşılaştırılır. Karşılaştırma tek karakter olarak yapılır. 
  Örnek uygulamada value1 ile value2 değerleri CompareTo ile karşılaştırılmıştır. 
  Geriye dönen değer bir olduğundan dolayı value1 değeri value2 değerinden sıralamada büyüktür.
*/

string value1 = "Merhaba";
string value2 = "Dünya";

var result = value1.CompareTo(value2);
Console.WriteLine(result);
