using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BEZAO_PayDAL.Entities;
using BEZAO_PayDAL.Interfaces.Repositories;
using BEZAO_PayDAL.Repositories;

namespace BEZAO_PayDAL.UnitOfWork
{
    public class UnitOfWorkMAin : IUnitOfWork
    {
        private readonly BezaoPayContext _context;

        private IRepository<Transaction> _transactions;
        private IRepository<Account> _accounts;
        private IRepository<User> _users;

        public UnitOfWorkMAin(BezaoPayContext context)
        {
            _context = context;
        }

        public IRepository<Transaction> Transactions { get { return _transactions ??= _transactions = new TransactionRepository(_context); } } 
        public IRepository<Account> Accounts { get { return _accounts ??= _accounts = new AccountRepository(_context); } } 
        public IRepository<User> Users { get { return _users ??= _users = new UserRepository(_context); } }
       
        public int Commit()
        {
           return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
