using BEZAO_PayDAL.Model;

namespace BEZAO_PayDAL.Interfaces.Services
{
    public interface ITransactionService
    {
        void Deposit(DepositViewModel model);
        void Withdraw(WithdrawalViewModel model);
        void Transfer(TransferViewModel model);

    }
}