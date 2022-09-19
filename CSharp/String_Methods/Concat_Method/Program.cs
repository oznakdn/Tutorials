/* AÇIKLAMA
 * String Concat yönetimi belirtilen iki string değişkeni birleştirir ve yeni bir string değer geriye döner.  
 * "string Concat(string str0,string str1)" söz dizimine sahiptir.  
 * İki yada daha fazla string türdeki verileri birleştirir.  
*/

string value1 = "Merhaba1";
string value2 = "Merhaba2";
string value3 = "Merhaba3";
string result = string.Concat(value1, value2,value3);
Console.WriteLine(result);