using System.ComponentModel;

namespace FirstPractice.Models
{
    // Bolge
    public class Region : BaseEntity
    {
        [DisplayName("Region Name")]
        public override string Name { get; set; }
        public float XCoordinate { get; set; }
        public float YCoordinate { get; set; }


        public Continent Continent { get; set; }
        public List<City> Cities { get; set; }
    }
}