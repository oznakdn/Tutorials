namespace FirstPractice.Models
{

    // Zindan
    public class Oubliette : BaseEntity
    {
        public Region Region { get; set; }
        public City City { get; set; }
        public List<Monster> Monsters { get; set; }
        public List<EliteMonster> EliteMonsters { get; set; }
    }
}