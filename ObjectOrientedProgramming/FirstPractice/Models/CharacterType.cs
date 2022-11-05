using FirstPractice.Interfaces;

namespace FirstPractice.Models;


// Inheritance
public class CharacterType : BaseEntity,IStat
{

    public CharacterType(string name)
    {
        this.Name = name;
    }


    public List<Character> Characters { get; set; } = new();

    public void StateDefinition(Character character) // Durum belirleme
    {
        switch (Name.ToLower())
        {

            case "warrior":
                character.Power = 3;
                character.Agility = 2;
                character.Durability = 3;
                character.Volition = 1; break;
            case "archer":
                character.Power = 2;
                character.Durability = 2;
                character.Agility = 3;
                character.Volition = 1; break;
            case "wizard":
                character.Power = 1;
                character.Durability = 1;
                character.Agility = 3;
                character.Volition = 2; break;
            case "paladin":
                character.Power = 3;
                character.Durability = 2;
                character.Agility = 3;
                character.Volition = 1; break;
            case "ninja":
                character.Power = 2;
                character.Durability = 2;
                character.Agility = 3;
                character.Volition = 2; break;
            default:
                Console.WriteLine("Character type not found");
                break;
        }

    }


}
