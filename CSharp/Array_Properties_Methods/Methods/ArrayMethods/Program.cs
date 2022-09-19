



/**************** Array.Clear() ==> Öğe türüne bağlı olarak Array öğesindeki bir dizi öğeyi sıfıra, false veya null değere ayarlar. ***************/
using System.Security.Cryptography.X509Certificates;

int[] numbers = new int[] {1,5,3,14,29};
Array.Clear(numbers);
Console.WriteLine(numbers[2]); // 0

/**************** Copy(Array, Array, Int32) ==> İlk öğeden başlayarak bir Dizi öğesisi başka bir Diziye yapıştırır. ***************/
int[] numbers1 = new int[] {10,20,30,40,50};
int[] numbers2 = new int[numbers.Length];
Array.Copy(numbers1, numbers2, numbers.Length);
Console.WriteLine(numbers2[2]); // 30

/**************** CopyTo(Array, Int32) ==> Dizinin tüm öğelerini, belirtilen hedef diziye kopyalar. ***************/
int[] numbers3 = new int[] {10,20,30,40,50};
int[] numbers4 = new int[numbers3.Length];
numbers3.CopyTo(numbers4,0);
Array.ForEach(numbers4, item =>
{
    Console.WriteLine(item); // 10,20,30,40,50
});

/**************** GetLength() ==> Dizinin belirtilen boyutundaki öğelerin sayısını temsil eden 32 bitlik bir tamsayı alır. ***************/
int[,] numbers5 = new int[2,2] {{10,20}, {30,40}};
Console.WriteLine(numbers4.GetLength(0)); // 5


/**************** GetLowerBound() ==> Dizide belirtilen boyutun alt sınırını alır. ***************/
int[,] numbers6 = new int[2,3];
Console.WriteLine(numbers6.GetLowerBound(1)); // 0


/**************** GetType() ==> Geçerli örneğin Türünü alır. (Object öğesinden devralındı.) ***************/
int[] numbers7 = new int[] {1,2,3};
Console.WriteLine(numbers7.GetType()); // Int32[]


/**************** GetUpperBound() ==> Dizide belirtilen boyutun üst sınırını alır. ***************/
Console.WriteLine(numbers6.GetUpperBound(0)); // 1

/**************** GetValue(Int32) ==> Tek boyutlu Dizide belirtilen konumdaki değeri alır. Dizin, 32 bitlik bir tam sayı olarak belirtilir. ***************/
string[] names = new string[] {"Ahmet","Mehmet","Sevda","Buse"};
Console.WriteLine(names.GetValue(0)); // Ahmet

/**************** Array.IndexOf(Array, Object) ==> Belirtilen nesneyi arar ve tüm tek boyutlu Dizi içindeki ilk oluşumun dizinini döndürür. ***************/
 var result = Array.IndexOf(names,"Buse");
Console.WriteLine(result); // 3

/**************** Array.Reverse(Array) ==> Tek boyutlu Dizinin tamamındaki öğelerin sırasını tersine çevirir.***************/
Array.Reverse(names);
Array.ForEach(names, item =>
{
      Console.WriteLine(item); // Buse, Sevda , Mehmet, Ahmet
});

/**************** SetValue(Object, Int32) ==> Tek boyutlu Dizide belirtilen konumda öğeye bir değer ayarlar.***************/
names.SetValue("Veli",1);
Array.ForEach(names, item =>
{
    Console.WriteLine(item); // Buse, Veli, Mehmet, Ahmet
});

/**************** Array.Sort(Array) ==> Dizinin her bir öğesinin IComparable uygulamasını kullanarak tüm tek boyutlu Dizideki öğeleri sıralar.***************/
char[] letters = new char[] {'a','b','c','d'};
Array.Sort(letters);
Array.ForEach(letters, item =>
{
    Console.WriteLine(item); // a, b, c, d
});

/**************** Array.Exist() ==> Belirtilen dizinin, eşleşen öğeler içerip içermediğini belirler.***************/
string[] cities = new string[] {"Adana","Bursa","Çanakkale","Diyarbakır"};
bool existCity = Array.Exists(cities, c => c == "Bursa" || c.Contains("Adana"));
Console.WriteLine(existCity); // true

/**************** Array.Find() ==> Eşleşen bir öğe arar ve tüm Dizi içindeki ilk oluşumu döndürür.***************/
string findCity = Array.Find(cities, c=>c.Contains('a'));
Console.WriteLine(findCity); // Adana

/**************** Array.FindAll() ==> Belirtilen yüklem tarafından tanımlanan koşullarla eşleşen tüm öğeleri alır. ***************/
var findCities = Array.FindAll(cities, c=>c.Contains('k'));
Array.ForEach(findCities, item =>
{
    Console.WriteLine(item); // Çanakkale, Diyabakır
});

/**************** Array.FindIndex() ==>  Eşleşen ilk elemanın index'ini döndürür. ***************/
int findIndex = Array.FindIndex(cities,c=> c == "Çanakkale");
Console.WriteLine(findIndex); // 2














