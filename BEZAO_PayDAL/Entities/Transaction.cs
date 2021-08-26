using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BEZAO_PayDAL.Entities
{
  public  class Transaction
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public TransactionMode TransactionMode { get; set; }

        [Column(TypeName = "decimal(38,2)")]
        public decimal Amount { get; set; }

        public DateTime TimeStamp { get; set; }

    }
}
