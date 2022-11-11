namespace CourseApp.Identity.Results
{
    public class Response<T> where T : class
    {
        public T Data { get; private set; } = default!;
        public bool IsSuccessful { get; private set; }
        public int StatusCode { get; private set; }
        public Error Error { get; private set; } = default!;


        public static Response<T> Success(T data,int statusCode) => new Response<T> { Data = data, IsSuccessful = true, StatusCode = statusCode };
        public static Response<T> Success(int statusCode) => new Response<T> { StatusCode = statusCode };
        public static Response<T> Fail (Error error, int statusCode) => new Response<T> {Error=error, StatusCode = statusCode };
        public static Response<T> Fail(string errorMessage, int statusCode) => new Response<T> { Error = new(errorMessage), StatusCode = statusCode };
       
    }
}
