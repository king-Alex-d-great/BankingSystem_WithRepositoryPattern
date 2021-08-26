using System;
using System.Collections.Generic;
using System.Text;
using BEZAO_PayDAL.Entities;
using BEZAO_PayDAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BEZAO_PayDAL.Repositories
{
   public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DbContext _context;               

        public UserRepository(DbContext context):
            base(context)
        {
            _context = context;
        }
    }

    
}
