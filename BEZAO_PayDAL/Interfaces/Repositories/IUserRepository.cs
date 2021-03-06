using BEZAO_PayDAL.Entities;

namespace BEZAO_PayDAL.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User getWithPasswordUserName(string password, string userNameEmail);
    }
}
