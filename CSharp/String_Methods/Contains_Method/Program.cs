/*
 * String Contains yöntemi string türündeki değer içerisinde arama yapar.  Geriye boolean türde döner.  
 * "bool Contains(string value)" sözdizimine sahiptir.  "value" aranacak olan string değeri ifade eder.  
 * String Contains yöntemi ile aranan veri var ise "true" yok ise "false" olarak geriye döner.
 * String Contains yöntemi büyük küçük harfe duyarlıdır. Arama işlemi ilk karakterden başlayarak son karaktere kadar devam eder.
*/

string value1 = "Hello, world";
bool result = value1.Contains("or");
Console.WriteLine(result); // True
