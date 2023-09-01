namespace be_api_shop01.Models.User
{
    public class UserTokenModel
    {
        public class UserCreateModel
        {
            public string username { get; set; }
            public string email { get; set; }
            public string password { get; set; }
            public string phone { get; set; } = string.Empty;
            public string fullname { get; set; }
            public string address { get; set; }
        }

        public class UserModifyModel
        {
            public long id { get; set; }
            public string email { get; set; }
            public string phone { get; set; } = string.Empty;
            public string fullname { get; set; }
            public string address { get; set; }
        }
    }
}
