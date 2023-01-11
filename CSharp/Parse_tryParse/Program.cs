// Parse: Belirtilen veri tibini donusturebilirse donusturur, donusturemezse hata firlatir.
// TryParse: Belirtilen ifadeyi donusturebilirse true, donusturemezse false doner.

string numberOne = "10";
int numberTwo = int.Parse(numberOne);
Console.WriteLine(numberTwo);


string numberThree = "10";
bool numberFour = int.TryParse(numberThree, out int result);
Console.WriteLine(numberFour);
Console.WriteLine(result);