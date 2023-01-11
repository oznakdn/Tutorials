namespace FirstLibrary
{
    public class Student
    {
        public string Name { get; set; }
        private string Surname { get; set; }
        internal int Age { get; set; }
        protected DateTime BirthDate { get; set; }
        protected internal string FatherName { get; set; }
        private protected string MotherName { get; set; }
    }


}