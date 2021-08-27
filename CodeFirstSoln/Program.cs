using System;
using System.Collections.Generic;
using System.Linq;
using BEZAO_PayDAL.Entities;
using BEZAO_PayDAL.Interfaces.Repositories;
using BEZAO_PayDAL.Interfaces.Services;
using BEZAO_PayDAL.Model;
using BEZAO_PayDAL.Repositories;
using BEZAO_PayDAL.Services;
using BEZAO_PayDAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstSoln
{
    partial class Program
    {
        static void Main(string[] args)
        {
            //EnrollUser(); workin
            //Login(); working
            // UpdateUser(); workin
            //getUsers(); workin
            //DeleteUSer(); workin
            //GetAccounts(); workin
            //Transfer(); working
            // Deposit(); working
            //Withdrawal(); workin

        }

        static void EnrollUser()
        {
            IUserService userService = new UserService(new UnitOfWork(new BezaoPayContext()));
            userService.Register(new RegisterViewModel{FirstName = "Junior", LastName = "Nwokolo", Email = "junior.sage@omekannaya.com", Username = "Sage",
            Birthday = new DateTime(2000, 01, 22), Password = "1234@one", ConfirmPassword = "1234@one"});            
        }
        static void Login ()
        {
            IUserService userService = new UserService(new UnitOfWork(new BezaoPayContext()));
            userService.Login(new LoginViewModel { Password = "1234", UsernameEmail = "darajohn" });
        }
        static void UpdateUser ()
        {
            IUserService userService = new UserService(new UnitOfWork(new BezaoPayContext()));
            userService.Update(new UpdateViewModel { Email = "Alexandra@gmail.com",  }, 2 );
        }
        static void DeleteUSer ()
        {
            IUserService userService = new UserService(new UnitOfWork(new BezaoPayContext()));
            int AffectedRow;
            userService.Delete(6, out AffectedRow);
        }
        static void GetUsers ()
        {
            IUserService userService = new UserService(new UnitOfWork(new BezaoPayContext()));
            userService.Get(3);
        }

        static void GetAccounts ()
        {
            IAccountService accountService = new AccountService(new UnitOfWork(new BezaoPayContext()));
            accountService.Get(2);
        }
        static void Transfer ()
        {
            ITransactionService TransService = new TransactionService(new UnitOfWork(new BezaoPayContext()));
            TransService.Transfer(new TransferViewModel { Amount = 500000, RecipientAccountNumber = 0760015555, SenderAccountNumber = 0222833403 });
        }
        static void Deposit ()
        {
            ITransactionService TransService = new TransactionService(new UnitOfWork(new BezaoPayContext()));
            TransService.Deposit(new DepositViewModel { Amount = 4000000, RecipientAccountNumber = 0760015555 });
        }
        static void Withdrawal ()
        {
            ITransactionService TransService = new TransactionService(new UnitOfWork(new BezaoPayContext()));
            TransService.Withdraw(new WithdrawalViewModel { Amount = 75000000, AccountNumber = 0760015555 });
        }
    }
}
