/* 
    Single Responsibility Principle
 -  Her yazılım modülünün  veya  sınıfının değişmek için yalnızca bir nedeni olmalıdır.
 -  Başka bir deyişle, her modülün veya sınıfın yapması gereken tek bir sorumluluğun olması gerekir.
 -  Bu yüzden yazılımı öyle bir şekilde tasarlamalıyız ki, bir sınıf veya modüldeki her şey tek bir sorumlulukla ilgili olmalıdır. 
 -  Bu, sınıfınızın yalnızca bir yöntem veya özellik içermesi gerektiği anlamına gelmez, tek bir sorumluluk veya işlevle ilgili 
    oldukları sürece birden fazla üyeye (yöntem veya özellik) sahip olabilirsiniz. 
 -  Böylece, C#'daki SRP'nin yardımıyla sınıflar daha küçük ve daha temiz hale gelir ve böylece bakımı daha kolay hale gelir.

*/


// Loglama için
public interface ILogger
{
    void Info(string info);
    void Debug(string info);
    void Error(string message, Exception ex);
}

public class Logger : ILogger
{
    public Logger()
    {

    }
    public void Info(string info)
    {
        Console.WriteLine(info);
    }
    public void Debug(string info)
    {
        Console.WriteLine(info);
    }
    public void Error(string message, Exception ex)
    {
        Console.WriteLine($"{message} {ex.Message}");
    }
}

// Mail için
public class MailSender
{
    public string EMailFrom { get; set; }
    public string EMailTo { get; set; }
    public string EMailSubject { get; set; }
    public string EMailBody { get; set; }
    public void SendEmail()
    {
        // Here we need to write the Code for sending the mail
    }
}

// Fatura için
public class Invoice
{
    public long InvAmount { get; set; }
    public DateTime InvDate { get; set; }
    private ILogger fileLogger;
    private MailSender emailSender;
    public Invoice()
    {
        fileLogger = new Logger();
        emailSender = new MailSender();
    }
    public void AddInvoice()
    {
        try
        {
            fileLogger.Info("Add method Start");
            // Here we need to write the Code for adding invoice
            // Once the Invoice has been added, then send the  mail
            emailSender.EMailFrom = "emailfrom@xyz.com";
            emailSender.EMailTo = "emailto@xyz.com";
            emailSender.EMailSubject = "Single Responsibility Princile";
            emailSender.EMailBody = "A class should have only one reason to change";
            emailSender.SendEmail();
        }
        catch (Exception ex)
        {
            fileLogger.Error("Error Occurred while Generating Invoice", ex.Message);
        }
    }
    public void DeleteInvoice()
    {
        try
        {
            //Here we need to write the Code for Deleting the already generated invoice
            fileLogger.Info("Delete Invoice Start at @" + DateTime.Now);
        }
        catch (Exception ex)
        {
            fileLogger.Error("Error Occurred while Deleting Invoice", ex);
        }
    }
}