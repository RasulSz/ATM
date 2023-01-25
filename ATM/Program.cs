using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace ATM
{
    class Client
    {
        public Client()
        {
            Id = ++ID;
        }
        public int Id { get; set; }
        public static int ID { get; set; } = 0;
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public Cart BankCart { get; set; }
    }
    class Cart
    {
        public string BankName { get; set; }
        public string UserName { get; set; }
        public string PAN { get; set; }
        public string PIN { get; set; }
        public string CVC { get; set; }
        public string ExpireDate { get; set; }
        public decimal Balance { get; private set; } = new Random().Next(500, 2000);
        public DateTime timeofcash { get; set; }
        public string CostofCash { get; set; }

        public void Credit()
        {
            Console.WriteLine("QEYD : Faizler 1 ayliq 30 faiz    6 ayliq 13 faiz    12 ayliq 20 faiz"); Console.WriteLine();
            Console.WriteLine("[1] 500 azn");
            Console.WriteLine("[2] 1000 azn");
            Console.WriteLine("[3] 2000 azn");
            Console.WriteLine("[4] 10000 azn");
            Console.WriteLine("[5] Geri");
            Console.Write("Meblegi secin : ");
            string amount = Console.ReadLine();
            if (amount == "1")
            {
                Balance += 500;
                Console.WriteLine("Ugurlu emeliyyat");
                Console.ReadKey();
            }
            else if (amount == "2")
            {
                Balance += 1000;
                Console.WriteLine("Ugurlu emeliyyat");
                Console.ReadKey();
            }
            else if (amount == "3")
            {
                Balance += 2000;
                Console.WriteLine("Ugurlu emeliyyat");
                Console.ReadKey();
            }
            else if (amount == "4")
            {
                Balance += 10000;
                Console.WriteLine("Ugurlu emeliyyat");
                Console.ReadKey();
            }
        }

        public void Cash()
        {
            Console.WriteLine("[1] 10 AZN");
            Console.WriteLine("[2] 20 AZN");
            Console.WriteLine("[3] 50 AZN");
            Console.WriteLine("[4] 100 AZN");
            Console.WriteLine("[5] Diger");
            Console.Write("Seciminiz : ");
            int select = int.Parse(Console.ReadLine());
            if (select == 1)
            {
                Balance -= 10;
                Console.WriteLine("Ugurlu Emelyat !"); Console.ReadKey();
                timeofcash = DateTime.Now;
                CostofCash = "10 azn";
            }
            else if (select == 2)
            {
                Balance -= 20;
                Console.WriteLine("Ugurlu Emelyat !"); Console.ReadKey();
                timeofcash = DateTime.Now;
                CostofCash = "20 azn";
            }
            else if (select == 3)
            {
                Balance -= 50;
                Console.WriteLine("Ugurlu Emelyat !"); Console.ReadKey();
                timeofcash = DateTime.Now;
                CostofCash = "50 azn";
            }
            else if (select == 4)
            {
                Balance -= 100;
                Console.WriteLine("Ugurlu Emelyat !"); Console.ReadKey();
                timeofcash = DateTime.Now;
                CostofCash = "100 azn";
            }
            else if (select == 5)
            {
                CustomCush();
            }
        }
        public void CustomCush()
        {
            Console.Write("Mebleg daxil edin : ");
            decimal balance = decimal.Parse(Console.ReadLine());
            if (balance < Balance)
            {
                Balance -= balance;
                Console.WriteLine("Ugurlu emelyat");
                Console.ReadKey();
                timeofcash = DateTime.Now;
                CostofCash = $"{balance} azn";
            }
            else { throw new Exception("Yeterli balans yoxdur !"); }
        }

    }
    class Controller
    {
        public static string[] info = new string[] { };
        static void HistoryOfCash(Cart card)
        {
            string temp = card.CostofCash + " cixarildi" + " " + card.timeofcash;
            Array.Resize(ref info, info.Length + 1);
            for (int i = 0; i < info.Length; i++)
            {
                info.CopyTo(info, 0);
            }
            info[info.Length - 1] = temp;
        }
        static public void NotificationCartToCart(Cart card, string pan, Client[] users)
        {
            foreach (var user in users)
            {
                if (user.BankCart.PAN == pan)
                {
                    string temp = $"{user.Name} {user.Surname} {card.CostofCash} gonderildi  {card.timeofcash}";
                    Array.Resize(ref info, info.Length + 1);
                    for (int i = 0; i < info.Length; i++)
                    {
                        info.CopyTo(info, 0);
                    }
                    info[info.Length - 1] = temp;
                }
            }
        }
        public static void Start()
        {
            void ATM()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("================ ATM ================");
                Console.ResetColor(); Console.WriteLine(); Console.WriteLine();
            }
            void CartToCart(Client user, Client[] userq, string pan1)
            {
                foreach (var user12 in userq)
                {
                    if (pan1 == user12.BankCart.PAN)
                    {
                        Console.WriteLine($"Balans {user.BankCart.Balance} manat");
                        Console.WriteLine($"{user12.Name} {user12.Surname}");
                        try
                        {
                            user.BankCart.CustomCush();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message); Console.ReadKey();
                        }
                        return;
                    }
                }
                Console.WriteLine("Istifadeci tapilmadi !"); Console.ReadKey();
                CartToCart(user, userq, pan1);
            }
            Client user1 = new Client()
            {
                Name = "Mehdi",
                Surname = "Esedov",
                Age = 20,
                Salary = 1800,
                BankCart = new Cart()
                {
                    BankName = "Kapital Bank",
                    UserName = "MAHDI ASADOV",
                    PAN = "1458789654123654",
                    PIN = "4558",
                    CVC = "196",
                    ExpireDate = "06/2025"
                }
            };
            Client user2 = new Client()
            {
                Name = "Nergiz",
                Surname = "Veliyeva",
                Age = 23,
                Salary = 2000,
                BankCart = new Cart()
                {
                    BankName = "Pasha Bank",
                    UserName = "NARGIZ VALIYEVA",
                    PAN = "5744987412547853",
                    PIN = "7864",
                    CVC = "369",
                    ExpireDate = "07/2027"
                }
            };
            Client user3 = new Client()
            {
                Name = "Pasha",
                Surname = "Mehdiyev",
                Age = 19,
                Salary = 2500,
                BankCart = new Cart()
                {
                    BankName = "Kapital Bank",
                    UserName = "PASHA MAHDIYEV",
                    PAN = "9875632145896574",
                    PIN = "2564",
                    CVC = "746",
                    ExpireDate = "10/2024"
                }
            };
            Client user4 = new Client()
            {
                Name = "Leyla",
                Surname = "Aghazade",
                Age = 27,
                Salary = 1999,
                BankCart = new Cart()
                {
                    BankName = "Beynelxalq Bank",
                    UserName = "LEYLA AGAZADA",
                    PAN = "3265789541263589",
                    PIN = "5873",
                    CVC = "547",
                    ExpireDate = "12/2030"
                }
            };
            Client user5 = new Client()
            {
                Name = "Murad",
                Surname = "Eliyev",
                Age = 26,
                Salary = 2200,
                BankCart = new Cart()
                {
                    BankName = "Beynelxalq Bank",
                    UserName = "MURAD ALIYEV",
                    PAN = "5789654123547896",
                    PIN = "3648",
                    CVC = "845",
                    ExpireDate = "04/2035"
                }
            };
            Client[] users = new Client[5] { user1, user2, user3, user4, user5 };
            ATM();
            while (true)
            {
                Console.Write("Enter CART PAN : ");
                string pan = Console.ReadLine();
                for (int i = 0; i < users.Length; i++)
                {
                    if (pan == users[i].BankCart.PAN)
                    {
                        while (true)
                        {
                            Console.Clear();
                            ATM();
                            Console.WriteLine($"Xosh Geldiniz {users[i].Name} {users[i].Surname}.\nZehmet olmasa asagidakilardan birini secesiniz.");
                            Console.WriteLine("[1] Balans\n[2] Nagd pul\n[3] Edilen emeliyyatlarin siyahisi\n[4] Kartdan karta kocurme\n[5] Kredit");
                            Console.Write("Seciminiz : ");
                            string choice = Console.ReadLine();
                            if (choice == "1")
                            {
                                Console.Clear();
                                ATM();
                                Console.WriteLine($"Sizin balansiniz {users[i].BankCart.Balance} manat");
                                Console.ReadKey();
                            }
                            else if (choice == "2")
                            {
                                Console.Clear();
                                ATM();
                                Console.WriteLine($"Balans {users[i].BankCart.Balance} manat");
                                try
                                {
                                    users[i].BankCart.Cash();
                                    HistoryOfCash(users[i].BankCart);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message); Console.ReadKey();
                                }
                            }
                            else if (choice == "3")
                            {
                                Console.Clear();
                                ATM();
                                if (info.Length != 0)
                                {
                                    foreach (var item in info)
                                    {
                                        Console.WriteLine(item);
                                    }
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("Emeliyyat yoxdur");
                                    Console.ReadKey();
                                }
                            }
                            else if (choice == "4")
                            {
                                Console.Clear();
                                ATM();
                                Console.Write("PAN daxil edin : ");
                                string pan1 = Console.ReadLine();
                                CartToCart(users[i], users, pan1);
                                NotificationCartToCart(users[i].BankCart, pan1, users);
                            }
                            else if (choice == "5")
                            {
                                Console.Clear();
                                ATM();

                                users[i].BankCart.Credit();
                            }
                        }
                    }
                }
                Console.WriteLine("Istifadeci tapilmadi. Zehmet olmasa tekrar daxil edesiniz ! "); Console.WriteLine();
            }
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Controller.Start();
        }
    }
}