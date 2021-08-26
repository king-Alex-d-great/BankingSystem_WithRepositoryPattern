using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BEZAO_PayDAL.Entities;
using BEZAO_PayDAL.Interfaces.Repositories;

namespace BEZAO_PayDAL.UnitOfWork
{
   public interface IUnitOfWork : IDisposable
    {
        IRepository<Transaction> Transactions { get; }
        IRepository<Account> Accounts { get; }
        IRepository<User> Users { get; }
        Task<int> CommitAsync();
        int Commit();       
    }
}
