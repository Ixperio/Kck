using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Kasyno.Classes.Games;
using Kasyno.Repository.Controllers;

namespace Kasyno.Classes
{
    internal class Information
    {
        UserController _userController = new UserController();

        public void InfoFrame(string info,int odstep)
        {    
            if(odstep <=0 || odstep > 8) {
                odstep = 2;
            }
           
            int length = info.Length;

            for (int i = 0; i < length + (2 * odstep + 2); i++)
            {
                Console.Write("*");
            }
            Console.Write("\n");
            for (int j = 0; j < odstep; j++)
            {
                for (int i = 0; i < length + (2 * odstep + 2); i++)
                {
                    if (i == 0 || i == (length + (2 * odstep + 2)) - 1)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write("\n");
            }
            Console.Write("*");
            for (int j = 0; j < odstep; j++)
            {
                Console.Write(" ");
            }
            Console.Write(info);
            for (int j = 0; j < odstep; j++)
            {
                Console.Write(" ");
            }
            Console.Write("*\n");
            for (int j = 0; j < odstep; j++)
            {
                for (int i = 0; i < length + (2 * odstep + 2); i++)
                {
                    if (i == 0 || i == (length + (2 * odstep + 2)) - 1)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write("\n");
            }
            for (int i = 0; i < length + (2 * odstep + 2); i++)
            {
                Console.Write("*");
            }
            Console.Write("\n");
        }

        public void InfoFrame(string info, int odstepX, int odstepY)
        {
            if (odstepX <= 0)
            {
                odstepX = 2;
            }
            if (odstepY <= 0)
            {
                odstepY = 2;
            }

            int length = info.Length;

            for (int i = 0; i < length + (2 * odstepX + 2); i++)
            {
                Console.Write("*");
            }
            Console.Write("\n");
            for (int j = 0; j < odstepY; j++)
            {
                for (int i = 0; i < length + (2 * odstepX + 2); i++)
                {
                    if (i == 0 || i == (length + (2 * odstepX + 2)) - 1)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write("\n");
            }
            Console.Write("*");
            for (int j = 0; j < odstepX; j++)
            {
                Console.Write(" ");
            }
            Console.Write(info);
            for (int j = 0; j < odstepX; j++)
            {
                Console.Write(" ");
            }
            Console.Write("*\n");
            for (int j = 0; j < odstepY; j++)
            {
                for (int i = 0; i < length + (2 * odstepX + 2); i++)
                {
                    if (i == 0 || i == (length + (2 * odstepX + 2)) - 1)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write("\n");
            }
            for (int i = 0; i < length + (2 * odstepX + 2); i++)
            {
                Console.Write("*");
            }
            Console.Write("\n");
        }
        public void FrameMulti(List<string> naglowki, int odstepX, int odstepY, List<string> dane) {

            int minLength = 0;
                
                foreach(string naglowek in naglowki)
                {
                    if(naglowek.Length > minLength)
                    {
                        minLength = naglowek.Length;
                    }
                }
            minLength += (2 * odstepX)+1;

            for (int i = 0;i<(minLength*naglowki.Count())+1;i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();

            for(int i = 0;i<odstepY/2; i++)
            {
                for (int j = 0; j <= (minLength * naglowki.Count()); j++)
                {
                    if(j%minLength == 0)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                    
                }
                Console.WriteLine();
            }
            Console.Write("*");
            foreach(string naglowek in naglowki)
            {
                for(int i=0;i< (minLength - naglowek.Length)/2; i++)
                {
                    Console.Write(" ");
                }
                Console.Write(naglowek.ToString());
                if (((minLength - naglowek.Length) / 2) * 2 + naglowek.Length < minLength)
                {
                    for (int i = 0; i < (minLength - naglowek.Length) / 2; i++)
                    {
                        Console.Write(" ");
                    }
                }
                else
                {
                    for (int i = 0; i < ((minLength - naglowek.Length) / 2) - 1; i++)
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write("*");
            }
            Console.WriteLine();
            Console.Write("*");
            foreach (string dana in dane)
            {
                for (int i = 0; i < (minLength - dana.Length) / 2; i++)
                {
                    Console.Write(" ");
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(dana.ToString());
                Console.ResetColor();
                if(((minLength - dana.Length)/2)*2 + dana.Length < minLength)
                {
                    for (int i = 0; i < (minLength - dana.Length) / 2; i++)
                    {
                        Console.Write(" ");
                    }
                }
                else
                {
                    for (int i = 0; i < ((minLength - dana.Length) / 2)-1; i++)
                    {
                        Console.Write(" ");
                    }
                }
                
                Console.Write("*");
            }
            Console.WriteLine();
            for (int i = 0; i < odstepY / 2; i++)
            {
                for (int j = 0; j <= (minLength * naglowki.Count()); j++)
                {
                    if (j % minLength == 0)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                }
                Console.WriteLine();
            }
            for (int i = 0; i < (minLength * naglowki.Count())+1; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }

        public void SelectFrame(List<string> buttons, int odstepX, int  odstepY, int nrPodswietlenia)
        {
            //ustalenie najdluzszej tresci
            int minLength = 0;

            foreach (string tresc in buttons)
            {
                if (tresc.Length > minLength)
                {
                    minLength = tresc.Length;
                }
            }

            for(int i=0; i < minLength + (odstepX*2)+2; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();

            for(int j=0; j<odstepY; j++)
            {
                Console.Write("*");
                for (int i = 0; i < (minLength + (odstepX*2)); i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("*");
            }
            int p=0;
            foreach(string tresc in buttons)
            {
                Console.Write("*");
                for(int j= 0; j < ((minLength-tresc.Length)/2)+odstepX; j++)
                {
                    Console.Write(" ");
                }
                if (p == nrPodswietlenia)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(tresc);
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(tresc);
                }
                for (int j = 0; j < ((minLength - tresc.Length)/2) + odstepX; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("*");
                p++;
            }

            for (int j = 0; j < odstepY; j++)
            {
                Console.Write("*");
                for (int i = 0; i < (minLength + (odstepX * 2)); i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("*");
            }
            for (int i = 0; i < minLength + (odstepX * 2)+2; i++)
            {
                Console.Write("*");
            }

        }
        public void LoginForm()
        {
            string email;
            string password;
            do
            {  
                Console.Clear();
                this.InfoFrame("Wprowadź dane do logowania", 2);
                Console.Write("Podaj email : ");
                email = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("Podaj hasło : ");


            } while (string.IsNullOrWhiteSpace(email));

            do
            {
                Console.Clear();
                this.InfoFrame("Wprowadź dane do logowania", 2);
                Console.WriteLine("Podaj email : "+email);
                Console.Write("Podaj hasło : ");
                string password2 = "";
                ConsoleKeyInfo key;
                do
                {
                    key = Console.ReadKey(true);

                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        password2 += key.KeyChar;
                        Console.Write("*");
                    }
                    else if (key.Key == ConsoleKey.Backspace && password2.Length > 0)
                    {
                        password2 = password2.Substring(0, password2.Length - 1);
                        Console.Write("\b \b");
                    }
                } while (key.Key != ConsoleKey.Enter);

                password = password2.ToString();

                if (string.IsNullOrWhiteSpace(password))
                {
                    Console.WriteLine("Pole hasło nie może być puste! Spróbuj ponownie.");
                }

            } while (string.IsNullOrWhiteSpace(password));

            List<User> users = new List<User>();
            users = _userController.OdczytajZPliku();

            User uzytkownik = users.Find(u => u.GetEmail() == email);

            if(uzytkownik != null)
            {
                if (uzytkownik.ComparePassword(password))
                {
                    this.StartMenu(uzytkownik);
                }
            }
            else
            {
                this.LoginForm();
            }

           
            
        }

        public void RegisterForm()
        {
           
            string name;
            string surname;
            int age;
            string email;
            string emailConfirm;
            string password;
            string passwordConfirm;
            string userInput;
            do
            {
                Console.Clear();
                InfoFrame("Witaj w formularzu rejestracji, wprowadź dane poniżej",2);

                Console.Write("Podaj swoje imię: ");
                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Imie nie może być puste! Spróbuj ponownie.");
                }

            }while (string.IsNullOrWhiteSpace(name));

            do
            {
                Console.Clear();
                InfoFrame("Witaj w formularzu rejestracji, wprowadź dane poniżej", 2);

                Console.Write("Podaj swoje nazwisko: ");
                surname = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(surname))
                {
                    Console.WriteLine("Nazwisko nie może być puste! Spróbuj ponownie.");
                }

            } while (string.IsNullOrWhiteSpace(surname));

            do
            {
                Console.Clear();
                InfoFrame("Witaj w formularzu rejestracji, wprowadź dane poniżej", 2);

                Console.Write("Zadeklaruj swój wiek: ");
                userInput = Console.ReadLine();

                int.TryParse(userInput, out age);

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("Pole wiek nie może być puste! Spróbuj ponownie.");
                }

            } while (string.IsNullOrWhiteSpace(userInput));

            do
            {
                Console.Clear();
                InfoFrame("Witaj w formularzu rejestracji, wprowadź dane poniżej", 2);

                Console.Write("Podaj swoj email: ");
                email = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(email))
                {
                    Console.WriteLine("Pole email nie może być puste! Spróbuj ponownie.");
                }

            } while (string.IsNullOrWhiteSpace(email));

            do
            {
                Console.Clear();
                InfoFrame("Witaj w formularzu rejestracji, wprowadź dane poniżej", 2);

                Console.Write("Potwierdź eamil: ");
                emailConfirm = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(emailConfirm))
                {
                    Console.WriteLine("Pole potwierdź email nie może być puste! Spróbuj ponownie.");
                }

            } while (string.IsNullOrWhiteSpace(emailConfirm));

            do
            {
                Console.Clear();
                InfoFrame("Witaj w formularzu rejestracji, wprowadź dane poniżej", 2);

                Console.Write("Wprowadź swoje hasło: ");

                string password2 = "";
                ConsoleKeyInfo key;
                do
                {
                    key = Console.ReadKey(true);

                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        password2 += key.KeyChar;
                        Console.Write("*");
                    }
                    else if (key.Key == ConsoleKey.Backspace && password2.Length > 0)
                    {
                        password2 = password2.Substring(0, password2.Length - 1);
                        Console.Write("\b \b"); 
                    }
                } while (key.Key != ConsoleKey.Enter);

                password = password2.ToString();

                if (string.IsNullOrWhiteSpace(password))
                {
                    Console.WriteLine("Pole hasło nie może być puste! Spróbuj ponownie.");
                }

            } while (string.IsNullOrWhiteSpace(password));

            do
            {
                Console.Clear();
                InfoFrame("Witaj w formularzu rejestracji, wprowadź dane poniżej", 2);

                Console.Write("Powtórz swoje hasło: ");
                string password2 = "";
                ConsoleKeyInfo key;
                do
                {
                    key = Console.ReadKey(true);

                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        password2 += key.KeyChar;
                        Console.Write("*"); 
                    }
                    else if (key.Key == ConsoleKey.Backspace && password2.Length > 0)
                    {
                        password2 = password2.Substring(0, password2.Length - 1);
                        Console.Write("\b \b"); 
                    }
                } while (key.Key != ConsoleKey.Enter);

                passwordConfirm = password2.ToString();

                if (string.IsNullOrWhiteSpace(passwordConfirm))
                {
                    Console.WriteLine("Pole powtórz hasło nie może być puste! Spróbuj ponownie.");
                }

            } while (string.IsNullOrWhiteSpace(passwordConfirm));

           

            if (_userController.Register(name, surname, age, email, emailConfirm, password, passwordConfirm) == true)
            {
                Console.Clear();
                InfoFrame("Poprawnie zarejestrowano! Zaloguj się w systemie na podane przez Ciebie dane!",3);
                Thread.Sleep(5000);
                this.MainMenu();
            }
            else
            {
                RegisterForm();
            }
        }

        public void MainMenu()
       {
            Console.CursorVisible = false;

           // string[] options = { "Zaloguj się", "Załóż konto", "Wyjdź" };
            int selectedOption = 0;
            Boolean isExit = false;
            do
            {

                Console.Clear();
                Information info = new Information();

                info.InfoFrame("Witaj w kasynie, zaloguj się lub załóż konto!", 3);

                List<string> options = new List<string>();

                options.Add("Zaloguj się");
                options.Add("Załóż konto");
                options.Add("Wyjdź");

                this.SelectFrame(options, 20, 2, selectedOption);

                /*
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedOption)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }

                    Console.WriteLine(options[i]);

                    Console.ResetColor();
                }

                */
                ConsoleKeyInfo key = Console.ReadKey();



                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedOption = (selectedOption - 1 + 4) % 4;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedOption = (selectedOption + 1) % 4;
                        break;
                    case ConsoleKey.Enter:
                        isExit = true;
                        break;
                }

                /**
                 * Wyjscie z nieskończonej pętli
                 */

                if (isExit)
                {
                    switch (selectedOption)
                    {
                        case 0:
                            info.LoginForm();
                            break;
                        case 1:
                            info.RegisterForm();
                            break;
                        case 2:
                            Environment.Exit(0);
                            break;
                    }
                    break;
                }


            } while (true);
        }


        public void StartMenu(User user)
        {
            int wybor = 0;
            Console.CursorVisible = false;

           // string[] options = { "Gry", "Wpłata", "Konto", "Wyloguj się" };
            ConsoleKeyInfo key3;
            do
            {
                Console.Clear();
                this.InfoFrame("Witaj w Kasynie !", 22,3);
                List<string> naglowki = new List<string>();
                List<string> dane = new List<string>();
                naglowki.Add("Jesteś zalogowany/a jako");
                naglowki.Add("Twoje aktualne saldo");
                dane.Add(user.GetName()+" "+user.GetSurname());
                dane.Add(user.GetBalance().ToString()+" zł");


                this.FrameMulti(naglowki, 3, 2, dane);
                Console.Write("\n");

                List<string> options = new List<string>();

                options.Add("Gry");
                options.Add("Wpłata");
                options.Add("Konto");
                options.Add("Wyloguj się");

                this.SelectFrame(options, 25, 2, wybor);

                /*
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == wybor)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }

                    Console.WriteLine(options[i]);

                    Console.ResetColor();
                }
                 */

                key3 = Console.ReadKey(true);


                if (key3.Key == ConsoleKey.UpArrow)
                {
                    wybor -= 1;
                    wybor %= 4;
                }
                else if (key3.Key == ConsoleKey.DownArrow)
                {
                    wybor += 1;
                    wybor %= 4;
                }

            } while (key3.Key != ConsoleKey.Enter);

            switch(wybor)
            {
                case 0:
                    //gry
                    this.ShowGames(user);
                    break;
                case 1:
                    //wpłata
                    this.Wplata(user);
                    break;
                case 2:
                    //Konto
                    this.ShowAccount(user);
                    break;
                case 3:
                    //Wyjscie
                    this.MainMenu();
                    break;
            }


        }

        public void ShowAccount(User user)
        {
           
            int select = 0;
            Console.Clear();
            InfoFrame("Witaj w zakładzce Konto! - wybierz akcję", 4, 2);
            ConsoleKeyInfo key;
            do
            {
                

                if(select%3 == 0)
                {
                    Console.Clear();
                    InfoFrame("Witaj w zakładzce Konto! - wybierz akcję", 4, 2);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("Wypłać środki");
                    Console.ResetColor();
                    Console.WriteLine("Dane Osobiste");
                    Console.WriteLine("Wróć");
                }
                else if(select%3 == 1)
                {
                    Console.Clear();
                    InfoFrame("Witaj w zakładzce Konto! - wybierz akcję", 4, 2);
                    Console.ResetColor();
                    Console.WriteLine("Wypłać środki");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("Dane Osobiste");
                    Console.ResetColor();
                    Console.WriteLine("Wróć");
                   
                }
                else if(select % 3 == 2) {
                    Console.Clear();
                    InfoFrame("Witaj w zakładzce Konto! - wybierz akcję", 4, 2);
                    Console.ResetColor();
                    Console.WriteLine("Wypłać środki");
                    Console.WriteLine("Dane Osobiste");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("Wróć");
                    Console.ResetColor();
                }

                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow)
                {
                    select--;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    select++;
                }

            } while (key.Key != ConsoleKey.Enter);

            select %= 3;

            switch(select)
            {
                case 0:
                    this.Wyplata(user);
                    break;
                case 1:
                    this.ShowUserData(user);
                    break;
                case 2:
                    this.StartMenu(user);
                    break;
            }


        }

        public void ShowGames(User user)
        {
            int wybor = 0;
            Console.CursorVisible = false;
            ConsoleKeyInfo key3;
            do
            {
                Console.Clear();
                this.InfoFrame("Wybierz grę, w którą chcesz zagrać", 3);

                List<string> options = new List<string>();

                options.Add("Ruletka");
                options.Add("BlackJack (niedostepne)");

                this.SelectFrame(options, 8, 2, wybor);


                key3 = Console.ReadKey(true);

                if (key3.Key == ConsoleKey.UpArrow)
                {
                    if(wybor >= 1)
                    {
                        wybor -= 1;
                        wybor %= 2;
                    }
                }
                else if (key3.Key == ConsoleKey.DownArrow)
                {
                    if(wybor < 2)
                    {
                        wybor += 1;
                        wybor %= 2;
                    }
                }


            } while (key3.Key != ConsoleKey.Enter);

            switch (wybor)
            {
                case 0:
                    //ruletka
                    this.MenuGryRuletka(user);
                    break;
                case 1:
                    //blackjack
                    this.StartMenu(user);
                    break;
            }

        }

        public void Wplata(User user)
        {
          
            Console.Clear();
            InfoFrame("Podaj kwotę, którą chcesz wpłacić!", 4, 2);
            ConsoleKeyInfo key;
            string kwota;
            Console.Write("Kwota wpłaty : ");
            kwota = Console.ReadLine();
            user.AddBalance(decimal.Parse(kwota));
            Console.WriteLine("Udało się wpłacić kwotę na konto! - aktualne saldo " + user.GetBalance());
            Thread.Sleep(3000);
            this.StartMenu(user);

        }

        public void Wyplata(User user)
        {

            Console.Clear();
            InfoFrame("Podaj kwotę, którą chcesz wypłacić!", 4, 2);
            ConsoleKeyInfo key;
            string kwota;
            Console.Write("Kwota wypłaty : ");
            kwota = Console.ReadLine();
            if (user.RemoveBalance(decimal.Parse(kwota)))
            {
                Console.WriteLine("Udało się wypłacić kwotę - aktualne saldo " + user.GetBalance());
                
            }
            else
            {
                Console.WriteLine("Nie udało się wypłacić kwoty , podana kwota przekracza wartość salda - aktualne saldo " + user.GetBalance());
            }
            Thread.Sleep(3000);
            this.StartMenu(user);

        }

        public void ShowUserData(User user)
        {
            Console.Clear();
            InfoFrame("Oto twoje dane!", 5, 2);
            Console.WriteLine();
            List<string> naglowki = new List<string>();
            List<string> dane = new List<string>();

            naglowki.Add("Imie");
            naglowki.Add("Nazwisko");
            naglowki.Add("Wiek");
            naglowki.Add("Adres Email");
            naglowki.Add("Środki");

            dane.Add(user.GetName());
            dane.Add(user.GetSurname());
            dane.Add(user.GetAge().ToString());
            dane.Add(user.GetEmail());
            dane.Add(user.GetBalance().ToString());

            FrameMulti(naglowki,4,3,dane);

            Console.WriteLine("Naciśnij klawisz END , aby zakończyc przegląd.");
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey();

            }while(key.Key != ConsoleKey.End);

            this.ShowAccount(user);
        }

