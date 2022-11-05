namespace FirstPractice.Models;


// Abstraction
public abstract class BaseEntity
{
    public BaseEntity()
    {
        CreatedDate = DateTime.Now;
    }
    public virtual string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
