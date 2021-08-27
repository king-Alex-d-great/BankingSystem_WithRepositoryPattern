using System;
using System.Collections.Generic;
using System.Text;
using BEZAO_PayDAL.Entities;
using BEZAO_PayDAL.Interfaces.Services;
using BEZAO_PayDAL.UnitOfWork;

namespace BEZAO_PayDAL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Account Get(int userId)
        {
            Account account = null;
            try
            {
               account = _unitOfWork.Accounts.Get(userId);
                Console.WriteLine(account.AccountNumber);
                Console.WriteLine(account.Balance);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
                return account;

        }
    }
}
