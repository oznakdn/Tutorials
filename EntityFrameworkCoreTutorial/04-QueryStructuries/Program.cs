
using _04_QueryStructurs.Data;
using _04_QueryStructurs.Entities;


using var context = new AppDbContext();


/************************************* Çoklu Veri Getirme Sorguları *****************************/

#region IQeryable Nedir?
/*
 * IQeryable Ef Core uzerinden yapilmis olan sorgunun olusturulup henuz execute edilmemis halidir.
 * IQueryable sorgularda, kod yazildigi noktada sorguyu olusturmaz. 
 * ToList() gibi bir metod calistirildiginda execute edilerek sorguyu baslatir ve verileri getirir (Eretelenmis calisma=Deffered Execution).
*/

// Method
IQueryable<Product> products1 =context.Products.AsQueryable(); //In Memory
products1.ToList(); //executing

// Linq
var products2 = from p in context.Products select p;
products2.ToList();

#endregion

#region IEnumerable Nedir?
/*
 * IEnumerable sorgunun olusturulup execute edilerek verilerin hafizaya (memory) alinmis halidir.
*/

// Method
IEnumerable<Category> categories1 = context.Categories.ToList(); // In Memory and Executing

// Linq
var categories2 = (from c in context.Categories select c).ToList();

#endregion

#region ToList()
/*
 * Sorguyu Execute ederek tum verileri getiren metotdur.
*/
// Method                                                              
var productsList = context.Products.ToList();
                          
// Linq
var categoryList = (from category in context.Categories
                    select category).ToList();
#endregion

#region Where()
/*
 * Sorguya kosul yada kosullar eklememizi saglar.
*/

// Method
var products3 = context.Products.Where(p=>p.Price>=20000 && p.Price<=40000);

// Linq
var categories3 = from c in context.Categories
                  where c.Id >1 && c.CategoryName.Contains("t")
                  select c;

#endregion

#region OrderBy()
/*
 * Parametre olarak verilen kosullarda verileri kucukten buyuge siralar.
*/

// Method
var produts4 = context.Products.OrderBy(p=>p.ProductName).ToList();

// Linq
var categories4 = (from c in context.Categories
                  where c.Id % 2 == 0
                  orderby c.CategoryName
                  select c).ToList();

#endregion 

#region OrderByDescending()
/*
 * Parametre olarak verilen kosullarda verileri buyukten kucuge siralar.
*/

// Method
var produts5 = context.Products.OrderByDescending(p=>p.ProductName).ToList();

// Linq
var categories5 = (from c in context.Categories
                  where c.Id % 2 == 0
                  orderby c.CategoryName descending
                  select c).ToList();

#endregion

#region ThenBy()
/*
 * OrderBy yada OrderByDescending ile birlikte baska colonlara da siralama uygulayabildigimiz metotdur.
*/

// Method
var produts6 = context.Products.OrderBy(i=>i.Id).ThenBy(p=>p.ProductName).ThenBy(p=>p.Price).ToList();

#endregion


/************************************* Tek Veri Getirme Sorguları ********************************/

#region Single()
/*
 * Tek bir veriyi getirir. Veri yoksa yada birden fazla veri gelirse hata firlatir.
 * Verilerde mukerrer Id kullanilip kullanilmadigini kontrol etmek icin kullanilir. Verinin tek olmasi beklenir.

*/

// Method
var product1 = context.Products.Single(p=>p.CategoryId==1);

// Linq
var category1 = (from c in context.Categories
                where(c.Id == 1)
                select c).Single();
    
#endregion

#region SingleOrDefault()
/*
 * Tek bir veriyi getirir. Veri yoksa null dondurur, birden fazla veri gelirse hata firlatir.
 * Verilerde mukerrer Id kullanilip kullanilmadigini kontrol etmek icin kullanilir. Verinin tek olmasi beklenir.

*/

// Method
var product2 = context.Products.SingleOrDefault(p=>p.Id == 1);

// Linq
var category2 = (from c in context.Categories
                where(c.Id == 1)
                select c).SingleOrDefault();
    
