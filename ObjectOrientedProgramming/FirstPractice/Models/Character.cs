using System.ComponentModel;

namespace FirstPractice.Models;


// Inheritance
public class Character : CharacterMonsterSpec
{

    public Character(CharacterType characterType, Racia racia, int caharacterLevel)
    {
        this.CharacterLevel = caharacterLevel;
        this.MaxHealth = 100;
        this.MaxEnergy = 50;
        this.CharacterType = characterType;
        this.Racia = racia;

        characterType.StateDefinition(this);
        racia.StateDefinition(this);

    }

    [DisplayName("Character Name")]
    public override string Name { get; set; }
    public int CharacterLevel { get; set; }
    public CharacterType CharacterType { get; set; }
    public Racia Racia { get; set; }


    public int Power { get; set; } // guc
    public int Agility { get; set; } // ceviklik
    public int Volition { get; set; } // irade
    public int Durability { get; set; } // dayaniklilik

    // Encapsulation
    // Polymorphism

    private int _maxHealth;
    public override int MaxHealth
    {
        get => _maxHealth;
        set
        {
            if (CharacterLevel == 1 && value == 100)
            {
                _maxHealth = value;
            }
            else if (CharacterLevel > 1 && value > 100)
            {
                _maxHealth = (CharacterLevel * 2) + value;
            }
            else
            {
                Console.WriteLine("Hatali giris!");
                _maxHealth = 100;
            }
        }
    }

    private int _maxEnergy;
    public override int MaxEnergy
    {
        get
        {
            if (CharacterLevel == 1 && MaxEnergy != 50)
                throw new Exception("Karakterin enerji seviyesi tutarsiz!");

            return _maxEnergy;
        }
        set
        {
            if (CharacterLevel == 1 && value == 50)
            {
                _maxEnergy = value;
            }
            else if (CharacterLevel > 1 && value > 100)
            {
                _maxEnergy = value;
            }
            else
            {
                throw new Exception("Karakter enerji seviyesi tutarsiz.");
            }
        }
    }


    public override int CloseAttack()
    {
        return base.CloseAttack() + Power + CharacterLevel;
    }

    public override int SpecificAttac()
    {
        throw new NotImplementedException();
    }
}
