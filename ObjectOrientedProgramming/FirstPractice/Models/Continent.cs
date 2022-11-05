using System.ComponentModel;

namespace FirstPractice.Models
{
    // Kita
    public class Continent : BaseEntity
    {
        [DisplayName("Continent Name")]
        public override string Name { get; set; }

        public List<Region> Regions { get; set; }

    }
}