using be_api_shop01.Entities;
using be_api_shop01.Models.Common;
using be_api_shop01.Models.User;

namespace be_api_shop01.IRepository
{
    public interface IUserRepository
    {
        public Task<UserModel> GetUserById(long id);
        public Task<UserModel> CreateUser(UserModel userAdd);
        public Task<UserModel> ModifyUser(UserModel userModify);
        public Task<bool> ChangeUserPassword(ChangePassModel passChange);
        public Task<bool> DeleteUser(long id);
        public Task<List<UserModel>> GetUserList();
        public Task<long> Authenticaticate(LoginModel login);
        public Task<User> CheckUser(string username);
        public Task<int> CheckUserExists(string username, string email);
    }
}
