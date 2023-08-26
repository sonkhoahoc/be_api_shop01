using be_api_shop01.Entities;
using be_api_shop01.Models.Common;
using be_api_shop01.Models.Customer;

namespace be_api_shop01.IRepository
{
    public interface ICustomerRepository
    {
        public Task<CustomerModel> GetCustomerById(long id);
        public Task<CustomerModel> CreateCustomer(CustomerModel userAdd);
        public Task<CustomerModel> ModifyCustomer(CustomerModel userModify);
        public Task<bool> ChangeCustomerPassword(ChangePassModel passChange);
        public Task<bool> DeleteCustomer(long id);
        public Task<List<CustomerModel>> GetCustomerList();
        public Task<long> CustomerLogin(LoginModel login);
        public Task<Customer> CheckCustomer(string username);
        public Task<int> CheckCustomerExists(string username, string phoneNumber, string email);
    }
}