using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using BEZAO_PayDAL.DataInitializer;
using Microsoft.Extensions.Configuration;

namespace BEZAO_PayDAL.Entities
{
   public class BezaoPayContext : DbContext
    {
        //private string connectionString;
        public BezaoPayContext(){          
        }
        public BezaoPayContext(DbContextOptions<BezaoPayContext> options):
            base(options)
        {
            /*var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);
            var configuration = builder.Build();
            var connectionString = configuration.GetConnectionString("SqlConnection");*/
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
          
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CFBEZAOPay; Integrated Security=True;Connect Timeout=30;  ");
           
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