        public void StartRoulette(User user)
        {
            Roulette ruletka = new Roulette();
            PostawZaklad zaklady;

            ConsoleKeyInfo key;
            Console.Clear();
            do
            {
                
                key = Console.ReadKey(true);

                // ruletka.RysujKafelek(3);
                Console.WriteLine(ruletka.GetNumber().ToString());

                List<TypZakladu> listaMozliwosci = ruletka.getZakladyList();

                foreach(TypZakladu x in listaMozliwosci)
                {
                    Console.WriteLine(x.getName() + " | mnożnik wygranej x" + x.getMultipier());
                }

            } while (key.Key != ConsoleKey.Enter);
            
            Console.Clear();
            do
            {
               
                key = Console.ReadKey(true);

                Console.WriteLine("**************************************");
                Console.WriteLine("\nDane uzytkownika " + user.GetName() + " " + user.GetSurname() + " Aktualne saldo: " + user.GetBalance());
                
                PostawZaklad zaklad = new PostawZaklad(ruletka,3, user, 2m);

                ruletka.SprawdzWygrana(ruletka);

                Console.WriteLine("\nDane uzytkownika " + user.GetName() + " " + user.GetSurname() + " Aktualne saldo: " + user.GetBalance());

            } while (key.Key != ConsoleKey.End);

        }

