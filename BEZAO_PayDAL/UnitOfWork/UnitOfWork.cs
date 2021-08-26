using System;
using System.Collections.Generic;
using System.Text;
using BEZAO_PayDAL.Entities;
using BEZAO_PayDAL.Interfaces;
using BEZAO_PayDAL.Repositories;

namespace BEZAO_PayDAL.UnitOfWork
{
    class UnitOfWork : IUnitOfWork
    {
        private BezaoPayContext _context;

        private IRepository<Transaction> _transactions;
        private IRepository<Account> _accounts;
        private IRepository<User> _users;

        public UnitOfWork(BezaoPayContext context)
        {
            _context = context;
        }

        public IRepository<Transaction> Transactions { get { return _transactions ??= (_transactions = new Repository<Transaction>(_context)); } } 
        public IRepository<Account> Accounts { get { return _accounts ??= (_accounts = new Repository<Account>(_context)); } } 
        public IRepository<User> Users { get { return _users ??= (_users = new Repository<User>(_context)); } }
       
        public void commit()
        {
            _context.SaveChanges();
        }        

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
