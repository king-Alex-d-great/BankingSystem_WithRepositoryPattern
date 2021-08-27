using System;
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
                    Password = model.ConfirmPassword,
                    Account = new Account { AccountNumber = 1209374652 },
                    Created = DateTime.Now
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
            int affectedRow;
            try
            {
                var user = _unitOfWork.Users.Get(Id);
                
                user.Email = model.Email ??= user.Email;
                user.Username = model.Username ??= user.Username;

                if (model.CurrentPassword == user.Password && !string.IsNullOrWhiteSpace(model.CurrentPassword))
                {
                    if (model.NewPassword == model.ConfirmNewPassword && !string.IsNullOrWhiteSpace(model.NewPassword))
                    {
                        user.Password = model.NewPassword;
                    }
                    Console.WriteLine("Confirm password field did not match newpassword field ");
                }
                affectedRow = _unitOfWork.Commit();
                Console.WriteLine("User Updated successfully\n\n");
                return affectedRow;
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            return 0;
        }

        public void Login(LoginViewModel model)
        {
            Console.ForegroundColor = ConsoleColor.White;
            if (!string.IsNullOrWhiteSpace(model.UsernameEmail))
            {
                if (!string.IsNullOrWhiteSpace(model.Password))
                {
                    model.UsernameEmail = model.UsernameEmail.Trim().ToLower();
                    model.Password = model.Password.Trim().ToLower();
                    var isValidated = validateLoginDetails(model.UsernameEmail, model.Password, out User user);

                    if (isValidated)
                    {
                        Console.WriteLine(" login Successful\n\n");
                        Console.WriteLine($"Welcome {user.Name}");
                    }
                }
            }
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
            var error = string.IsNullOrWhiteSpace(model.Email) ? ErrorMenu("Email") :
            string.IsNullOrWhiteSpace(model.FirstName) ? ErrorMenu("FirstName") :
            string.IsNullOrWhiteSpace(model.LastName) ? ErrorMenu("LastName") :
            model.Birthday == new DateTime() ? "Invalid date" :
            string.IsNullOrWhiteSpace(model.Password) ? ErrorMenu("Password") :
            model.Password != model.ConfirmPassword ? "Your passwords dont match!" :
            string.Empty;

            if (string.IsNullOrWhiteSpace(error))
            {
                return true;
            }
            return false;
        }
        string ErrorMenu(string name)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nError Alert");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($" Your {name} cannot be empty\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Please Input your {name}\n");
                var Input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(Input))
                {
                    break;
                }
            }
            return "yoo";
        }

        public bool validateLoginDetails(string userNameEmail, string password, out User user)
        {
            user = null;
            var isValidated = false;

            var queryableuser = _unitOfWork.Users.Find(a => a.Password == password && (a.Username == userNameEmail || a.Email == userNameEmail));
            foreach (var item in queryableuser)
            {
                if (item != null)
                {
                    user = item;
                    isValidated = true;
                    return isValidated;
                }
            }
            Console.WriteLine("Your username or password is Incorrect\nor you aren't registered to this service\n");
            return false;
        }
    }
}
