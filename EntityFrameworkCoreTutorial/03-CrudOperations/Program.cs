
/*
 * ChangeTracker, context uzerinden gelen verilerin takibinden sorumludur. Herhangi bir degisiklik oldugunda bunu db'ye bildirir.
    var updatedProduct = context.Products.SingleOrDefault(p=>p.ProductId == 1);
    context.Entr(updatedProduct).State = EntityState.Modified;
    context.SaveChanges();
 * Degisiklik yapilacak bir Veri context'den gelmediyse (changeTracker mekanizmasi devre disi) yeni bir nesne olusturup primarykey bilgisi verilmelidir.
    Product product = new Product {Id=1};
    context.Entry(product).State = EntityState.Deleted;
    context.SaveChanges();
 * EntityState = Bir entity instance'inin durumunu gosteren referanstir. ChangeTracker mekanizmasi, degisiklikleri bu mekanizmadan takip eder.
*/




using _03_CrudOperations.Data;
using _03_CrudOperations.Entities;
using _03_CrudOperations.Operations;

IProductOperation operation = new ProductOperation(new NorthwindContext());


#region Create

// One Add
operation.Add(new Product { ProductName = "Coffee", CategoryId = 1, Discontinued = false, UnitsInStock = 10, UnitPrice = 40 });

// More Add

var newProducts = new List<Product>
{
    new Product {ProductName = "Ice Tea", CategoryId=1, UnitsInStock=100, UnitPrice = 15},
    new Product {ProductName = "Apple Juice", CategoryId=1, UnitsInStock=100, UnitPrice = 12},
    new Product {ProductName = "Tea", CategoryId=1, UnitsInStock=100, UnitPrice = 30}
};
operation.AddRange(newProducts);

#endregion

#region Read

// Get All
var products = operation.GetAll();
foreach (Product product in products)
{
    System.Console.WriteLine($"Id : {product.ProductId} ProductName : {product.ProductName} CategoryId: {product.CategoryId} Discontinued: {product.Discontinued}");
}

// Get One
var oneProduct = operation.Get(10);
Console.Write(oneProduct.ProductName);
#endregion

#region Update

// Update One
var updateProduct = operation.Get(1087);
updateProduct.ProductName = "Cola";
operation.Update(updateProduct);

// Update More
var product1091 = operation.Get(1091);
product1091.ProductName = "Ananas Juice";
var product1092 = operation.Get(1092);
product1092.ProductName="Tomato Juice";

List<Product>updateProducts = new()
{
    product1091,product1092

};
operation.UpdateRange(updateProducts);

#endregion

#region Delete

// Remove More

var product1080 = operation.Get(1080);
var product1081 = operation.Get(1081);
var product1082= operation.Get(1082);
var product1083= operation.Get(1083);
var product1085= operation.Get(1085);
var product1086= operation.Get(1086);

var deleteProducts = new List<Product>
{
    product1080,product1081,product1082,product1083,product1085,product1086
};

// Other Remove More
var deleteProductList = operation.GetAll();
operation.DeleteRange(deleteProductList,1079,1087);


// Remove One

var product1084= operation.Get(1084);
operation.Delete(product1084);

operation.RemoveRange(deleteProducts);



#endregion
