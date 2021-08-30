using System;
using System.Collections.Generic;
using System.Text;
using BEZAO_PayDAL.Interfaces;

namespace BEZAO_PayDAL.Model
{
    public class DepositViewModel : IViewModel
    {
        public int RecipientAccountNumber { get; set; }
        public decimal Amount { get; set; }

    }

}
