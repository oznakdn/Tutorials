using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/* Delegates (temsilciler) *
 - Bazen programımızın çevresinde yönteme bir işaretçi iletmek isteyebiliriz. Yöntemin bu işaretçisine Delege adı verilir ve 
   yöntemi başka bir konumdan çağırmamızı sağlar. 
 - Temsilciler, bu yönteme başvurmak için eşleştirmeleri gereken yöntem imzasıyla tanımlanır. 
 - Delegelere bazen Geri Arama İşlevleri (callback functions) denir.
 - Delegate olarak isaretlenecek olan metotlarin donus tipleri, parametre tipleri ve parametre sayilari ayni olmalidir.
*/
namespace MethodsEventsDelegates
{
    public class DelegateAbout
    {
        public delegate int CalculateHandler (int arg1, int arg2);

        public int Calculate(int myArg1, int myArg2, CalculateHandler handler)
        {
            var output = handler(myArg1,myArg2);
            return output;
        }

        public int Add (int arg1, int arg2)
        {
            var output = arg1 + arg2;
            Console.WriteLine($"Added: {output}");
            return output;
        }

        public int Subtract (int arg1, int arg2)
        {
            var output = arg1 - arg2;
            Console.WriteLine($"Subtracted: {output}");
            return output;
        }
    }
}