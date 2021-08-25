using System;
using System.Collections.Generic;
using System.Linq;
using BEZAO_PayDAL.Entities;
using BEZAO_PayDAL.Repositories;
using BEZAO_PayDAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstSoln
{
    class Program
    {
        static void Main(string[] args)
        {
          var dbContext = new BezaoPayContext();

            // dbContext.Users.Add(
            //     new User
            //     {
            //         Name = "Francis Sorry",
            //         Email = "sorry.sir@abeg.com", 
            //         Account = new Account{AccountNumber = 0923746523, Balance = 6_000_000},
            //         Birthday = new DateTime(1990,10,24), Created = DateTime.Now
            //     });

            //   dbContext.Users.AddRange(new List<User>
            // {
            //     new User
            //     {
            //         Name = "GrandMaster KC", 
            //         Birthday = new DateTime(1420,10,30),
            //         Email = "badguy@BBA.com",
            //         Account = new Account{Balance = 2_000_000, AccountNumber = 0182341233},
            //         Created = DateTime.Now, IsActive = true
            //     },
            //
            //     new User
            //     {
            //         Name = "Dara John",
            //         Birthday = new DateTime(1420,10,30),
            //         Email = "dara.sage@ned.com",
            //         Account = new Account{Balance = 2_000_000, AccountNumber = 0185641233},
            //         Created = DateTime.Now, IsActive = true
            //     },
            //
            //     new User
            //     {
            //         Name = "Kachi !Thename",
            //         Birthday = new DateTime(1420,10,30),
            //         Email = "sadboy@BBA.com",
            //         Account = new Account{Balance = 2_000_000, AccountNumber = 0182341233},
            //         Created = DateTime.Now, IsActive = true
            //     },
            //
            //
            //     new User
            //     {
            //         Name = "Sammy ROCBAFDEZ",
            //         Birthday = new DateTime(1420,10,30),
            //         Email = "omo@BBA.com",
            //         Account = new Account{Balance = 2_000_000, AccountNumber = 0182341233},
            //         Created = DateTime.Now, IsActive = true
            //     },
            // });

            // dbContext.SaveChanges();



            // var users = dbContext.Users.AsQueryable();
            var users = dbContext.Users;
            var userAccounts = dbContext.Users.Include(u => u.Account);
            // var users = dbContext.Users.ToList();

        foreach (var user in users)
        {
            Console.WriteLine($"{user.Name} {user.Email} {user.IsActive}");
        }

        Console.WriteLine("-----------All Customers with Repo------------------");

        IUserRepository userRepository = new UserRepository(dbContext);

        foreach (var user in userRepository.GetAll().ToList())
        {
            Console.WriteLine($"{user.Name} {user.Email} {user.IsActive}");
            }

            Console.WriteLine("-----------with account------------------");

        foreach (var userAccount in userAccounts)
        {
            Console.WriteLine($"Name: {userAccount.Name}, : {userAccount.Account.AccountNumber}, Balance: {userAccount.Account.Balance} ");
        }


        Console.WriteLine("-----------Active Customers------------------");

        foreach (var userAccount in userAccounts.Where(u => u.IsActive))
        {
            Console.WriteLine($"Name: {userAccount.Name}, : {userAccount.Account.AccountNumber}, Balance: {userAccount.Account.Balance} ");
        }

            Console.WriteLine("Done!");


            Console.WriteLine("-----------Single Customer------------------");

          var oneCustomer =  userAccounts.FirstOrDefault();

          var someUser = dbContext.Users.Find(1);
          dbContext.Users.Remove(someUser);

          dbContext.SaveChanges();


            //update
        oneCustomer.Name = "Pope Francis";
        oneCustomer.Account.Balance += 1_000;

         



          dbContext.SaveChanges();


          Console.WriteLine(oneCustomer?.Name ?? "No Name");
          Console.WriteLine(oneCustomer?.Account.Balance ?? 0);

        }



        
    }
}
