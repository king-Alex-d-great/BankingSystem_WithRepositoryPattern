using System;
using System.Collections.Generic;
using System.Text;
using BEZAO_PayDAL.Entities;
using BEZAO_PayDAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BEZAO_PayDAL.Repositories
{
    class AccountRepository : Repository<Account>, IAccountRepository
    {
        private readonly DbContext _context;
        public AccountRepository (DbContext context) : base(context)
        {
            _context = context;
        }
    }
}
