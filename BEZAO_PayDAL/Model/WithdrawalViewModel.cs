using BEZAO_PayDAL.Interfaces;

namespace BEZAO_PayDAL.Model
{
    public class WithdrawalViewModel : IViewModel
    {
        public int AccountNumber { get; set; }
        public decimal Amount { get; set; }

    }
}