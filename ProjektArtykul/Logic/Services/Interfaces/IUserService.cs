using DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Dto.User;
using Logic.Enums;
using DB;

namespace Logic.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetList();
        List<User> GetAllUserAdmin();
        User GetUser(int id);
        UserLoggedDto Login(UserLoginDto user);
        User GetUserByEmail(string email);
        bool UpdateRole(int id, int role);
        UserDeleteStatus Delete(int id);
        int Add(UserAddDto user);
        bool Update(int id, UserEditDto user);
    }
}
