using AutoMapper;
using be_api_shop01.Entities;
using be_api_shop01.Extension;
using be_api_shop01.IRepository;
using be_api_shop01.Models.Common;
using be_api_shop01.Models.User;
using Microsoft.EntityFrameworkCore;

namespace be_api_shop01.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<long> Authenticaticate(LoginModel login)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.username == login.username);
            if (user == null)
            {
                return 0; // Người dùng không tồn tại
            }

            var hashedPassword = Security.MD5Hash(login.password);
            if (user.password == hashedPassword)
            {
                return user.id; // Đăng nhập thành công
            }
            else
            {
                return -1; // Sai mật khẩu
            }
        }


        public async Task<bool> ChangeUserPassword(ChangePassModel passChange)
        {
            try
            {
                var user = await _context.User.FindAsync(passChange.id);
                if (user == null)
                {
                    return false;
                }

                if (user.password != Security.MD5Hash(passChange.Oldpassword))
                {
                    return false;
                }

                user.password = Security.MD5Hash(passChange.Newpassword);
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                // Xử lý lỗi nếu cần
                return false;
            }
        }



        public async Task<User> CheckUser(string username)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.username == username);
        }

        public async Task<int> CheckUserExists(string username,  string email)
        {
            var userCount = await _context.User.CountAsync(u => u.username == username || u.email == email);

            return userCount;
        }

        public async Task<UserModel> CreateUser(UserModel userAdd)
        {
            var existingUser = await _context.User.FirstOrDefaultAsync(u => u.username == userAdd.username || u.email == userAdd.email);
            if (existingUser != null)
            {
                return null;
            }

            var newUser = _mapper.Map<User>(userAdd);
            newUser.password = Security.MD5Hash(userAdd.password);
            newUser.dateAdded = DateTime.UtcNow;

            _context.User.Add(newUser);
            await _context.SaveChangesAsync();

            var userModel = _mapper.Map<UserModel>(newUser);
            return userModel;
        }

        public async Task<bool> DeleteUser(long id)
        {
            var users = await _context.User.FindAsync(id);
            if (users == null)
            {
                return false;
            }

            _context.User.Remove(users);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<UserModel> GetUserById(long id)
        {
            var users = await _context.User.FindAsync(id);

            if(users == null)
            {
                return null;
            }   

            var usersModel = _mapper.Map<UserModel>(users);
            return usersModel;
        }

        public async Task<List<UserModel>> GetUserList()
        {
            var users = await _context.User.ToArrayAsync();
            var userModels = _mapper.Map<List<UserModel>>(users);

            userModels = userModels.OrderByDescending(u => u.dateAdded).ToList();
            return userModels;
        }

        public async Task<UserModel> ModifyUser(UserModel userModify)
        {
            var user = await _context.User.FirstOrDefaultAsync(r => r.id == userModify.id);

            if (user == null)
            {
                return null; // Trả về null nếu không tìm thấy người dùng
            }

            user.address = userModify.address;
            user.email = userModify.email;
            user.phone = userModify.phone;
            user.fullname = userModify.fullname;
            user.avatar = userModify.avatar;
            user.dateAdded = DateTime.Now;

            _context.User.Update(user);
            await _context.SaveChangesAsync();

            UserModel userModel = _mapper.Map<UserModel>(user);
            return userModel;
        }

    }
}       