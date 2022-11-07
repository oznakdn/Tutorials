using System.Text.Json.Serialization;

namespace CourseApp.Shared.Results
{
    public class NoContentResponse
    {

        [JsonIgnore]
        public int StatusCode { get; private set; }

        [JsonIgnore]
        public bool IsSuccessful { get; private set; }

        public static NoContentResponse Success(int statusCode)
        {
            return new NoContentResponse
            {
                StatusCode = statusCode,
                IsSuccessful = true
            };
        }
    }
}
