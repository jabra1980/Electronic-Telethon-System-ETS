using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace Project_ETS_consoleApp
{
    
    public class Program
    {

        static void Main(string[] args)
        {
            ETS_Manager eTS_Manager = new ETS_Manager();

            int option = 0;

            Console.Write("\n\t\t\t\t\tElectronic Telethon System (ETS)\n");

            Console.Write("Username: ");
            string user = Console.ReadLine().ToLower();

            Console.Write("Password: ");
            string pass = Console.ReadLine().ToLower();

            Console.Clear();

            if (passVerifier(user, pass) == true)
            {
                do
                {   
                    mainMenu();
                    option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                           do
                           {
                                sponsorMenu();
                                option = Convert.ToInt32(Console.ReadLine());
                                switch (option)
                                {
                                    case 1:
                                        eTS_Manager.addSponsor();
                                        Console.Write("Press any key to continue...");
                                        Console.ReadKey();
                                        break;

                                    case 2:
                                        eTS_Manager.listSponsor();
                                        Console.Write("Press any key to continue...");
                                        Console.ReadKey();
                                        break;

                                    case 3:
                                        eTS_Manager.searchSponsor();
                                        Console.Write("Press any key to continue...");
                                        Console.ReadKey();
                                        break;

                                    case 4:
                                        mainMenu();
                                        break;

                                    default:
                                        Console.WriteLine("please, Choose between 1-3 or 4 to Main Menu");
                                        break;
                                }
                           } while (option != 4) ;
                            break;

                        case 2:
                            do
                            {
                                prizeMenu();
                                option = Convert.ToInt32(Console.ReadLine());
                                switch (option)
                                {
                                    case 1:
                                        eTS_Manager.addPrize();
                                        Console.Write("Press any key to continue...");
                                        Console.ReadKey();
                                        break;

                                    case 2:
                                        eTS_Manager.listPrize();
                                        Console.Write("Press any key to continue...");
                                        Console.ReadKey();
                                        break;

                                    case 3:
                                        eTS_Manager.searchPrize();
                                        Console.Write("Press any key to continue...");
                                        Console.ReadKey();
                                        break;

                                    case 4:
                                        mainMenu();
                                        break;

                                    default:
                                        Console.WriteLine("please, Choose between 1-3 or 4 to Main Menu");
                                        break;
                                }

                            } while (option != 4);
                            break;

                        case 3:
                            do
                            {
                                donorMenu();
                                option = Convert.ToInt32(Console.ReadLine());
                                switch (option)
                                {
                                    case 1:
                                        eTS_Manager.addDonor();
                                        Console.Write("Press any key to continue...");
                                        Console.ReadKey();
                                        break;

                                    case 2:
                                        eTS_Manager.listDonor();
                                        Console.Write("Press any key to continue...");
                                        Console.ReadKey();
                                        break;

                                    case 3:
                                        eTS_Manager.searchDonor();
                                        Console.Write("Press any key to continue...");
                                        Console.ReadKey();
                                        break;

                                    case 4:
                                        mainMenu();
                                        break;

                                    default:
                                        Console.WriteLine("please, Choose between 1-3 or 4 to Main Menu");
                                        break;
                                }
                            } while (option != 4);
                            break;

                        case 4:
                            do
                            {
                                donationMenu();
                                option = Convert.ToInt32(Console.ReadLine());
                                switch (option)
                                {
                                    case 1:
                                        eTS_Manager.addDonation();
                                        Console.Write("Press any key to continue...");
                                        Console.ReadKey();
                                        break;

                                    case 2:
                                        eTS_Manager.listDonation();
                                        Console.Write("Press any key to continue...");
                                        Console.ReadKey();
                                        break;

                                    case 3:
                                        eTS_Manager.searchDonation();
                                        Console.Write("Press any key to continue...");
                                        Console.ReadKey();
                                        break;

                                    case 4:
                                        mainMenu();
                                        break;

                                    default:
                                        Console.WriteLine("please, Choose between 1-3 or 4 to Main Menu");
                                        break;
                                }
                            } while (option != 4);
                            break;

                        case 5:
                            eTS_Manager.backupData();
                            Console.ReadKey();
                            break;

                        case 6:
                            Console.WriteLine("Thank you to using ETS Software");
                            break;

                        default:
                            Console.WriteLine("please, Choose between 1-6 or 7 to Exit");
                            break;
                    }

                } while (option != 6);

            }

        }
        
        private static bool passVerifier(string user, string pass)
        {
            int attempt = 1;
            bool flag = false;
            string fileName = "login.txt";
            string path = @"C:\Users\jabra\OneDrive\Desktop\Project_ETS_consoleApp\DBtxt\";


            using (StreamReader sr = new StreamReader(Path.Combine(path, fileName)))
            {

                while (sr.Peek() >= 1)
                {
                    string line = sr.ReadLine();
                    string[] lineArray = line.Split(',');

                    string username = lineArray[0];
                    string password = lineArray[1];

                    while (attempt != 3) {
                        
                        if (user.Equals(username) && pass.Equals(password))
                        {
                            flag = true;
                            break;
                        }

                        if (attempt < 3)
                        {
                            if (user != username && pass == password)
                            {
                                Console.Write($"Username is incorrect....!\tattempt No. {attempt}\n\n");
                                ++attempt;
                                Console.Write("Please, enter the username? ");
                                user = Console.ReadLine().ToLower();

                                Console.Write("Please, enter the pass? ");
                                pass = Console.ReadLine().ToLower();
                                
                            }
                            else if (user == username && pass != password)
                            {
                                Console.Write($"Password is incorrect....!\tattempt No. {attempt}\n\n");
                                ++attempt;
                                Console.Write("Please, enter the username? ");
                                user = Console.ReadLine().ToLower();

                                Console.Write("Please, enter the pass? ");
                                pass = Console.ReadLine().ToLower();
                                
                            }
                            else if (user != username && pass != password)
                            {
                                Console.Write($"Username and Password are incorrect....!\tattempt No. {attempt}\n\n");
                                ++attempt;
                                Console.Write("Please, enter the username? ");
                                user = Console.ReadLine().ToLower();

                                Console.Write("Please, enter the pass? ");
                                pass = Console.ReadLine().ToLower();
                                
                            }
                            
                        }
                        if (attempt == 3)
                        {
                            Console.WriteLine("Maximum number of attempts exceeded\n");
                            break;
                        }

                    }
                }
            }
            
            return flag;

        }

        private static void mainMenu()
        {
            
            Console.Clear();

            Console.Write("\n\t\t\t\t\tElectronic Telethon System (ETS)\n\n");

            Console.Write("\t\t\t\t\t\t   Main Menu\n\n");

            Console.WriteLine("1-   Sponsor");
            Console.WriteLine("2-   Prize");
            Console.WriteLine("3-   Donor");
            Console.WriteLine("4-   Donation");
            Console.WriteLine("5-   Backup Data to File");
            Console.WriteLine("6-   Exit");

            Console.Write("Please, Choose 1 - 5 or 6 to Exit: ");

        }

        private static void sponsorMenu()
        {
            Console.Clear();

            Console.Write("\n\t\t\t\t\tElectronic Telethon System (ETS)\n\n");

            Console.Write("\t\t\t\t\t\t   Sponsor Menu\n\n");

            Console.WriteLine("1-   Add Sponsor");
            Console.WriteLine("2-   List sponsors");
            Console.WriteLine("3-   Search Sponsor");
            Console.WriteLine("4-   Return To Menu");
            Console.Write("Please, Choose 1 - 3 or 5 to Main Menu: ");
        }

        private static void prizeMenu()
        {
            Console.Clear();

            Console.Write("\n\t\t\t\t\tElectronic Telethon System (ETS)\n\n");

            Console.Write("\t\t\t\t\t\t   Prize Menu\n\n");

            Console.WriteLine("1-   Add Prize");
            Console.WriteLine("2-   List Prizes");
            Console.WriteLine("3-   Search Prize");
            Console.WriteLine("4-   Return To Menu");
            Console.Write("Please, Choose 1 - 3 or 5 to Main Menu: ");
        }

        private static void donorMenu()
        {
            Console.Clear();

            Console.Write("\n\t\t\t\t\tElectronic Telethon System (ETS)\n\n");

            Console.Write("\t\t\t\t\t\t   Donor Menu\n\n");

            Console.WriteLine("1-   Add Donor");
            Console.WriteLine("2-   List Donors");
            Console.WriteLine("3-   Search Donor");
            Console.WriteLine("4-   Return To Menu");
            Console.Write("Please, Choose 1 - 3 or 5 to Main Menu: ");
        }

        private static void donationMenu()
        {
            Console.Clear();

            Console.Write("\n\t\t\t\t\tElectronic Telethon System (ETS)\n\n");

            Console.Write("\t\t\t\t\t\t   Donation Menu\n\n");

            Console.WriteLine("1-   Add Donation");
            Console.WriteLine("2-   List Donations");
            Console.WriteLine("3-   Search Donation");
            Console.WriteLine("4-   Return To Menu");
            Console.Write("Please, Choose 1 - 3 or 5 to Main Menu: ");
        }

    }
}
