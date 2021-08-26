using System;
using System.Collections.Generic;
using BEZAO_PayDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BEZAO_PayDAL.DataInitializer
{
    internal static class DataInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            var Users = new List<User>
            {
                 new User
                 {
                     Id= 1,
                     Name = "Francis Sorry",
                     Email = "sorry.sir@abeg.com",Birthday = new DateTime(1990,10,24),
                     Created = DateTime.Now,
                     IsActive = true,
                     AccountId=1
                 },
                 new User
                 {
                     Id= 2,
                     Name = "GrandMaster KC",
                     Birthday = new DateTime(1420,10,30),
                     Email = "badguy@BBA.com",
                     Created = DateTime.Now, IsActive = true,
                     AccountId=2
                 },

                 new User
                 {
                     Id= 3,
                     Name = "Dara John",
                     Birthday = new DateTime(1420,10,30),
                     Email = "dara.sage@ned.com",
                     Created = DateTime.Now, IsActive = true,
                     AccountId=3
                 },

                 new User
                 {
                     Id= 4,
                     Name = "Kachi !Thename",
                     Birthday = new DateTime(1420,10,30),
                     Email = "sadboy@BBA.com",
                     Created = DateTime.Now, IsActive = true,
                    AccountId=4
                 },


                 new User
                 {
                     Id= 5,
                     Name = "Sammy ROCBAFDEZ",
                     Birthday = new DateTime(1420,10,30),
                     Email = "omo@BBA.com",
                     Created = DateTime.Now, IsActive = true,
                     AccountId=5, 
                 },

            };

            var Accounts = new List<Account>
            {
                new Account { Id= 1, AccountNumber= 0760015555, Balance= 23_456_782_340  },
                new Account { Id= 2, AccountNumber= 0222833403, Balance= 56_000_000_000 },
                new Account { Id= 3, AccountNumber= 0456723646, Balance= 78_345_678_230 },
                new Account { Id= 4, AccountNumber= 1642347213, Balance= 63_723_456_780 },
                new Account { Id= 5, AccountNumber= 0753485382, Balance= 88_978_234_000 },
            };

            var Transactions = new List<Transaction>
            {
                new Transaction { Id= 1, Amount=50000000, TransactionMode= TransactionMode.Credit, UserId= 1, TimeStamp = new DateTime(2021, 10, 24) ,},
                new Transaction { Id= 2, Amount=60000000, TransactionMode= TransactionMode.Credit, UserId= 2, TimeStamp = new DateTime(2022, 10, 24)  },
                new Transaction { Id= 3, Amount=70000000, TransactionMode= TransactionMode.Credit, UserId= 3, TimeStamp = new DateTime(2023, 10, 24)  },
                new Transaction { Id= 4, Amount=80000000, TransactionMode= TransactionMode.Credit, UserId= 4, TimeStamp = new DateTime(2024, 10, 24)  },
                new Transaction { Id= 5, Amount=90000000, TransactionMode= TransactionMode.Credit, UserId= 5, TimeStamp = new DateTime(2025, 10, 24)  }
            };

            modelBuilder.Entity<Account>().HasData(Accounts);
           //modelBuilder.Entity<User>().HasData(Users);
           // modelBuilder.Entity<Transaction>().HasData(Transactions);

        }
    }
}
