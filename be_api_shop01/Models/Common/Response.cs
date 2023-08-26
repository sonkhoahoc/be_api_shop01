namespace be_api_shop01.Models.Common
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
    public class ChangePassModel
    {
        public long id { get; set; }
        public string Oldpassword { get; set; }
        public string Newpassword { get; set; }
    }

    public class LoginModel
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
