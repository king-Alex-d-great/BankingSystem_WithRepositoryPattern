using System;
using System.Collections.Generic;
using System.Text;
using BEZAO_PayDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BEZAO_PayDAL.Repositories
{
    public class TransactionRepository : Repository<Transaction>,  ITransactionRepository
    {
        private readonly DbContext _context;
        public TransactionRepository(DbContext context) : base(context)
        {
            _context = context;
        }
    }
}


