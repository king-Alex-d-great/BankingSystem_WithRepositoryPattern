using System;
using System.Collections.Generic;
using System.Text;
using BEZAO_PayDAL.Entities;
using BEZAO_PayDAL.Interfaces.Services;
using BEZAO_PayDAL.Model;
using BEZAO_PayDAL.UnitOfWork;

namespace BEZAO_PayDAL.Services
{
  public  class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Register(RegisterViewModel model)
        {

            if (!Validate(model))
            {
                return;
            }

            var user = new User
            {
                Name = $"{model.FirstName} {model.LastName}",
                Email = model.Email,
                Username = model.Username,
                Birthday = model.Birthday,
                IsActive = true,
                Password = model.ConfirmPassword,
                Account = new Account{AccountNumber = 1209374652},
                Created = DateTime.Now
            };
            _unitOfWork.Users.Add(user);
            _unitOfWork.Commit();
            Console.WriteLine("Success!");
        }

        public void Update(UpdateViewModel model)
        {
            throw new NotImplementedException();
        }

        public void Login(LoginViewModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Get(int id)
        {
            throw new NotImplementedException();
        }

        private bool Validate(RegisterViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Email) 
                || string.IsNullOrWhiteSpace(model.FirstName) 
                || string.IsNullOrWhiteSpace(model.LastName) 
                || (model.Birthday == new DateTime()) 
                || (string.IsNullOrWhiteSpace(model.Password))
                || (model.Password != model.ConfirmPassword))
            {
                Console.WriteLine("A field is required");
                return false;

            }

            return true;

        }
    }
}
