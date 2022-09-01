using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/* Events
  - sınıfımızın içinde bir şey olduğunda haber vermemizi sağlar. Olaylar, olay başlatıldığında çağrılması gereken 
     başka bir yönteme başvurdukları için delege kavramı üzerine kuruludur . 
  - Erişim değiştiricileri ve .NET standart uygulamasına göre iki argümanla bir olay tanımlarız:
       - gönderen
       - ortaya çıkan olayla ilgili tüm argümanları içeren bir sınıf.
  - Bir olaydan dönüş türü EventHandler dir. Bu iki bağımsız değişkeni tanımlayan türden bir temsilcidir.
*/
namespace MethodsEventsDelegates
{

    public class EnrolledEventArgs : EventArgs
    {
        public short YearEnrolled { get; set; }
    }
    public class EventAbout
    {
        public delegate void EnrolledEventHandler(object sender, EnrolledEventArgs args);
        public event EnrolledEventHandler Enrolled;

        public void Enroll() {
        
        Enrolled(this, new EnrolledEventArgs {
                YearEnrolled = 2021
            });
        
    }
    }
}