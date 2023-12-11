using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kasyno.Classes;
using System.IO;

namespace Kasyno.Repository.Controllers
{
    internal class UserController
    {
        private string dataFile = "C:\\Users\\alok1\\Desktop\\STUDIA\\SEM5\\kck\\KasynoGui\\KasynoBL\\Repository\\Data";
       
        private User FindUserByEmail(string email)
        {
            User user = null;

            try
            {
                string fileContent = File.ReadAllText(dataFile);

                Console.WriteLine(fileContent);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Plik nie zostął znaleziony!");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd: {ex.Message}");
            }

            return user;

        }

        public Boolean Register(string name, string surname, int age, string email, string confirmEmail, string password, string confirmPassword)
        {
            if ((password == confirmPassword) && (confirmEmail == email) && (age >= 18))
            {

                if (true)
                {
                    User user = new User();

                    user = user.Register(name, surname, age, email, password);

                    if(this.addUser(user, password))
                    {
                        return true;
                    }

                    return false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
            

        private int getLastUserId()
        {
            return 0;
        }
        private Boolean addUser(User user, string password)
        {
            string combine = Path.Combine(dataFile, "Users.txt");
            try
            {
                using (StreamWriter writer = new StreamWriter(combine, true))
                {
                   // Console.WriteLine($"Udało się otworzyć plik: {combine}");
                    writer.WriteLine(user.GetName() + ";" + user.GetSurname() + ";" + user.GetAge() + ";" +
                        user.GetEmail() + ";" + password + ";" + user.GetBalance());

                }
            }catch (Exception ex)
            {
                Console.WriteLine($"Nie udało się dodac uzytkownika do bazy : {ex.Message}");
                return false;
            }
          
            return true;

        }

        public List<User> OdczytajZPliku()
        {
            string sciezka = Path.Combine(dataFile, "Users.txt");

            List<User> uzytkownicy = new List<User>();

            if (File.Exists(sciezka))
            {
                using (StreamReader reader = new StreamReader(sciezka))
                {
                    string linia;
                    while ((linia = reader.ReadLine()) != null)
                    {
                        string[] split = linia.Split(';');
                        if (split.Length == 6)
                        {
                            User uzytkownik = new User();

                            uzytkownik.SetName(split[0]);
                            uzytkownik.SetSurname(split[1]);
                            uzytkownik.SetAge(int.Parse(split[2]));
                            uzytkownik.SetEmail(split[3]);
                            uzytkownik.SetPassword(split[4]);
                            uzytkownik.SetBalance(decimal.Parse(split[5]));
                           
                            uzytkownicy.Add(uzytkownik);
                        }
                    }
                }

                //Console.WriteLine("Dane użytkowników odczytane z pliku.");
            }
            else
            {
                //Console.WriteLine("Plik nie istnieje. Utworzono nowy plik.");
            }

            return uzytkownicy;
        }

        public void NadpiszPlik(User zaktualizowanyUzytkownik)
        {
            string sciezka = Path.Combine(dataFile, "Users.txt");

            List<User> uzytkownicy = OdczytajZPliku();

            // Znajdź indeks użytkownika, którego balance chcesz zaktualizować
            int indeks = uzytkownicy.FindIndex(u => u.GetEmail() == zaktualizowanyUzytkownik.GetEmail());

            if (indeks != -1)
            {
                // Zaktualizuj wartość Balance
                uzytkownicy[indeks].SetBalance(zaktualizowanyUzytkownik.GetBalance());

                // Zapisz zaktualizowaną listę do pliku
                ZapiszDoPliku(uzytkownicy);

                Console.WriteLine($"Zaktualizowano wartość Balance dla użytkownika {zaktualizowanyUzytkownik.GetName()}");
            }
            else
            {
                Console.WriteLine($"Użytkownik {zaktualizowanyUzytkownik.GetName()} nie został znaleziony.");
            }
        }

        public void ZapiszDoPliku(List<User> uzytkownicy)
        {
            string sciezka = Path.Combine(dataFile, "Users.txt");

            try
            {
                using (StreamWriter writer = new StreamWriter(sciezka))
                {
                    foreach (var uzytkownik in uzytkownicy)
                    {
                        writer.WriteLine($"{uzytkownik.GetName()};{uzytkownik.GetSurname()};{uzytkownik.GetAge()};{uzytkownik.GetEmail()};{uzytkownik.GetPassword()};{uzytkownik.GetBalance()}");
                    }
                }

                Console.WriteLine("Dane użytkowników zapisane do pliku.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd podczas zapisywania do pliku: {ex.Message}");
            }
        }

    }
}
