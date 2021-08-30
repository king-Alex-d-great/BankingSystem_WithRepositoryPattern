using BEZAO_PayDAL.Interfaces;

namespace BEZAO_PayDAL.Model
{
    public class UpdateViewModel : IViewModel
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
        
    }
}