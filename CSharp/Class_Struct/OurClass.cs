namespace Class_Struct
{
    public class OurClass
    {
        public OurClass()
        {

        }

        /* Parametreli bir constructor tanimlandiginda default constructor iptal edilir. 
           Eger iptal edilmesi istenmezse yukaridaki gibi default constructor acikca tanimlanmalidir.
           Boylece butun constructorlar nesne olusturulurken overload olarak karsimiza cikar.
        */

        public OurClass(int id)
        {

        }

        public int Id { get; set; }
    }
}