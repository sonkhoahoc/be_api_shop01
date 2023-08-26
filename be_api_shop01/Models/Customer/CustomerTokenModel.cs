namespace be_api_shop01.Models.Customer
{
    public class CustomerCreateModel
    {
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; } = string.Empty;
        public string fullname { get; set; }
        public string address { get; set; }
        public string avatar { get; set; }
    }

    public class CustomerModifyModel
    {
        public long id { get; set; }
        public string email { get; set; }
        public string phone { get; set; } = string.Empty;
        public string fullname { get; set; }
        public string address { get; set; }
        public string avatar { get; set; }
    }

}
