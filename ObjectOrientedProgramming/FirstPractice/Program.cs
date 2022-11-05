using FirstPractice.Models;



CharacterType characterType = new("warrior");
Racia racia = new("human");


Character newCharacker = new(characterType, racia, 1);
Console.WriteLine(newCharacker.Volition);
Console.WriteLine(newCharacker.Agility);
Console.WriteLine(newCharacker.Power);
Console.WriteLine(newCharacker.Durability);



int attack = newCharacker.CloseAttack();
Console.WriteLine(attack);

