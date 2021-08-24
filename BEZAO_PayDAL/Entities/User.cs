using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BEZAO_PayDAL.Entities
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [MinLength(4)]
        public string Name { get; set; }

        
        [MaxLength(50)]
        public string Email { get; set; }

        public DateTime Birthday { get; set; }

        public bool IsActive { get; set; }

        public DateTime Created { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }

    }
}
