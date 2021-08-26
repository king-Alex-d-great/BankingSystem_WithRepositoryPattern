using BEZAO_PayDAL.Model;

namespace BEZAO_PayDAL.Interfaces.Services
{
    public  interface IUserService
    {
        void Register(RegisterViewModel model);
        void Update(UpdateViewModel model);
        void Login(LoginViewModel model);
        void Delete(int id);
        void Get(int id);

    }
}
