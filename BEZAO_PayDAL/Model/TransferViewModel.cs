using BEZAO_PayDAL.Interfaces;

namespace BEZAO_PayDAL.Model
{
    public class TransferViewModel : IViewModel
    {
        public int SenderAccountNumber { get; set; }
        public int RecipientAccountNumber { get; set; }
        public decimal Amount { get; set; }
    }
}