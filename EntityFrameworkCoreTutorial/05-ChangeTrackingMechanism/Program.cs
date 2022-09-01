
/* change Tracking (Değişiklik izleme)
  - Değişiklik izleme, uygulamalar için verimli bir değişiklik izleme mekanizması sağlayan hafif bir çözümdür. 
  - Tipik olarak, uygulamaların bir veritabanındaki verilerdeki değişiklikleri sorgulamasını ve değişikliklerle ilgili 
    bilgilere erişmesini sağlamak için uygulama geliştiricilerin özel değişiklik izleme mekanizmalarını uygulamaları gerekiyordu. 
    Bu mekanizmaları oluşturmak genellikle çok fazla iş gerektiriyordu ve sıklıkla tetikleyiciler, zaman damgası sütunları, 
    izleme bilgilerini depolamak için yeni tablolar ve özel temizleme işlemlerinin bir kombinasyonunu kullanmayı gerektiriyordu.
  - Uygulamalar, bir kullanıcı tablosunda yapılan değişikliklerle ilgili aşağıdaki soruları yanıtlamak için değişiklik izlemeyi kullanabilir:
    . Bir kullanıcı tablosu için hangi satırlar değişti?
    . Sıra değişti mi?
  - Context uzerinden gelen nesnelere ait islem veya degisiklikler changeTracking mekanizmasi tarafindan izlenir. Bu mekanizmaya gore sql sorgulari uretilir.
  - Metot ve property ler
    . DetectChanges = changeTracking mekanizmasini manuel olarak devreye sokar.
    . AutoDetectChangesEnabled = DetectChanges ozelligini kapatir.
    . Entries = Tum takip edilen nesnelerin state bilgisini EntityEntry tipinde verir.
*/


/* Entity State Metotlari */

  using var context = new AppDbContext();
  Product product = new();
  #region Added
    context.Entry(product).State = EntityState.Added;
    //context.SaveChanges();
  #endregion

  #region Modified
    context.Entry(product).State = EntityState.Modified;
    //context.SaveChanges();
  #endregion

  #region Deleted
    context.Entry(product).State = EntityState.Deleted;
    //context.SaveChanges();
  #endregion






/* AsNoTracking() ve AsNoTrackingWithIdentityResolution() Kullanimi 
 * iliskisel verilerde AsNoTrackingWithIdentityResolution() kullanilir.
 * normal veriler getirilirken AsNoTracking() kullanilir.
*/

var method = new Method();
var productList = method.GetProducts(false).ToList();
productList.ForEach(item=>{
    Console.WriteLine(item.ProductName);
});



public class Method
{

    public IQueryable<Product>GetProducts(bool isTracking)
    {
        using var context = new AppDbContext();
        if(!isTracking)
        {
            return context.Products.AsNoTracking(); 
        }
        return context.Products.AsQueryable();
        
    }

    public List<Category>GetCategories(bool isTracking)
    {
        using var context = new AppDbContext();
        if(!isTracking) return context.Categories.AsNoTracking().ToList();

        return context.Categories.ToList();
    }

    public List<Category>GetCategoryProducts(int categoryId, bool isTracking)
    {
        using var context = new AppDbContext();
        if(!isTracking)
        {
            return context.Categories.Include(x=>x.Products).AsNoTrackingWithIdentityResolution().ToList();
        }

        return context.Categories.Include(x=>x.Products.Select(x => new {
            x.Id,
            x.ProductName,
            x.Price
        })).ToList();
    }
}
