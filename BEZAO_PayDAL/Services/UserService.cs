using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using BEZAO_PayDAL.Encryption;
using BEZAO_PayDAL.Entities;
using BEZAO_PayDAL.Interfaces.Services;
using BEZAO_PayDAL.Model;
using BEZAO_PayDAL.UnitOfWork;

namespace BEZAO_PayDAL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Register(RegisterViewModel model)
        {
           
            var salt = Hasher.getSalt();
            try
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
                    Password = Hasher.hashPassword(Encoding.UTF8.GetBytes(model.ConfirmPassword), Encoding.UTF8.GetBytes(salt)),
                    Account = new Account { AccountNumber = RandomNumberGenerator.GetInt32(999999999)},                    
                    Created = DateTime.Now,
                    Salt = salt
                };

                _unitOfWork.Users.Add(user);
                _unitOfWork.Commit();
                Console.WriteLine("Success!\n");
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                Console.WriteLine(error.InnerException);
            }
        }

        public int Update(UpdateViewModel model, int Id)
        {
            int affectedRow = 0;
            try
            {
                var user = _unitOfWork.Users.Get(Id);
                var salt = user.Salt;
                user.Email = model.Email ??= user.Email;
                user.Username = model.Username ??= user.Username;
                var currenthashedpassword = Hasher.hashPassword(Encoding.UTF8.GetBytes(model.CurrentPassword), Encoding.UTF8.GetBytes(salt));
                Console.WriteLine(currenthashedpassword);
                Console.WriteLine(user.Password);
                Console.WriteLine(salt);
                if (currenthashedpassword == user.Password && !string.IsNullOrWhiteSpace(model.CurrentPassword))
                {

                    if (model.NewPassword == model.ConfirmNewPassword && !string.IsNullOrWhiteSpace(model.NewPassword))
                    {
                        user.Password = Hasher.hashPassword(Encoding.UTF8.GetBytes(model.ConfirmNewPassword), Encoding.UTF8.GetBytes(salt));
                        affectedRow = _unitOfWork.Commit();
                        Console.WriteLine("User Updated successfully\n\n");
                        return affectedRow;
                    }
                    Console.WriteLine("Confirm password field did not match newpassword field ");
                }
                return affectedRow;
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            return 0;
        }

        public User Login(LoginViewModel model, out Account account)
        {
            bool isValidated = false;
            Console.ForegroundColor = ConsoleColor.White;

            model.UsernameEmail = model.UsernameEmail.Trim().ToLower();
            model.Password = model.Password.Trim().ToLower();
            isValidated = AuthenticateUser(model.UsernameEmail, model.Password, out User user);
           // account = _unitOfWork.Accounts.Find(a => a.Id == user.AccountId).FirstOrDefault();
            if (!isValidated)
            {
                account = null;
                Console.WriteLine("Invalid Username or password\n");
                return null; 
            }
            account = _unitOfWork.Accounts.Find(a => a.Id == user.AccountId).FirstOrDefault();
            Console.WriteLine(" login Successful\n\n");
            Console.WriteLine(account.Balance);
            return user;            
        }

        public User Delete(int id, out int affectedRow)
        {
            affectedRow = 0;
            try
            {
                var result = _unitOfWork.Users.Get(id);
                _unitOfWork.Users.Delete(result);
                affectedRow = _unitOfWork.Commit();
                Console.WriteLine($"User : {id} deleted\n\n");
                return result;
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            return null;
        }

        public void Get(int id)
        {
            try
            {
                var user = _unitOfWork.Users.Get(id);
                Console.WriteLine(user.Email);
                Console.WriteLine(user.Name);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }

        private bool Validate(RegisterViewModel model)
        {
            var error = string.IsNullOrWhiteSpace(model.Email) ? ErrorMessage("Email", out int count) :
            string.IsNullOrWhiteSpace(model.FirstName) ? ErrorMessage("FirstName", out count) :
            string.IsNullOrWhiteSpace(model.LastName) ? ErrorMessage("LastName", out count) :
            model.Birthday == new DateTime() ? "Invalid date" :
            string.IsNullOrWhiteSpace(model.Password) ? ErrorMessage("Password", out count) : string.Empty;

            if (string.IsNullOrWhiteSpace(error))
            {
                return true;
            }
            return false;
        }
        public static string ErrorMessage(string name, out int count)
        {
            count = 0;
            while (true && count < 2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nError Alert");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($" Your {name} cannot be empty\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"You have {2 - count} more chances\n");
                Console.WriteLine($"Please Input your {name}\n");
                var Input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(Input))
                {
                    break;
                }
                count++;
            }
            if (count >= 2)
            {
                Console.WriteLine("You've Exhausted your chances. ");
                return string.Empty;
            }
            return "yoo";
        }

        public bool AuthenticateUser(string userNameEmail, string password, out User user)
        {
            user = null;
            var isValidated = false;

            user = _unitOfWork.Users.Find(a => a.Username == userNameEmail || a.Email == userNameEmail).FirstOrDefault();

            if (user == null)
                return false;

            var salt = user.Salt;
            var saltedLoginPassword = Hasher.hashPassword(Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(salt));

            if (saltedLoginPassword == user.Password)
            {
                isValidated = true;
                return isValidated;
            }
            Console.WriteLine("Your username or password is Incorrect\nIf you are a new user , please click 1 to register\n");
            return isValidated;
        }

    }
}

