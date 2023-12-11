using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Kasyno.Classes.Games.Enums;

namespace Kasyno.Classes.Games
{
    public enum Kolor
    {
        Czerwony,
        Czarny,
        Zielony
    }
    internal class Roulette
    {
        private readonly decimal kwotaMinZakladu;
        private readonly decimal kwotaMaxZakladu;
        private readonly int[] biale = { 1, 3, 5,7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
        private readonly int[] czarne = { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };
        private readonly List<int> liczby;
        private readonly List<TypZakladu> rodzajeZakladow;
        private List<Zaklad> listaPostawionychZakladow;
        private int liczbaWylosowana;
        private int lastNumber;
        public Roulette()
        {
            liczby = new List<int> { 0, 32, 15, 19, 4, 21, 2, 25, 17, 34, 6, 27, 13, 36, 11, 30, 8, 23, 10, 5, 24, 16, 33, 1, 20, 14, 31, 9, 22, 18, 29, 7, 28, 12, 35, 3, 26 };


            lastNumber = 0;

            kwotaMaxZakladu = 5000m;
            kwotaMinZakladu = 0.5m;

            rodzajeZakladow = new List<TypZakladu>();
            listaPostawionychZakladow = new List<Zaklad>();

            rodzajeZakladow.Add(new TypZakladu(1, "Postaw na konkretną liczbę.", 35));
            rodzajeZakladow.Add(new TypZakladu(2, "Postaw na kolor.", 2));
            rodzajeZakladow.Add(new TypZakladu(3, "Postaw na parzystą liczbę.", 2));
            rodzajeZakladow.Add(new TypZakladu(4, "Postaw na nieparzystą liczbę.", 2));
            rodzajeZakladow.Add(new TypZakladu(5, "Postaw na 1sza 12 liczby 1-12.", 3));
            rodzajeZakladow.Add(new TypZakladu(6, "Postaw na 2ga 12 liczby 13-24.", 3));
            rodzajeZakladow.Add(new TypZakladu(7, "Postaw na 3cią 12 liczby 25-36.", 3));
            rodzajeZakladow.Add(new TypZakladu(8, "Postaw na 1szą połowę 1-18", 3));
            rodzajeZakladow.Add(new TypZakladu(9, "Postaw na 2gą połowę 19-36", 3));

        }
        public int GetNumber()
        {

            Random random = new Random();
            int numer = random.Next(36, 359);

            int roundedNumber = liczby[(lastNumber+numer) % 36];

            lastNumber = roundedNumber;

            return roundedNumber;

        }

        public List<TypZakladu> getZakladyList()
        {
            return rodzajeZakladow;
        }

        public void RysujSrodek(int dl)
        {
   
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < dl; i++)
            {
                Console.Write("*");

            }
            Console.WriteLine("");
            for (int i = 0; i < dl/2; i++)
            {
                Console.Write(" ");
            }
            Console.Write("***");
            Console.WriteLine("");
            for (int i = 0; i < dl/2+1; i++)
            {
                Console.Write(" ");

            }
            Console.Write("*");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public async void RysujKafelek(int nr)
        {
            int pozycja = 0;
            int liczbaKafelkow = 7;
            int szerokoscKafelka = 14;
            int wysokoscKafla = 7;

            
            //pętla rysująca górne gwiazdki
            for(int i=0; i< liczbaKafelkow * szerokoscKafelka; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();

            //pętla rysująca poziomy
            for(int i=0; i<wysokoscKafla;i++)
            {

                //petla rozrozniajaca kafelki
                for(int j=0; j<liczbaKafelkow; j++)
                {
                    //pętla rysująca odstępy lub gwiazdki w zależności czy kafelek jest biały czy czarny

                    for(int k = 0; k < szerokoscKafelka; k++)
                    {
                        if(i == (wysokoscKafla/2))
                        {
                            //wiersz zawierający liczbę
                            if((k < ((szerokoscKafelka - 2) / 2)) || (k > (((szerokoscKafelka - 2) / 2))))
                            {
                                if (biale.Contains(liczby.ElementAt((nr + j) % 37)))
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.Write("*");
                                    Console.ResetColor();
                                }
                                else if(biale.Contains(liczby.ElementAt((nr + j) % 37)) == false && czarne.Contains(liczby.ElementAt((nr + j) % 37)) == false)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.Write("*");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write(" ");
                                }
                            }
                            else
                            {
                                if (liczby.ElementAt((nr + j) % 37).ToString().Length == 1)
                                {
                                    //pojedyncza liczba
                                    Console.Write("0" + liczby.ElementAt(((nr + j) % 37)).ToString());
                                }
                                else
                                {
                                    //podwojna liczba
                                    Console.Write(liczby.ElementAt((nr + j) % 37).ToString());

                                }
                                k++;
                            }

                        }
                        else
                        {
                            if (biale.Contains(liczby.ElementAt((nr + j)%37)))
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write("*");
                                Console.ResetColor();
                            }
                            else if (biale.Contains(liczby.ElementAt((nr + j)%37)) == false && czarne.Contains(liczby.ElementAt((nr + j) % 37)) == false)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.Write("*");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write(" ");
                            }
                        }
                        
                    }



                }
                Console.WriteLine();



            }


