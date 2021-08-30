using BEZAO_PayDAL.Interfaces;

namespace BEZAO_PayDAL.Model
{
    public class LoginViewModel : IViewModel
    {
        public string UsernameEmail { get; set; }
        public string Password { get; set; }

    }
}