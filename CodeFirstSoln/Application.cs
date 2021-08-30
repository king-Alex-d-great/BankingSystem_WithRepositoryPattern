using System;
using System.Text;
using BEZAO_PayDAL.Entities;
using BEZAO_PayDAL.Helpers;
using BEZAO_PayDAL.Interfaces.Services;
using BEZAO_PayDAL.Services;
using BEZAO_PayDAL.UnitOfWork;

namespace CodeFirstSoln
{
    partial class Program
    {
        private static readonly StringBuilder StringBuilder = new StringBuilder();
        static IUserService userService = new UserService(new UnitOfWorkMAin(new BezaoPayContext()));
        private static readonly Logger Logger = new Logger();
        public static void Run()
        {

            Console.WriteLine("Welcome to Kings ATM");
        mainmenu:
            StringBuilder.Clear();
            StringBuilder.AppendLine("Press:");
            StringBuilder.AppendLine("  1. Login");
            StringBuilder.AppendLine("  2. Register");
            StringBuilder.AppendLine("  3. Exit");
            Console.WriteLine(StringBuilder.ToString());

            switch (Console.ReadLine())
            {
                case "1":
                    Login();
                    break;

                case "2":
                    EnrollUser();
                    DisplayPrompt();
                    break;

                case "3":

                    Logger.LogLine("\nThanks and GoodBye!...\nRun the App to use again!...\n");
                    break;
                default:
                    Logger.LogLine("\nInvalid input...\nTry Again!!\n");
                    goto mainmenu;
            }
        }

        public static void MainMenu(User user, Account account)
        {
            Console.WriteLine($"Welcome {user.Name}\n");
            Logger.LogLine("Press 1 : Deposit \nPress 2 : Withdraw cash \nPress 3 : Transfer\nPress 4 : Check balance\nPress Any other key : Exit\n ");
            switch (Console.ReadLine())
            {
                case "1":
                    Deposit(account);
                    DisplayPrompt();
                    break;
                case "2":
                    Withdrawal(account);
                    DisplayPrompt();
                    break;
                case "3":
                    Transfer(account);
                    DisplayPrompt();
                    break;
                case "4":
                    GetBalance(user);
                    DisplayPrompt();
                    break;
                default:
                    {
                        Logger.LogLine("Thank you for Using this service\n");
                        break;
                    }
            }

        }
        static void DisplayPrompt()
        {
            Logger.LogLine("\nDo you want to perform another operation? \n1. Yes\n2. Any other Key to exit!\n");
            switch (Console.ReadLine())
            {
                case "1":

                    Login();
                    break;
                default:
                    Console.WriteLine("Thank you for Using this service\n");
                    break;
            };
        }

    }
}
