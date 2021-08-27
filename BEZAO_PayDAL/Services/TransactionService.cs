using System;
using System.Linq;
using BEZAO_PayDAL.Entities;
using BEZAO_PayDAL.Interfaces.Services;
using BEZAO_PayDAL.Model;
using BEZAO_PayDAL.UnitOfWork;

namespace BEZAO_PayDAL.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Deposit(DepositViewModel model)
        {
            try
            {
                var account = _unitOfWork.Accounts.Find(a => a.AccountNumber == model.RecipientAccountNumber).FirstOrDefault();
                if (account != null)
                {
                    Console.WriteLine("Deposit Started");
                    account.Balance += model.Amount;
                    _unitOfWork.Transactions.Add(new Transaction { Amount = model.Amount, TimeStamp = DateTime.Now, TransactionMode = TransactionMode.Credit, UserId = account.Id });
                    _unitOfWork.Commit();
                    Console.WriteLine("Deposit Successful");
                    Console.WriteLine($"Account Balance : {account.Balance}" );
                    return;
                }
                Console.WriteLine("Deposit failed\nUser not found");
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }

        public void Transfer(TransferViewModel model)
        {
            try
            {
                var senderAccount = _unitOfWork.Accounts.Find(a => a.AccountNumber == model.SenderAccountNumber).FirstOrDefault();
                var receiverAccount = (Account)_unitOfWork.Accounts.Find(a => a.AccountNumber == model.RecipientAccountNumber).FirstOrDefault();

                if (senderAccount != null && receiverAccount != null)
                {
                    senderAccount.Balance -= model.Amount;
                    receiverAccount.Balance += model.Amount;

                    _unitOfWork.Transactions.Add(new Transaction { Amount = model.Amount, TimeStamp = DateTime.Now, TransactionMode = TransactionMode.Credit, UserId = receiverAccount.Id });
                    _unitOfWork.Transactions.Add(new Transaction { Amount = model.Amount, TimeStamp = DateTime.Now, TransactionMode = TransactionMode.Debit, UserId = senderAccount.Id });
                    _unitOfWork.Commit();
                    Console.WriteLine("Transfer Successful");
                    return;
                }
                Console.WriteLine("Transfer failed\n Please check that the account numbers supplied are valid!");
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

        }

        public void Withdraw(WithdrawalViewModel model)
        {
            try
            {
                var account = _unitOfWork.Accounts.Find(a => a.AccountNumber == model.AccountNumber).FirstOrDefault();
                if (account != null)
                {
                    if (account.Balance > model.Amount)
                    {
                        account.Balance -= model.Amount;
                        Console.WriteLine("\nIn what denominations will you like your cash to be \n1. 1000 Naira\n2. 500 Naira");                        
                        int UserReply = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Collect your cash\n");// CurrrencyNoteCount //ADD CoLOR

                        if (UserReply == 1)
                        {
                            Console.WriteLine($"There are {model.Amount / 1000} notes of 1000 Naira , amounting to {model.Amount } \n");                            
                        }
                        if (UserReply == 2)
                        {
                           Console.WriteLine($"There are {model.Amount / 500} notes of 500 Naira , amounting to {model.Amount} \n");
                        }
                        _unitOfWork.Transactions.Add(new Transaction { Amount = model.Amount, TimeStamp = DateTime.Now, TransactionMode = TransactionMode.Debit, UserId = account.Id });
                        _unitOfWork.Commit();
                        return;
                    }
                }
                Console.WriteLine("Invalid account number");
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}
