using AutoMapper;
using be_api_shop01.Entities;

using be_api_shop01.Models.Customer;
using be_api_shop01.Models.User;
using System.Security.Cryptography.X509Certificates;

namespace be_api_shop01.Mapper
{
    public class ApplicationMapper: Profile
    {
        public ApplicationMapper()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
            CreateMap<Customer, CustomerModel>();
            CreateMap<CustomerModel, Customer>();
        }
    }
}
