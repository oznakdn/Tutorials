namespace FirstPractice.Models;


// Abstraction
public abstract class CharacterMonsterSpec : BaseEntity
{
    public virtual int MaxHealth { get; set; }
    public virtual int MaxEnergy { get; set; }
    public int CurrentlyEnergy { get; set; }
    public int CurrentlyHealth { get; set; }
    public virtual int ExpriencePuan { get; set; }

    public virtual int CloseAttack()
    {
        return new Random().Next(1, 21);
    }

    public abstract int SpecificAttac();



}
