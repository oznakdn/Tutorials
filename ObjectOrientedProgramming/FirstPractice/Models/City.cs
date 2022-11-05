using System.ComponentModel;

namespace FirstPractice.Models;


// Inheritance
public class City : BaseEntity
{

    [DisplayName("City Name")]
    public override string Name { get; set; }

    public List<Racia> Racias { get; set; }
    public Region Region { get; set; }
}
