using AutoMapper;
using be_api_shop01.Entities;
using be_api_shop01.Extension;
using be_api_shop01.IRepository;
using be_api_shop01.Models.Common;
using be_api_shop01.Models.Customer;
using Microsoft.EntityFrameworkCore;

namespace be_api_shop01.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public CustomerRepository(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<long> CustomerLogin(LoginModel login)
        {
            var customers = await _context.Customer.FirstOrDefaultAsync(c => c.username == login.username);
            if (customers == null)
            {
                return 0;
            }

            var hasPass = Security.MD5Hash(login.password);
            if (customers.password != hasPass)
            {
                return -1;
            }

            return customers.id;
        }

        public async Task<bool> ChangeCustomerPassword(ChangePassModel passChange)
        {
            try
            {
                var customers = await _context.Customer.FindAsync(passChange.id);
                if (customers == null)
                {
                    return false;
                }

                if (customers.password != Security.MD5Hash(passChange.Oldpassword))
                {
                    return false;
                }

                customers.password = Security.MD5Hash(passChange.Newpassword);
                _context.Entry(customers).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Customer> CheckCustomer(string username)
        {
            return await _context.Customer.FirstOrDefaultAsync(c => c.username == username);
        }

        public async Task<int> CheckCustomerExists(string username, string phoneNumber, string email)
        {
            var cusCount = await _context.Customer.CountAsync(c => c.username == username || c.phone == phoneNumber || c.email == email);
            return cusCount;
        }

        public async Task<CustomerModel> CreateCustomer(CustomerModel userAdd)
        {
            var existingCustomer = await _context.Customer.FirstOrDefaultAsync(c => c.username == userAdd.username || c.email == userAdd.email);
            if (existingCustomer != null)
            {
                return null;
            }

            var newCus = _mapper.Map<Customer>(existingCustomer);
            newCus.password = Security.MD5Hash(userAdd.password);
            newCus.dateAdded = DateTime.UtcNow;

            _context.Customer.Add(newCus);
            await _context.SaveChangesAsync();

            var cusModel = _mapper.Map<CustomerModel>(newCus);
            return cusModel;
        }

        public async Task<bool> DeleteCustomer(long id)
        {
            var customers = await _context.Customer.FindAsync(id);
            if (customers == null)
            {
                return false;
            }

            _context.Customer.Remove(customers);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<CustomerModel> GetCustomerById(long id)
        {
            var customers = await _context.Customer.FindAsync(id);

            if (customers == null)
            {
                return null;
            }

            var cusModel = _mapper.Map<CustomerModel>(customers);
            return cusModel;
        }

        public async Task<List<CustomerModel>> GetCustomerList()
        {
            var customers = await _context.Customer.ToListAsync();
            var customerModels = _mapper.Map<List<CustomerModel>>(customers);
            return customerModels;
        }

        public async Task<CustomerModel> ModifyCustomer(CustomerModel userModify)
        {
            var customer = await _context.Customer.FirstOrDefaultAsync(c => c.id == userModify.id);

            if (customer == null)
            {
                return null;
            }

            customer.address = userModify.address;
            customer.email = userModify.email;
            customer.phone = userModify.phone;
            customer.fullname = userModify.fullname;
            customer.dateAdded = DateTime.Now;

            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var customerModel = _mapper.Map<CustomerModel>(customer);
            return customerModel;
        }
    }
}
