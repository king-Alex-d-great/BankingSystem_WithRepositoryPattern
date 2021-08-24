using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text;

namespace BEZAO_PayDAL.Entities
{
   public class Account
    {
        public int Id { get; set; }

        [MaxLength(10)]
        [MinLength(10)]
        public int AccountNumber { get; set; }

        [Column(TypeName ="decimal(38,2)")]
        public decimal Balance { get; set; }

    }
}