#endregion

#region First()
/*
 * Tek veri getirir. Veri yoksa hata firlatir, birden fazla veri varsa ilk veriyi getirir.
*/

// Method
var product3 = context.Products.First(p=>p.CategoryId==1);

// Linq
var category3 = (from c in context.Categories
                where(c.Id == 1)
                select c).First();
    
#endregion

#region FirstOrDefault()
/*
 * Tek veri getirir. Veri yoksa null dondurur, birden fazla veri gelirse ilk veriyi getirir.
*/

// Method
var product4 = context.Products.FirstOrDefault(p=>p.CategoryId==1);

// Linq
var category4 = (from c in context.Categories
                where(c.Id == 1)
                select c).FirstOrDefault();
    
#endregion

#region Last()
/*
 * Tek veri getirir. Veri yoksa hata firlatir, birden fazla veri varsa son veriyi getirir.
*/

// Method
var product5 = context.Products.Last(p=>p.CategoryId==1);

// Linq
var category5 = (from c in context.Categories
                where(c.Id == 1)
                select c).Last();
    
#endregion

#region LastOrDefault()
/*
 * Tek veri getirir. Veri yoksa null dondurur, birden fazla veri gelirse son veriyi getirir.
*/

// Method
var product6 = context.Products.LastOrDefault(p=>p.CategoryId==1);

// Linq
var category6 = (from c in context.Categories
                where(c.Id == 1)
                select c).LastOrDefault();
    
#endregion

#region Find()
/*
 * PrimaryKey uzerinden sorgulama yapmayi saglar.
*/

// Method
int id = 1;
var product7 = context.Products.Find(id);

#endregion


/************************************* Diğer Sorguları ********************************/

#region Count()
/*
 * Veri adedini gosterir
*/

// Method
var product8 = context.Products.Count();

// Linq
var category8 = (from c in context.Categories
                select c).Count();
    
#endregion

#region LongCount()
/*
 * int tipinin yetmedigi buyuk Verilerin adedini gosterir
*/

// Method
var product9 = context.Products.LongCount();

// Linq
var category9 = (from c in context.Categories
                select c).LongCount();
    
#endregion

#region Any()
/*
 * Bir kosulun saglanip saglanmadigini kontrol eder. (Var mi? yok mu?)
*/

// Method
var product10 = context.Products.Where(x=>x.ProductName.Contains("a")).Any();
if(product10)Console.WriteLine("Product name has a");

// Linq
var category10 = (from c in context.Categories
                 where c.Id == 1000
                 select c).Any();
if(!category10) Console.WriteLine("Product is not exist");
    
#endregion

#region Max()
/*
 * En buyuk degeri getirir.
*/

// Method
var product11 = context.Products.Max(p=>p.Price);

// Linq
var product12 = (from p in context.Products
                 select p).Max(p=>p.Price);

#endregion

#region Min()
/*
 * En kucuk degeri getirir.
*/

// Method
var product13 = context.Products.Min(p=>p.Price);

// Linq
var product14 = (from p in context.Products
                 select p).Min(p=>p.Price);

#endregion

#region Distinct()
/*
 * Tekrarli kayitlari bir kere gosterir
*/

// Method
var product15 = context.Products.Distinct().ToList();

// Linq
var product16 = (from p in context.Products
                 select p).Distinct().ToList();

#endregion

#region All()
/*
 * Sorgu neticesinde tum verilerin ilgili kosula uyup uymadigini kontrol eder.
*/

// Method
bool product17 = context.Products.All(x=>x.Price > 1);
if(product17) Console.WriteLine("Product pricies are than greather 1");


#endregion

#region Sum()
/*
 * Verilerin toplama degerini gosterir.
*/

// Method
decimal product18 = context.Products.Sum(p=>p.Price);

#endregion

#region Averange()
/*
 * Verilerin aritmetik ortalama degerini gosterir.
*/

// Method
decimal product19 = context.Products.Average(p=>p.Price);

#endregion

