/* AÇIKLAMA
 * String Substring yöntemi ile string ifadesi içerisinde belirtilen index numarasından itibaren başlayarak string ifadeyi geriye döner.
 * "string Substring(int startIndex)" sözdizimine sahiptir. "startIndex" başlangıç karakter index numarasını temsil eder.
 * Geriye başlangıç index numarasının olduğu karakterden itibaren, strin'ing sonuna kadar olan ifade geriye döner. 
 * String'in uzunluğu index değeri ile eşitse geriye boş değer döner. String ifadesi uzunluğundan büyük index değeri verilirse geriye hata döner.
*/


string value = "Merhaba Dünya";
Console.WriteLine(value.Substring(4)); // aba Dünya
