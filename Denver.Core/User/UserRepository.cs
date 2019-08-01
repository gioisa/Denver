using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Denver._Model.UserModel;
using Denver.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Denver.Core.User
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<UserModel> Login(string username, string password)
        {
            var usersLogin = await _context.UserModel.SingleOrDefaultAsync(x => x.Username == username && x.Password == password);

            if (usersLogin == null)
                return null;

            return usersLogin;

        }

        public async Task<UserModel> Regist(UserModel user)
        {
            await _context.UserModel.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;

        }
    }
}
