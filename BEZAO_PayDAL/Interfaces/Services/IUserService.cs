using BEZAO_PayDAL.Entities;
using BEZAO_PayDAL.Model;

namespace BEZAO_PayDAL.Interfaces.Services
{
    public  interface IUserService
    {
        void Register(RegisterViewModel model);
        int Update(UpdateViewModel model, int Id);
        User Login(LoginViewModel model, out Account account);
        User Delete(int id, out int affectedRow);
        void Get(int id);
    }
}
