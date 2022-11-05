using System.ComponentModel;
using FirstPractice.Interfaces;

namespace FirstPractice.Models;


// Inheritance
public class Racia : BaseEntity, IStat
{

    public Racia(string name)
    {
        this.Name = name;
        switch (Name.ToLower())
        {
            case "human":
                VolitionModification = 1; break;
            case "elf":
                AgilityModification = 1; break;
            case "org":
                PowerModification = 2; break;
            case "dwarf":
                DurabilityModification = 2; break;
            case "undead":
                PowerModification = 3;
                VolitionModification = 1; break;
        }
    }



    [DisplayName("Racia Name")]
    public override string Name { get; set; }

    public int PowerModification { get; set; } // guc modifikasyonu
    public int AgilityModification { get; set; } // ceviklik modifikasyonu
    public int VolitionModification { get; set; } // irade modifikasyonu
    public int DurabilityModification { get; set; } // dayaniklilik modifikasyonu

    public City StartCity { get; set; }
    public List<Character> Characters { get; set; }


    public void StateDefinition(Character character)
    {
        switch (Name.ToLower())
        {
            case "human":
                character.Volition = VolitionModification;
                break;
            case "elf":
                character.Agility = AgilityModification;
                break;
            case "org":
                character.Power = PowerModification;
                break;
            case "dwarf":
                character.Durability = DurabilityModification;
                break;
            case "undead":
                character.Power = PowerModification;
                character.Volition = VolitionModification;
                break;
            default:
                Console.WriteLine("Racia not found!");
                break;
        }

    }

}
