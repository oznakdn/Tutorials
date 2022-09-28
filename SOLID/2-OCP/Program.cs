/* 
    Open-Closed Principle
 -  Modüller, sınıflar, işlevler vb. yazılım varlıklarının genişletilmeye açık, ancak değiştirilmeye kapalı olması gerektiğini ” belirtir .
 -  Burada iki şeyi anlamamız gerekiyor. İlki Uzatmaya Açık, ikincisi ise Değiştirilmeye Kapalıdır. 
 -  Genişletmeye Açık, yazılım modüllerini/sınıflarını, yeni gereksinimler geldiğinde yeni sorumluluklar veya işlevler kolayca eklenecek 
    şekilde tasarlamamız gerektiği anlamına gelir. 
 -  Öte yandan, Modifikasyona Kapalı, bazı hatalar bulana kadar sınıfı/modülü değiştirmememiz gerektiği anlamına gelir.
 -  Basit bir ifadeyle, kaynak kodunu değiştirmeden davranışının genişletilmesine izin verecek şekilde bir modül/sınıf 
    geliştirmemiz gerektiğini söyleyebiliriz.
*/


Invoice FInvoice = new FinalInvoice();
Invoice PInvoice = new ProposedInvoice();
Invoice RInvoice = new RecurringInvoice();
double FInvoiceAmount = FInvoice.GetInvoiceDiscount(10000);
double PInvoiceAmount = PInvoice.GetInvoiceDiscount(10000);
double RInvoiceAmount = RInvoice.GetInvoiceDiscount(10000);
Console.ReadKey();





public class Invoice
{
    public virtual double GetInvoiceDiscount(double amount)
    {
        return amount - 10;
    }
}

public class FinalInvoice : Invoice
{
    public override double GetInvoiceDiscount(double amount)
    {
        return base.GetInvoiceDiscount(amount) - 50;
    }
}
public class ProposedInvoice : Invoice
{
    public override double GetInvoiceDiscount(double amount)
    {
        return base.GetInvoiceDiscount(amount) - 40;
    }
}
public class RecurringInvoice : Invoice
{
    public override double GetInvoiceDiscount(double amount)
    {
        return base.GetInvoiceDiscount(amount) - 30;
    }
}
