using System.Text.Json.Serialization;

namespace CourseApp.Shared.Results
{
    public class Response<T>
    {
        // Disaridan set edilememesi icin private set yapildi. Set etme islemi Success static metodu ile yapilacak.
        public T Data { get; private set; }

        [JsonIgnore]
        public int StatusCode { get; private set; }

        [JsonIgnore]
        public bool IsSuccessful { get; private set; }

        public List<string> Errors { get; private set; }


        // Static Factory Methods

        /// <summary>
        /// Response basarili olma durumunda datayi doner
        /// </summary>
        /// <param name="data"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        public static Response<T> Success(T data, int statusCode)
        {
            return new Response<T>
            {
                Data = data,
                StatusCode = statusCode,
                IsSuccessful = true
            };
        }

        /// <summary>
        /// Response basarili oldugunda datayi donmez
        /// </summary>
        /// <param name="statusCode"></param>
        /// <returns></returns>

        public static Response<T> Success(int statusCode)
        {
            return new Response<T>
            {
                Data = default(T),
                StatusCode = statusCode,
                IsSuccessful = true
            };
        }

        /// <summary>
        /// Response basarisiz oldugunda hata listesi doner
        /// </summary>
        /// <param name="errors"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        public static Response<T> Fail(List<string> errors, int statusCode)
        {
            return new Response<T>
            {
                Errors = errors,
                StatusCode = statusCode,
                IsSuccessful = false
            };
        }

        /// <summary>
        /// Response basarisiz oldugunda tek bir hata doner
        /// </summary>
        /// <param name="error"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        public static Response<T> Fail(string error, int statusCode)
        {

            return new Response<T>
            {
                Errors = new List<string>() { error },
                StatusCode = statusCode,
                IsSuccessful = false
            };
        }



    }
}
