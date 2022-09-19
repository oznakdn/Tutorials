
string[] fruits = new string[]
{
    "Apple", "Banana", "Strawberry" , "Pear"
};


/**************** IsFixedSize ==> Dizinin sabit bir boyutu olup olmadığını gösteren bir değer alır.*****************/
Console.WriteLine(fruits.IsFixedSize); // True

/**************** IsReadOnly ==> Dizinin salt okunur olup olmadığını gösteren bir değer alır. *****************/
Console.WriteLine(fruits.IsReadOnly); // False

/**************** Length ==> Dizinin tüm boyutlarındaki toplam öğe sayısını temsil eden 32 bitlik bir tamsayı alır. *****************/
Console.WriteLine(fruits.Length); // 4

/**************** LongLength ==> Dizinin tüm boyutlarındaki toplam öğe sayısını temsil eden 64 bitlik bir tamsayı alır. *****************/
Console.WriteLine(fruits.LongLength); // 4

/**************** Rank ==> Dizinin derecesini (boyut sayısı) alır. *****************/
Console.WriteLine(fruits.Rank); // 1







