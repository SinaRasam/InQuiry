using System.Net;

namespace InQuiry.Dto
{
    public class APIResult<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; } = true;
        public List<string> Messages { get; set; } = new List<string>();
        public T Result { get; set; }
    }
}
