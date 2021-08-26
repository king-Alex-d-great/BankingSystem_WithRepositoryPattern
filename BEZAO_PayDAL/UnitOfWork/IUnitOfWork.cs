using System;
using System.Collections.Generic;
using System.Text;
using BEZAO_PayDAL.Entities;
using BEZAO_PayDAL.Interfaces;

namespace BEZAO_PayDAL.UnitOfWork
{
    interface IUnitOfWork : IDisposable
    {
        IRepository<Transaction> Transactions { get; }
        IRepository<Account> Accounts { get; }
        IRepository<User> Users { get; }
        void commit();       
    }
}
