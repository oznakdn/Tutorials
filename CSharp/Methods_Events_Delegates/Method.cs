using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/* Methods *
 - Programın yürütebileceği bir dizi ifadeyi içeren bir kod bloğu olarak tanımlanır. 
 - Yöntemleri genellikle sınıfımızın gerçekleştirdiği bir eylem veya sınıf üzerinde bir eylem olarak düşünürüz.
 - Bir yöntemin, onunla nasıl etkileşime geçebileceğinizi tanımlayan bir imzası vardır. 
   İmzanın hemen ardından , yöntemde yürütülecek kodu saran kaşlı ayraçlar { } gelir.
 - Varsayılan olarak, access modifier'i olmayan bir yöntem kabul "private" kabul edilir.
 - Parametreler, virgülle ayrılır ve parametrenin türü ve adı ile değişkenlere benzer şekilde tanımlanır.
*/

/* Methods Overloading *
 - Birden çok constructor olusturabildigimiz gibi, aynı isim ve farklı parametreler ve dönüş türleri ile birden çok yöntem de olusturabiliriz. 
   Buna Yöntem Aşırı Yükleme denir ve sınıfımızla aynı amaca sahip alternatif etkileşimler sağlamak için çok değerli olabilir.
*/

/* Params *
 - Params keyword'u metotların değişken/istenen sayıda parametre almasına imkan veren bir anahtar kelimedir.
 - Params kullanildiginda metoda parametre verme zorunlulugu yoktur. Hata vermez ancak metodun donus tipi int ise 0, string ise null dondurur.
*/

/* Ref ve Out 
 - Deger tipli degiskenleri referans tipler gibi kullanmayi saglayan anahtarlardir.
 - Out bir parametrenin çıkış olarak ayarlandığını belirtir ve Ref bir parametrenin referans olarak iletildiğini belirtir.
 - Bu anahtar sözcükler bir yöntemin parametre imzasında kullanılıyorsa, yöntem yürütülürken de kullanılmaları gerekir.
 - Out kullanilan bir metotda baslangic degeri verilmelidir. Metot calistirildiginda direkt o deger kullanilir, degistirilemez.
   Ornegin metod da daha sonra degismesini istemedigimiz bir parametre varsa Out anahtari ile kullaniriz.

*/



namespace MethodsEventsDelegates
{
    public class Method
    {

        public void Write()
        {
            Console.WriteLine("Writing");
        }



        /// <summary>
        /// Params keywordu kullanildigi icin, metodu kullanirken parametre verme zorunlulugu yoktur
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public int MultipleSum(params int[] numbers)
        {
            int total = 0;
            foreach (int number in numbers)
            {
                total += number;
            }
            return total;
        }

        /// <summary>
        /// Params keywordu kullanilmadigi icin, metodu kullanirken parametre verme zorunlulugu vardir
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public string[] Lessons(string[] lessons)
        {
            var result = new string[lessons.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = lessons[i];
            }

            return result;
        }


        // Methods overloading

        public double Sum(double number1, double number2)
        {
            return number1 + number2;
        }

        public int Sum(int number1, int number2)
        {
            return number1 + number1;
        }

        // Out
        public string Save(out string UniversityName, string FirstName, string LastName, string Year)
        {
            UniversityName = "MIT";
            return $"{UniversityName} University saving Student is\nFirstname : {FirstName}\nLastname : {LastName}\nSaving Year : {Year} ";
        }

        // Ref

        public void Hello(ref string name)
        {
            name += " Walker";
            Console.WriteLine("Hello!" + " " + name);
        }



    }
}