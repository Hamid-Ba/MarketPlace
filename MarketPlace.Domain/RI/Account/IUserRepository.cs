using System.Threading.Tasks;
using Framework.Domain;
using MarketPlace.Domain.Entities.Account;

namespace MarketPlace.Domain.RI.Account
{
    public interface IUserRepository : IRepository<User>
    {
       Task<User> GetUserBy(string mobilePhone);
    }
}