        public void MenuGryRuletka(User user)
        {

            int selectedRow = 1;
            int selectedRow2 = 1;
            int selectedColumn = 0;
            int wartosc = 0;
            ConsoleKeyInfo key3;
            Roulette ruletka = new Roulette();
            this.RuletkaGraRysuj(ruletka,user, selectedRow,selectedColumn,0, 34);
            Console.CursorVisible = false;
            do
            {
                int wartosc1 = (selectedRow % 9);
                int wartosc3 = (selectedRow2 % 2);
                int selectedcol1 = (selectedColumn % 3);
                key3 = Console.ReadKey(true);
                if(key3.Key == ConsoleKey.DownArrow && selectedcol1 == 0)
                {
                    selectedRow++;
                }
                else if(key3.Key == ConsoleKey.UpArrow && selectedcol1 == 0)
                {
                    selectedRow--;
                }
                else if (key3.Key == ConsoleKey.DownArrow && selectedcol1 == 1)
                {
                    selectedRow2++;
                }
                else if (key3.Key == ConsoleKey.UpArrow && selectedcol1 == 1)
                {
                    selectedRow2--;
                }
                else if(key3.Key == ConsoleKey.RightArrow)
                {
                    selectedColumn++;
              
                }
                else if (key3.Key == ConsoleKey.LeftArrow)
                {
                    selectedColumn--;
                 
                }
                int wartosc2 = (selectedRow % 9);
                int wartosc4 = (selectedRow2 % 2);
                int selectedcol2 = (selectedColumn % 3);

                if ((wartosc1 != wartosc2) || selectedcol1 != selectedcol2 || wartosc3 != wartosc4)
                {
                    this.RuletkaGraRysuj(ruletka, user, wartosc2, selectedcol2,wartosc4, 0);
                }
               
                if(key3.Key == ConsoleKey.Spacebar)
                {
                   
                    this.playAnim(ruletka);
                }

                if (key3.Key == ConsoleKey.Home)
                {

                    this.StartMenu(user);
                }


            } while(key3.Key != ConsoleKey.End);


        }

