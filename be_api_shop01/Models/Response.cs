namespace be_api_shop01.Models
{

    public interface IResponseData
    {

    }

    public class ResponseMessageModel<T>
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public T Data { get; set; }
    }

    public class Response
    {
    }
}
