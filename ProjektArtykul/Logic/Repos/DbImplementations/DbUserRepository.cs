using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;
using DB.Entities;
using DB.Enums;
using Logic.Repos.Intrefaces;

namespace Logic.Repos
{
    public class DbUserRepository : IUserRepository
    {
        //Kolekcja wprowadzająca do api testowy artykuł
        //user1 - tajnehaslo123
        private readonly MyDbContext _context;

        public DbUserRepository(MyDbContext context)
        {
            this._context = context;
           
        }

        //pobieranie pojedyńczego artykułu po id
        public User GetUser(int id)
        {
            var res = _context.Users.Where(x => x.Id == id && x.IsDeleted == false).SingleOrDefault();
            if(res == null)
            {
                return null;
            }
            return res;
        }
        //pobieranie wszystkich artykułów
        public List<User> GetAll()
        {
            return _context.Users.Where(x => x.IsDeleted == false).ToList();
        }
        //pobieranie artykułów po liście ich id
        public List<User> GetAllByIds(List<int> ids)
        {
            return _context.Users.Where(x => x.IsDeleted == false && ids.Contains(x.Id)).ToList();
        }
        public User GetUserByEmail(string email)
        {
            return _context.Users.Where(x => x.IsDeleted == false && email == x.Email).SingleOrDefault();
        }
        //update artykułu

        public bool UpdateRole(int id, int role)
        {
            var usr = this.GetUser(id);

            if(usr != null)
            {
                usr.Rola = (UserRole)role;
                _context.Users.Update(usr);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Update(User user)
        {
            if(this.GetUser(user.Id) != null)
            {
                _context.Users.Update(user);
                _context.SaveChanges();
                return true;

            }
            return false;

        }
        //dodanie artykułu
        public int Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.Id;
        }
        //usuwanie artykułu
        public bool Delete(int id)
        {
            User userToDelete = this.GetUser(id);
            if (userToDelete != null)
            {
                userToDelete.IsDeleted = true;
                _context.Users.Update(userToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;
            
        }

    }
}
