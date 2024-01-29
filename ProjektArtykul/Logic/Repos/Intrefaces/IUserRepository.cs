using DB;
using DB.Entities;

namespace Logic.Repos.Intrefaces
{
    public interface IUserRepository
    {
        List<User> GetAllByIds(List<int> ids);
        List<User> GetAll();
        User GetUser(int id);
        User GetUserByEmail(string email);
        bool Update(User user);
        bool UpdateRole(int id, int role);
        int Add(User user);
        bool Delete(int id);
    }
}
