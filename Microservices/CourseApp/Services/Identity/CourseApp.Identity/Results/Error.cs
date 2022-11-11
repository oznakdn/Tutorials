namespace CourseApp.Identity.Results
{
    public class Error
    {
        public List<string> Errors { get; private set; }

        public Error(string error)
        {
            Errors.Add(error);
        }
        public Error(List<string>errors)
        {
            Errors = errors;
        }
    }
}