        public void RuletkaGraRysuj(Roulette ruletka, User user, int selectedRow, int selectedColumn, int selectedRow2, int rysujNr)
        {
            

            Console.Clear();
            selectedColumn += 1;
            this.InfoFrame("Witaj w grze w Ruletkę!", 30, 3);

            List<string> naglowki = new List<string>();
            List<string> dane = new List<string>();

            naglowki.Add("Zalogowany jako");
            naglowki.Add("Twoje saldo");
            naglowki.Add("Historia gier");

            dane.Add(user.GetName() + " " + user.GetSurname());
            dane.Add(user.GetBalance().ToString() + " zł");
            dane.Add("--");

            this.FrameMulti(naglowki, 6, 2, dane);


            List<TypZakladu> zaklady = new List<TypZakladu>();

            Console.Write("\n");
            ruletka.RysujSrodek(98);
            ruletka.RysujKafelek(rysujNr);
            Console.WriteLine();
            Console.WriteLine();
            naglowki.Clear();
            dane.Clear();

            naglowki.Add("Wybierz rodzaj zakładu");
            if((selectedRow+1) == 1)
            {
                naglowki.Add("Wybierz liczbę");
                naglowki.Add("Ustaw kwotę");
            }
            else if((selectedRow + 1) == 2 )
            {
                naglowki.Add("Wybierz kolor");
                naglowki.Add("Ustaw kwotę");
            }
            else
            {
                naglowki.Add("-----");
                naglowki.Add("Ustaw kwotę");
            }

            if((selectedColumn) == 1)
            {
                dane.Add("(Wybrane)");
                dane.Add("");
                dane.Add("");
            }
            if ((selectedColumn) == 2)
            {
                dane.Add("");
                dane.Add("(Wybrane)");
                dane.Add("");
            }
            if ((selectedColumn) == 3)
            {
                dane.Add("");
                dane.Add("");
                dane.Add("(Wybrane)");
            }

            this.FrameMulti(naglowki, 3, 2, dane);

            string kwota = string.Empty;
            string wygrywajaca = string.Empty;
            Kolor wybranyKolor = new Kolor();

            if (selectedColumn == 1)
            {
                zaklady = ruletka.getZakladyList();
                Console.WriteLine("*  ");
                foreach (TypZakladu zaklad in zaklady)
                {
                    if (zaklad.getId() == (selectedRow + 1))
                    {
                        Console.Write("*  ");
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(zaklad.getName());
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("*  " + zaklad.getName());
                    }

                }
            }else if(selectedColumn == 2 && selectedRow == 1)
            {

                if(selectedRow2 == 0)
                {
                    Console.Write("*  ");
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(Kolor.Czerwony.ToString());
                    Console.ResetColor();
                    Console.Write("*  ");
                    Console.WriteLine(Kolor.Czarny.ToString());
                    wybranyKolor = Kolor.Czerwony;
                }
                else if(selectedRow2 == 1)
                {
                    Console.Write("*  ");
                    Console.WriteLine(Kolor.Czerwony.ToString());
                    Console.Write("*  ");
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(Kolor.Czarny.ToString());
                    Console.ResetColor();
                    wybranyKolor = Kolor.Czarny;
                }
                   

            }
            else if(selectedColumn == 2 && selectedRow == 0)
            {
                Console.Write("*  ");
                Console.Write("Wprowadź liczbę która ma wygrać :");
                wygrywajaca = Console.ReadLine();
                Console.Write("Wprowadź kwotę zakładu:");
                kwota = Console.ReadLine();
            }
            else if (selectedColumn == 3 || (selectedColumn == 2 && selectedRow > 2))
            {
                
                Console.Write("*  ");
                Console.Write("Wprowadź kwotę zakładu :");
                kwota = Console.ReadLine();
            }

            if(selectedColumn == 3 && (kwota != string.Empty || decimal.Parse(kwota) > 0m))
            {
                if(wygrywajaca != "")
                {
                    PostawZaklad postawZaklad = new PostawZaklad(ruletka, 1, user, decimal.Parse(kwota), int.Parse(wygrywajaca));
                }
                else if(wybranyKolor == Kolor.Czerwony || wybranyKolor == Kolor.Czarny)
                {
                    
                    if(selectedRow2 == 0 && selectedRow == 1)
                    {
                        wybranyKolor = Kolor.Czerwony;
                        PostawZaklad postawZaklad = new PostawZaklad(ruletka, 2, user, decimal.Parse(kwota), wybranyKolor);
                    }
                    else if(selectedRow2 == 1 && selectedRow == 1)
                    {
                        wybranyKolor = Kolor.Czarny;
                        PostawZaklad postawZaklad = new PostawZaklad(ruletka, (selectedRow + 1), user, decimal.Parse(kwota), wybranyKolor);
                    }
                    else if(selectedRow >= 2)
                    {
                        PostawZaklad postawZaklad = new PostawZaklad(ruletka, (selectedRow + 1), user, decimal.Parse(kwota));
                    }

                }
                else
                {
                    PostawZaklad postawZaklad = new PostawZaklad(ruletka, (selectedRow + 1), user, decimal.Parse(kwota));
                }


            }

        }
        
        public void playAnim(Roulette ruletka)
        {
            
            ruletka.SprawdzWygrana(ruletka);
        }


}
}
