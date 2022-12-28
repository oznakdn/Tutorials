namespace _20_ComplexQueryOperators.Entities
{
    public class Photo
    {

        public int PersonId { get; set; }
        public string Url { get; set; }
        public Person Person { get; set; }

    }
}