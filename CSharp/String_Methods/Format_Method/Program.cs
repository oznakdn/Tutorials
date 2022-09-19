/* AÇIKLAMA
 * String Format yöntemi ile değerlerin formatlarının değiştirilmesi sağlanır. 
 * Sayılar, tarihler vb. değerleri farklı biçimlere dönüştürülmesi sağlanır. 
 * "string Format(string format,params Object[] args)" sözdizimine sahiptir.
 * "format" alanına format türü eklenir. 
 * "args" alanına formatı değiştirilecek olan nesne değeri atanır. 
 * Geriye formatı değişmiş olan veri döner.
*/

string value = string.Format("{0:D}", DateTime.Now);
Console.WriteLine(value);

string value2 = string.Format("{0:F2}", 15.5);
Console.WriteLine(value2);