            //pętla rysująca dolne gwiazdki
            for (int i = 0; i < liczbaKafelkow * szerokoscKafelka; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();


        }
        static async Task DelayAsync(int milliseconds)
        {
            // Utwórz obiekt CancellationTokenSource, aby można było anulować opóźnienie, jeśli to konieczne
            using (var cts = new CancellationTokenSource())
            {
                try
                {
                    // Poczekaj asynchronicznie na określony czas
                    await Task.Delay(milliseconds, cts.Token);
                }
                catch (TaskCanceledException)
                {
                    // Przechwyć wyjątek, jeśli zadanie zostanie anulowane
                }
            }
        }

        public int[] getBiale()
        {
            return biale;
        }
        public int[] getCzarne()
        {
            return czarne;
        }

        public Kolor getColor(int nr)
        {
            if (biale.Contains(nr))
            {
                return Kolor.Czerwony;
            }
            else if(czarne.Contains(nr))
            {
                return Kolor.Czarny;
            }
            else
            {
                return Kolor.Zielony;
            }
        }

        public List<Zaklad> getListaPostawionychZakladow()
        {
            return listaPostawionychZakladow;
        }

        public void addZaklad(Zaklad zaklad)
        {
            this.listaPostawionychZakladow.Add(zaklad);

        }

