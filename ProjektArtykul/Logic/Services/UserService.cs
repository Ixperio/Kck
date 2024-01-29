using Logic.Services.Interfaces;
using Logic.Repos.Intrefaces;
using Logic.Dto.User;
using Logic.Enums;
using DB.Entities;
using DB;
using System.Text;
using System.Security.Cryptography;
using System.Web;
using System.Net.Http;
using System.Diagnostics.SymbolStore;

namespace Logic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        
        }

        //pobranie listy wszystkich użytkownikow
        public List<User> GetList()
        {
            var users = userRepository.GetAll();
            var result = new List<User>();
            foreach (var user in users)
            {
                result.Add(new User()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    Rola = user.Rola,
                    HavingAvatar = user.HavingAvatar
                });
            }
            return result;
        }
        //usuniecie z repozytorium konkretnego artykułu
        public UserDeleteStatus Delete(int id)
        {
            if (userRepository.Delete(id) == true)
            {
                return UserDeleteStatus.Ok;
            }
            else
            {
                return UserDeleteStatus.UserCannotBeDeleted;
            }
            
        }
        //funkcja zwraca true/false w zależności od pozwolenia na usunięcie.
        private bool CheckCanDeleteUser(int id)
        {
            return true;
        }

        public User GetUser(int id)
        {
            return userRepository.GetUser(id);
        }

        public bool UpdateRole(int id, int role)
        {

            var usr =  userRepository.GetUser(id);

            if (usr != null)
            {
                return userRepository.UpdateRole(id, role);
            }
            else
            {
                return false;
            }

        }

        public List<User> GetAllUserAdmin()
        {
            //sprawdzic czy sesja jest adminem

            var users = userRepository.GetAll();
            var result = new List<User>();
            foreach (var user in users)
            {
                result.Add(new User()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    Password = user.Password,
                    Rola = user.Rola,
                    HavingAvatar = user.HavingAvatar
                });
            }
            return result;
        }

        public User GetUserByEmail(string email)
        {
            return userRepository.GetUserByEmail(email);
        }
        //dodawnaie do repozytorium
        public int Add(UserAddDto user)
        {
            //sprawdzenie czy użytkownik podał podprawne dane
            if(user.Email == user.EmailConfirm)
            {
                if (user.Password == user.PasswordConfirm)
                {
                    //haszowanie hasła i dodanie do repozytorium
                    var hashedPassword = HashPassword(user.Password);
                    var newUser = new User()
                    {
                        Name = user.Name,
                        Surname = user.Surname,
                        Email = user.Email,
                        Password = hashedPassword,
                        Rola = DB.Enums.UserRole.User,
                        HavingAvatar = false

                    };
                    userRepository.Add(newUser);
                    return newUser.Id;
                }
            }
            return -1;
            
        }
        //logowanie uzytkownika
        public UserLoggedDto Login(UserLoginDto user)
        {
            if(user != null)
            {
                string userPassword = HashPassword(user.Password);
                var user2 = userRepository.GetUserByEmail(user.Email);
                if(user2 != null)
                {
                    if (user2.Password == userPassword)
                    {
                        return new UserLoggedDto() { Id = user2.Id, Name = user2.Name, Surname = user2.Surname, Email = user2.Email, Role = user2.Rola, Havingavatar = user2.HavingAvatar };

                    }
                }
                return null;
            }
            return null;
        }

        //aktualizacja w repozytorium
        public bool Update(int id, UserEditDto user)
        {
            var existingUser = userRepository.GetUser(id);
            if(existingUser == null)
            {
                return false;
            }
            existingUser.Name = user.Name;
            existingUser.Surname = user.Surname;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.Rola = user.Role;
            existingUser.HavingAvatar = user.Havingavatar;
            userRepository.Update(existingUser);
            return true;
        }

        //hashowanie haseł
        public string HashPassword(string password)
        {
            using (SHA256 sha256 = new SHA256Managed())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    builder.Append(hash[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

    }
}
