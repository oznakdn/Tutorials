namespace FirstPractice.Models;

public class Monster : CharacterMonsterSpec
{
    public Oubliette Oubliette { get; set; }

    public override int SpecificAttac()
    {
        throw new NotImplementedException();
    }
}