        public void SprawdzWygrana(Roulette ruletka)
        {
            int getWynik = this.GetNumber();

            Thread.Sleep(100);
            Console.SetCursorPosition(0, 19);

            for (int i = 0; i < 36*2+(liczby.IndexOf(getWynik)); i++)
            {
             
              
                if((36 * 2 + (liczby.IndexOf(getWynik))/2) > i)
                {
                    Thread.Sleep(100);
                }
                else if((36 * 2 + (liczby.IndexOf(getWynik)) / 1.5) > i)
                {
                    Thread.Sleep(200);
                }
                else if ((36 * 2 + (liczby.IndexOf(getWynik)) / 1.25) > i)
                {
                    Thread.Sleep(300);
                }
                else if ((36 * 2 + (liczby.IndexOf(getWynik)) / 1.125) > i)
                {
                    Thread.Sleep(400);
                }
                ruletka.RysujKafelek(i);

                Console.SetCursorPosition(0, Console.CursorTop - 9);
            }

            Console.SetCursorPosition(0, Console.CursorTop + 30);
            //  Console.Write("\nWygrywa nr: " + getWynik);

            //  Console.Write(" Kolor ("+this.getColor(getWynik).ToString()+")");

            //  Console.WriteLine("");


            foreach (Zaklad zaklad in ruletka.getListaPostawionychZakladow())
            {
                TypZakladu rodzajZakladu = zaklad.rodzajZakladu();

                if (rodzajZakladu != null)
                {
                    int id = rodzajZakladu.getId();

                    switch (id)
                    {
                        case 1:
                            //postaw na konkretną liczbę
                            if (getWynik == zaklad.getWybranaLiczba())
                            {
                                zaklad.getUser().AddBalance(zaklad.KwotaZakladu() * zaklad.getMultipier());
                                Console.Write("\nUdało Ci się wygrać : " + (decimal)(zaklad.KwotaZakladu() * zaklad.getMultipier()) + " zł zostało dodane do twojego konta!");
                            }
                            else
                            {
                                Console.Write("\nNiestety tym razem nie udało Ci się wygrać! - tracisz " + zaklad.KwotaZakladu() + " zł");
                            }
                            break;
                        case 2:
                            //postaw na kolor
                            if (zaklad.wybranyKolor() == ruletka.getColor(getWynik))
                            {
                                zaklad.getUser().AddBalance(zaklad.KwotaZakladu() * zaklad.getMultipier());
                                Console.Write("\nUdało Ci się wygrać : " + (decimal)(zaklad.KwotaZakladu() * zaklad.getMultipier()) + " zł zostało dodane do twojego konta!");
                            }
                            else
                            {
                                Console.Write("\nNiestety tym razem nie udało Ci się wygrać! - tracisz " + zaklad.KwotaZakladu() + " zł");
                            }
                            break;
                        case 3:
                            //postaw na parzystą liczbę
                            if (getWynik%2 == 0)
                            {
                                zaklad.getUser().AddBalance(zaklad.KwotaZakladu() * zaklad.getMultipier());
                                Console.Write("\nUdało Ci się wygrać : " + (decimal)(zaklad.KwotaZakladu() * zaklad.getMultipier()) + " zł zostało dodane do twojego konta!");
                            }
                            else
                            {
                                Console.Write("\nNiestety tym razem nie udało Ci się wygrać! - tracisz " + zaklad.KwotaZakladu() + " zł");
                            }
                            break;
                        case 4:
                            //postaw na nieparzysta liczbę
                            if (getWynik % 2 == 1)
                            {
                                zaklad.getUser().AddBalance(zaklad.KwotaZakladu() * zaklad.getMultipier());
                                Console.Write("\nUdało Ci się wygrać : " + (decimal)(zaklad.KwotaZakladu() * zaklad.getMultipier()) + " zł zostało dodane do twojego konta!");
                            }
                            else
                            {
                                Console.Write("\nNiestety tym razem nie udało Ci się wygrać! - tracisz " + zaklad.KwotaZakladu() + " zł");
                            }

                            break;
                        case 5:
                            //postaw na 1sza 12 liczby 1-12
                            if (getWynik > 0 && getWynik < 13)
                            {
                                zaklad.getUser().AddBalance(zaklad.KwotaZakladu() * zaklad.getMultipier());
                                Console.Write("\nUdało Ci się wygrać : " + (decimal)(zaklad.KwotaZakladu() * zaklad.getMultipier()) + " zł zostało dodane do twojego konta!");
                            }
                            else
                            {
                                Console.Write("\nNiestety tym razem nie udało Ci się wygrać! - tracisz " + zaklad.KwotaZakladu() + " zł");
                            }
                            break;
                        case 6:
                            //postaw na 2gą 12 liczby 13-24
                            if (getWynik > 12 && getWynik < 25)
                            {
                                zaklad.getUser().AddBalance(zaklad.KwotaZakladu() * zaklad.getMultipier());
                                Console.Write("\nUdało Ci się wygrać : " + (decimal)(zaklad.KwotaZakladu() * zaklad.getMultipier()) + " zł zostało dodane do twojego konta!");
                            }
                            else
                            {
                                Console.Write("\nNiestety tym razem nie udało Ci się wygrać! - tracisz " + zaklad.KwotaZakladu() + " zł");
                            }
                            break;
                        case 7:
                            //postaw na 3cia 12 liczby 25-36
                            if (getWynik > 24 && getWynik <= 36)
                            {
                                zaklad.getUser().AddBalance(zaklad.KwotaZakladu() * zaklad.getMultipier());
                                Console.Write("\nUdało Ci się wygrać : " + (decimal)(zaklad.KwotaZakladu() * zaklad.getMultipier()) + " zł zostało dodane do twojego konta!");
                            }
                            else
                            {
                                Console.Write("\nNiestety tym razem nie udało Ci się wygrać! - tracisz " + zaklad.KwotaZakladu() + " zł");
                            }
                            break;
                        case 8:
                            //na pierwszą połowę
                            if (getWynik > 0 && getWynik <= 18)
                            {
                                zaklad.getUser().AddBalance(zaklad.KwotaZakladu() * zaklad.getMultipier());
                                Console.Write("\nUdało Ci się wygrać : " + (decimal)(zaklad.KwotaZakladu() * zaklad.getMultipier()) + " zł zostało dodane do twojego konta!");
                            }
                            else
                            {
                                Console.Write("\nNiestety tym razem nie udało Ci się wygrać! - tracisz " + zaklad.KwotaZakladu() + " zł");
                            }
                            break;
                        case 9:
                            //na drugą połowę
                            if (getWynik > 18 && getWynik <= 36)
                            {
                                zaklad.getUser().AddBalance(zaklad.KwotaZakladu() * zaklad.getMultipier());
                                Console.Write("\nUdało Ci się wygrać : " + (decimal)(zaklad.KwotaZakladu() * zaklad.getMultipier()) + " zł zostało dodane do twojego konta!");
                            }
                            else
                            {
                                Console.Write("\nNiestety tym razem nie udało Ci się wygrać! - tracisz " + zaklad.KwotaZakladu() + " zł");
                            }
                            break;
                    }
                }
            }

            ruletka.listaPostawionychZakladow.Clear();

        }

