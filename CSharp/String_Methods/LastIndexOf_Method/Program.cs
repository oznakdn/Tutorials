/* AÇIKLAMA
 * String LastIndexOf yöntemi string ifade içerisinde belirtilen karakteri sondan başlayarak arar.
 * "int LastIndexOf(char value)" sözdizimine sahiptir. "value" aranacak olan tek karakterlik değerin tanımlandığı alandır.
 * Geriye int türünde bulduğu karakterin index numarasını döner. Arana karakter string değeri içerisinde yok ise geriye "-1" döner.
*/

string value = "Merhaba Dünya";
int index1 = value.LastIndexOf('h');
Console.WriteLine(index1);

int index2 = value.LastIndexOf('p');
Console.WriteLine(index2);
