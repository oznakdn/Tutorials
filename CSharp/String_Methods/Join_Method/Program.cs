/* AÇIKLAMA
 * String Join yöntemi ile dizi içerisinde bulunan her üye elemanı için ayırıcı kullanarak birleştirir.
 * "string Join<T>(string separator, IEnumerable<T> values)" sözdizimine sahiptir. "T" Alınan değişken türü belirtilir.  
 * "separator" Ayırıcı olarak kullanılacak olan değer yazılır. "values" birleştirilecek olan dizi elemanlarını birleştirecek olan koleksiyondur.
 * Dizi elemanları, tanımlanan ayırıcı değer eklenerek geriye string türünde döner. 
 * "separator" değişkeninde herhangi bir değer yok ise dizi elemanları yan yana yazılarak geriye döner.
*/


string[] values = { "1", "2", "3", "4", "5" };
string result = string.Join("", values);
Console.WriteLine(result);