        public decimal getMinKwotaZakaldu()
        {
            return this.kwotaMinZakladu;
        }
        public decimal getMaxKwotaZakaldu()
        {
            return this.kwotaMaxZakladu;
        }

    }

    internal class TypZakladu
    {
        private int Id;
        private string Name;
        private decimal multipier;

        public TypZakladu(int id, string Name, decimal multipier)
        {
            this.Id = id;
            this.Name = Name;
            this.multipier = multipier;
        }

        public decimal getMultipier()
        {
            return this.multipier;
        }
        public string getName()
        {
            return this.Name;
        }
        public int getId()
        {
            return this.Id;
        }
    }
    internal class Zaklad : Roulette
    {

        private User User { get; set; }
        private decimal kwotaZakladu;
        private TypZakladu rodzaj;
        private int wybranaLiczba;
        private Kolor Kolor { get; set; }

        public Zaklad(int idZakladu, User user, decimal kwota)
        {
            
            List<TypZakladu> zaklady = getZakladyList();
            this.rodzaj = zaklady.ElementAt(idZakladu - 1);
            this.User = user;
            this.kwotaZakladu = kwota;
        }

        public Zaklad(int idZakladu, User user, decimal kwota, int wybranaLiczba)
        {
            if (idZakladu == 1)
            {
               
                List<TypZakladu> zaklady = getZakladyList();
                this.rodzaj = zaklady.ElementAt(idZakladu-1);
                this.User = user;
                this.kwotaZakladu = kwota;
                this.wybranaLiczba = wybranaLiczba;
            }
        }
        public Zaklad(int idZakladu, User user, decimal kwota, Kolor kolor)
        {
                List<TypZakladu> zaklady = getZakladyList();
                this.rodzaj = zaklady.ElementAt(idZakladu - 1);
                this.User = user;
                this.kwotaZakladu = kwota;
                this.Kolor = kolor;
        }

        public TypZakladu rodzajZakladu()
        {
            return this.rodzaj;
        }
        public decimal getMultipier()
        {
            return rodzaj.getMultipier();
        }
        public int getWybranaLiczba()
        {
            return this.wybranaLiczba;
        }
        public Kolor wybranyKolor()
        {
            return this.Kolor;
        }

        public User getUser()
        {
            return this.User;
        }
        public decimal KwotaZakladu()
        {
            return this.kwotaZakladu;
        }

        public void MozliwaWygrana()
        {
            Console.Write("Możliwa wygrana : " + (kwotaZakladu * getMultipier()));
        }

        public Kolor GetKolor()
        {
            return this.Kolor;
        }

    }
    internal class PostawZaklad
    {
        //postaw na dowolny inny zakład
        public PostawZaklad(Roulette ruletka, int id, User user,decimal kwota)
        {
            if(id != 1 && id != 2)
            {
                //sprawdza czy kwota zakładu nie przekracza limitów
                if ((kwota >= ruletka.getMinKwotaZakaldu()) && (kwota <= ruletka.getMaxKwotaZakaldu()))
                {
                    //sprawdza czy użytkownik ma wystarczającą kwotę na koncie
                    if (this.sprawdzSaldo(user, kwota))
                    {
                        //jezeli tak
                        if (user.RemoveBalance(kwota))
                        {
                            //jezeli udało się usunąć kwotę postaw zakład
                            Zaklad newZaklad = new Zaklad(id, user, kwota);
                            ruletka.addZaklad(newZaklad);
                            this.informationPlacedOrder(kwota, ruletka.getZakladyList().ElementAt(id - 1).getName());
                        }
                        else
                        {
                            this.exceptionWeCannotTakeMoneyFromYourAccount();
                        }

                    }
                    else
                    {
                        this.exceptionYouHaveNoEnoughMoney();
                    }
                }
                else
                {
                    this.exceptionLimitesNotReached(kwota, ruletka.getMinKwotaZakaldu(), ruletka.getMaxKwotaZakaldu());
                }
            }
            else
            {
                this.exceptionBadOrder();
            }
            

        }
        //postaw na kolor    
        public PostawZaklad(Roulette ruletka,int id, User user, decimal kwota, Kolor kolor)
        {
            if(id == 2)
            {
                //sprawdza czy kwota zakładu nie przekracza limitów
                if ((kwota >= ruletka.getMinKwotaZakaldu()) && (kwota <= ruletka.getMaxKwotaZakaldu()))
                {
                    //sprawdza czy użytkownik ma wystarczającą kwotę na koncie
                    if (this.sprawdzSaldo(user, kwota))
                    {
                        //jezeli tak
                        if (user.RemoveBalance(kwota))
                        {
                            //jezeli udało się usunąć kwotę postaw zakład
                            Zaklad newZaklad = new Zaklad(id, user, kwota, kolor);
                            ruletka.addZaklad(newZaklad);
                            this.informationPlacedOrder(kwota, ruletka.getZakladyList().ElementAt(id - 1).getName() + " na " + kolor.ToString() + " ");
                        }
                        else
                        {
                            this.exceptionWeCannotTakeMoneyFromYourAccount();
                        }

                    }
                    else
                    {
                        this.exceptionYouHaveNoEnoughMoney();
                    }
                }
                else
                {
                    this.exceptionLimitesNotReached(kwota, ruletka.getMinKwotaZakaldu(), ruletka.getMaxKwotaZakaldu());
                }
            }
            else
            {
                this.exceptionBadOrder();
            }
            

        }
        //postaw na konkretną liczbę
        public PostawZaklad(Roulette ruletka,int id, User user, decimal kwota,int liczba)
        {
            if(id == 1)
            {
                //sprawdza czy kwota zakładu nie przekracza limitów
                if ((kwota >= ruletka.getMinKwotaZakaldu()) && (kwota <= ruletka.getMaxKwotaZakaldu()))
                {
                    //sprawdza czy użytkownik ma wystarczającą kwotę na koncie
                    if (this.sprawdzSaldo(user, kwota))
                    {
                        //jezeli tak
                        if (user.RemoveBalance(kwota))
                        {
                            //jezeli udało się usunąć kwotę postaw zakład
                            Zaklad newZaklad = new Zaklad(id, user, kwota, liczba);
                            ruletka.addZaklad(newZaklad);
                            this.informationPlacedOrder(kwota, ruletka.getZakladyList().ElementAt(id - 1).getName() + " na " + liczba + " ");
                        }
                        else
                        {
                            this.exceptionWeCannotTakeMoneyFromYourAccount();
                        }

                    }
                    else
                    {
                        this.exceptionYouHaveNoEnoughMoney();
                    }
                }
                else
                {
                    this.exceptionLimitesNotReached(kwota, ruletka.getMinKwotaZakaldu(), ruletka.getMaxKwotaZakaldu());
                }
            }
            else
            {
                this.exceptionBadOrder();
            }
           

        }


        //funkcje pomocnicze + informujące
        private Boolean sprawdzSaldo(User user, decimal kwota)
        {
            if (user.GetBalance() >= kwota)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void informationPlacedOrder(decimal kwota, string zaklad)
        {
            Console.WriteLine("Postawiono zakład ("+zaklad+") na kwotę "+kwota+" zł");
        }
        private void exceptionYouHaveNoEnoughMoney()
        {
            Console.WriteLine("Niestety nie posiadasz wystarczających środków na swoim koncie aby postawić zakład o takiej kwocie.");
        }
        private void exceptionWeCannotTakeMoneyFromYourAccount()
        {
            Console.WriteLine("Nie udało się pobrać środków z twojego konta, operacja anulowana.");
        }
        private void exceptionLimitesNotReached(decimal kwota,decimal kwotaMin, decimal kwotaMax)
        {
            Console.WriteLine("Nie postawiono zakładu. Kwota zakładu musi mieścić się w przedziale od "+kwotaMin+" do "+kwotaMax+" zł, próbowano postawić "+kwota+" zł.");
        }
        private void exceptionBadOrder()
        {
            Console.WriteLine("Nie postawiono zakładu należy uzupełnić dane o zakładzie!");
        }

    }

}

