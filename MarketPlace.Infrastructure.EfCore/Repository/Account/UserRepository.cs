using System.Linq;
using System.Threading.Tasks;
using Framework.Infrastructure;
using MarketPlace.ApplicationContract.ViewModels.Account;
using MarketPlace.Domain.Entities.Account;
using MarketPlace.Domain.RI.Account;
using MarketPlace.Infrastructure.EfCore.Context;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.EfCore.Repository.Account
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly MarketPlaceContext _context;

        public UserRepository(MarketPlaceContext context) : base(context) => _context = context;

        public async Task<User> GetUserBy(string mobilePhone) => await _context.Users.FirstOrDefaultAsync(u => u.Mobile == mobilePhone);

        public async Task<EditUserVM> GetDetailForEditBy(long id) => await _context.Users.Select(u => new EditUserVM()
        {
            UserId = u.Id,
            FirstName = u.FirstName,
            LastName = u.LastName,
            Avatar = u.Avatar,
        }).FirstOrDefaultAsync(u => u.UserId == id);

    }
}