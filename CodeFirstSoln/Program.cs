using System;
using System.Collections.Generic;
using System.Linq;
using BEZAO_PayDAL.Entities;
using BEZAO_PayDAL.Interfaces.Repositories;
using BEZAO_PayDAL.Interfaces.Services;
using BEZAO_PayDAL.Model;
using BEZAO_PayDAL.Repositories;
using BEZAO_PayDAL.Services;
using BEZAO_PayDAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstSoln
{
    partial class Program
    {
        static void Main(string[] args)
        {
           EnrollUser();
        }

        static void EnrollUser()
        {
            IUserService userService = new UserService(new UnitOfWork(new BezaoPayContext()));
            userService.Register(new RegisterViewModel{FirstName = "Junior", LastName = "Nwokolo", Email = "junior.sage@omekannaya.com", Username = "Sage",
                Birthday = new DateTime(2000, 01, 22), Password = "1234@one", ConfirmPassword = "1234@one"});
            
        }
    }
}
