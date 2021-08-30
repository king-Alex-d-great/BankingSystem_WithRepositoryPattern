using BEZAO_PayDAL.Entities;

namespace BEZAO_PayDAL.Interfaces.Services
{
    public interface IAccountService
    {
        Account Get(int userId);

        void checkBalance(User user);

    }
}