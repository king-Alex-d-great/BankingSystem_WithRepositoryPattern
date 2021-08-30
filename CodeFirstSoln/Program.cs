using System;
using BEZAO_PayDAL.Entities;
using BEZAO_PayDAL.Interfaces.Services;
using BEZAO_PayDAL.Model;
using BEZAO_PayDAL.Services;
using BEZAO_PayDAL.UnitOfWork;

namespace CodeFirstSoln
{
    partial class Program
    {

        static void Main(string[] args)
        {
            Run();

            //return SelectedLanguageOption;

            //EnrollUser(); 
            //Login();
            //UpdateUser(); 
            //GetUsers(); 
            //DeleteUSer();
            /*GetAccounts();
            Transfer();
            Deposit();
            Withdrawal();*/

        }

        static void EnrollUser()
        {
            try
            {


                Console.WriteLine("Enter your firstname");
                var firstname = Console.ReadLine();
                Console.WriteLine("Enter your lastname");
                var lastname = Console.ReadLine();
                Console.WriteLine("Enter your Email");
                var email = Console.ReadLine();
                Console.WriteLine("Would you like your email to also be your username?\n 1: Yes\n2: No");
                var emailAsUsernameReply = Console.ReadLine();
                string username;
                if (emailAsUsernameReply == "1")
                {
                    username = email;
                }
                else
                {
                    Console.WriteLine("Enter your username");
                    username = Console.ReadLine();
                }
                Console.WriteLine("Enter your password");
                var password = Console.ReadLine();
                Console.WriteLine("Enter Confirm password ");
                var cPassword = Console.ReadLine();

                IUserService userService = new UserService(new UnitOfWorkMAin(new BezaoPayContext()));
                userService.Register(new RegisterViewModel
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Email = email,
                    Username = username,
                    Birthday = new DateTime(2000, 01, 22),
                    Password = password,
                    ConfirmPassword = cPassword
                });
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
        public static void Login()
        {
            try
            {
                // start:
                Console.WriteLine("Enter your username");
                var username = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(username))
                {
                    UserService.ErrorMessage("username", out int count);
                    if (count >= 2)
                        return;
                }
                Console.WriteLine("Enter your password");
                var password = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(password))
                {
                    UserService.ErrorMessage("password", out int count);
                    if (count >= 2)
                        return;
                }
                IUserService userService = new UserService(new UnitOfWorkMAin(new BezaoPayContext()));
                var LoggedInUser = userService.Login(new LoginViewModel { Password = password, UsernameEmail = username }, out Account account);

                if (LoggedInUser != null)
                {
                    MainMenu(LoggedInUser, account);
                }
                else
                {
                    DisplayPrompt();
                    return;
                }
                return;
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

        }
        public static void UpdateUser()
        {
            IUserService userService = new UserService(new UnitOfWorkMAin(new BezaoPayContext()));
            userService.Update(new UpdateViewModel { Email = "Alexagmail.com", NewPassword = "77888", CurrentPassword = "1234", ConfirmNewPassword = "77888" }, 4);
        }
        public static void DeleteUSer()
        {
            IUserService userService = new UserService(new UnitOfWorkMAin(new BezaoPayContext()));
            int AffectedRow;
            userService.Delete(7, out AffectedRow);
        }
        public static void GetUsers()
        {
            IUserService userService = new UserService(new UnitOfWorkMAin(new BezaoPayContext()));
            userService.Get(4);
        }

        public static void GetAccounts()
        {
            IAccountService accountService = new AccountService(new UnitOfWorkMAin(new BezaoPayContext()));
            accountService.Get(2);
        }

        public static void GetBalance(User user)
        {
            try
            {
                IAccountService accountService = new AccountService(new UnitOfWorkMAin(new BezaoPayContext()));
                accountService.checkBalance(user);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

        }
        public static void Transfer(Account account)
        {
            int count = 0;
            int countTwo = 0;
        start:
            Console.WriteLine("How much will you like to transfer?");
            int recipientAccountNumber = 0;
            decimal amount = 0;
            try
            {
                amount = Convert.ToDecimal(Console.ReadLine());
            startTwo:
                Console.WriteLine("Enter receiver's account number");
                try
                {
                    recipientAccountNumber = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    if (recipientAccountNumber + 0 == 0 && countTwo < 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid account number\nTry again");
                        Console.ForegroundColor = ConsoleColor.White;
                        countTwo++;
                        goto startTwo;
                    }
                    if (countTwo >= 2)
                    {
                        DisplayPrompt();
                        return;
                    }
                       
                }

                ITransactionService TransService = new TransactionService(new UnitOfWorkMAin(new BezaoPayContext()));
                TransService.Transfer(new TransferViewModel { Amount = amount, RecipientAccountNumber = recipientAccountNumber, SenderAccountNumber = account.AccountNumber });
            }
            catch (FormatException)
            {
                if (amount + 0 == 0 && count != 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Amount cannot be empty\nTry again");
                    Console.ForegroundColor = ConsoleColor.White;

                    count++;
                    goto start;
                }
                if (count == 2)
                    DisplayPrompt();
            }
            catch (Exception error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error.Message);
                Console.ForegroundColor = ConsoleColor.White;
                DisplayPrompt();
            }
        }
        public static void Deposit(Account account)
        {
            int count = 0;
        start:
            Console.WriteLine("Enter amount being deposited");
            decimal amount = 0;
            try
            {
                amount = Convert.ToDecimal(Console.ReadLine());
                ITransactionService TransService = new TransactionService(new UnitOfWorkMAin(new BezaoPayContext()));
                TransService.Deposit(new DepositViewModel { Amount = amount, RecipientAccountNumber = account.AccountNumber });
            }
            catch (FormatException)
            {
                if (amount + 0 == 0 && count != 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Amount cannot be empty\nTry again");
                    Console.ForegroundColor = ConsoleColor.White;

                    count++;
                    goto start;
                }
                if (count == 2)
                    DisplayPrompt();
            }
            catch (Exception error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error.Message);
                Console.ForegroundColor = ConsoleColor.White;
                DisplayPrompt();
            }
        }
        public static void Withdrawal(Account account)
        {
            int count = 1;
        start:
            Console.WriteLine("How much will you like to withdraw?");
            decimal amount = 0;
            try
            {
                amount = Convert.ToDecimal(Console.ReadLine());
                ITransactionService TransService = new TransactionService(new UnitOfWorkMAin(new BezaoPayContext()));
                TransService.Withdraw(new WithdrawalViewModel { Amount = amount, AccountNumber = account.AccountNumber });

            }
            catch (FormatException)
            {
                if (amount + 0 == 0 && count != 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Amount cannot be empty\nTry again");
                    Console.ForegroundColor = ConsoleColor.White;

                    count++;
                    goto start;
                }
                if (count == 2)
                    DisplayPrompt();
            }
            catch (Exception error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error.Message);
                Console.ForegroundColor = ConsoleColor.White;
                DisplayPrompt();
            }

        }

    }
}
