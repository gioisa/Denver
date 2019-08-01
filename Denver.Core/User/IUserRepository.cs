using Denver._Model.UserModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Denver.Core.User
{
    public interface IUserRepository
    {
        Task<UserModel> Login(string username, string passowrd);
        Task<UserModel> Regist(UserModel user);

    }
}
