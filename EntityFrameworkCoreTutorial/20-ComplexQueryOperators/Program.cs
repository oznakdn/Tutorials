using _20_ComplexQueryOperators.Context;


using AppDbContext dbContext = new();

#region Join
#region 1) Query Syntax

var query = (from photo in dbContext.Photos
             join person in dbContext.Persons
             on photo.PersonId equals person.PersonId
             select new
             {
                 person.Name,
                 photo.Url
             }).ToList();


// foreach (var item in query)
// {
//     Console.WriteLine(item.Name);
//     Console.WriteLine(item.Url);
// }

#endregion
#region 2) Method Syntax
var query1 = dbContext.Photos
                .Join(dbContext.Persons,
                photo => photo.PersonId,
                person => person.PersonId,
                (photo, person) => new
                {
                    person.Name,
                    photo.Url
                });

#endregion
#endregion

#region Multiple Columns Join
var query2 = (from photo in dbContext.Photos
              join person in dbContext.Persons
              on new { photo.PersonId, photo.Url }
              equals new { person.PersonId, Url = person.Name }
              select new
              {
                  person.Name,
                  photo.Url
              }).ToList();
#endregion

#region More than two tables Join
var query3 = (from photo in dbContext.Photos
              join person in dbContext.Persons
              on photo.PersonId equals person.PersonId
              join order in dbContext.Orders
              on person.PersonId equals order.PersonId
              select new
              {
                  person.Name,
                  person.Gender,
                  photo.Url,
                  order.Description
              }).ToList();

#endregion

#region Group Join
var query4 = (from person in dbContext.Persons
              join order in dbContext.Orders
              on person.PersonId equals order.PersonId
              into personOrders
              select new
              {
                  person.Name,
                  Count = personOrders.Count(),
                  personOrders
              }).ToList();

#endregion

#region Left Join
// Sorgulama surecinde iliskisel olarak karsiligi olmayan verilere default degerlerini yazdirir.
var query5 = (from person in dbContext.Persons
              join order in dbContext.Orders
              on person.PersonId equals order.PersonId
              into personOrders
              from order in personOrders.DefaultIfEmpty()
              select new
              {
                  person.Name,
                  order.Description
              }).ToList();
#endregion

#region Right Join
var query6 = (from order in dbContext.Orders
              join person in dbContext.Persons
              on order.PersonId equals person.PersonId
              into orderPersons
              from person in orderPersons.DefaultIfEmpty()
              select new
              {
                  person.Name,
                  order.Description
              }).ToList();

#endregion

#region Cross Join
var quiery7 = (from order in dbContext.Orders
               from person in dbContext.Persons
               select new
               {
                   order,
                   person
               }).ToList();

#endregion

#region Where

var query8 = (from order in dbContext.Orders
              from person in dbContext.Persons.Where(p => p.PersonId == order.PersonId)
              select new
              {
                  order,
                  person
              });

#endregion