#region Contains()
/*
 * Parametre olarak verilen degerin veri icerisinde bulunup bulunmadigini sorgular.
*/

// Method
bool product20 = context.Products.Any(x=>x.ProductName.Contains("note"));
var product21 = context.Products.Where(x=>x.ProductName.Contains('a')).ToList();

#endregion

#region StartsWith()
/*
 * Parametre olarak verilen degerle baslayan kayitlari getirir.
*/

// Method
bool product22 = context.Products.Any(x=>x.ProductName.StartsWith("note"));
var product23 = context.Products.Where(x=>x.ProductName.StartsWith('A')).ToList();

#endregion

#region EndsWith()
/*
 * Parametre olarak verilen degerle biten kayitlari getirir.
*/

// Method
bool product24 = context.Products.Any(x=>x.ProductName.EndsWith("book"));
var product25 = context.Products.Where(x=>x.ProductName.EndsWith('z')).ToList();

#endregion

#region GroupBy()
/*
 * Gruplama yapmayi saglar.
*/

// Method
var product31 = context.Products.GroupBy(x=>x.Price).Select(group => new{
    count = group.Count(),
    Price = group.Key
}).ToList();

// Linq
var product32 = (from p in context.Products
                group p by p.Price
                into  grup 
                select new
                {
                    Count = grup.Count(),
                    Price = grup.Key
                }).ToList();

#endregion



/************************************* Sorgu Sonuçlarini Farkli Tiplere Donüştüren Sorgular ********************************/

#region ToDictionary()
/*
 * Sorgu sonucunda elde edilen veriler Dictionary tipine donusturulur.
 * Gelen sorguyu Dictionary turunden gosterir.
*/

// Method
var product26 = context.Products.ToDictionary(x=>x.Id, x=>x.ProductName); // Key-Value
foreach (var item in product26)
{
    Console.WriteLine(item.Key +" "+ item.Value);
}

#endregion

#region ToArray()
/*
 * Sorgu sonucunda elde edilen veriler Array tipine donusturulur.
*/

// Method
var product27 = context.Products.ToArray();
foreach (var item in product27)
{
    Console.WriteLine(item.ProductName);
}

#endregion

#region Select()
/*
 * Sorgulanan verilerin belli alanlarini getirmek icin kullanilir.
*/

// Method
var product28 = context.Products.Select(x=> new {id = x.Id, name=x.ProductName}).ToList();
var product29 = context.Products.Where(x=>x.Id == 2).Select(y=> new Product {Id = y.Id , ProductName = y.ProductName, Price = y.Price}).SingleOrDefault();

#endregion

#region SelectMany()
/*
 * Sorgulanan verileri iliskisel verileriyle birlikte getirmek icin kullanilir.
*/

// Method
var categories29 = context.Categories.SelectMany(c=>c.Products,(c,p)=> new {
    c.CategoryName,
    p.ProductName,
    p.Price
}).ToList();

// Linq
var products30 = (from p in context.Products
                 join c in context.Categories
                 on p.CategoryId equals c.Id
                 select new
                 {
                    p.ProductName, 
                    p.Price,
                    c.CategoryName
                 }).ToList();

products30.ForEach(item=>{
    Console.WriteLine(item.ProductName + item.CategoryName + item.Price);
});

#endregion




/*
List<Category> categories = new()
{
    new Category {CategoryName = "Telefon"},
    new Category {CategoryName = "Notebook"},
    new Category {CategoryName = "Tablet"}
}; 


List<Product> products = new ()
{
    new Product {CategoryId = 1, ProductName="IPhone 13", Price=30000},
    new Product {CategoryId = 2, ProductName="MacBook Pro", Price=40000},
    new Product {CategoryId = 1, ProductName="IPad Air 4", Price=12000},
};

if(!context.Categories.Any() && !context.Products.Any())
{
    context.Categories.AddRange(categories);
    context.AddRange(products);
    context.SaveChanges();
    Console.WriteLine("Urunler Veri tabanina eklendi");
}
else Console.WriteLine("Urunler mevcut");
*/