using Framework.Infrastructure;
using MarketPlace.Domain.Entities.Site;
using MarketPlace.Domain.RI.Account;
using MarketPlace.Infrastructure.EfCore.Context;

namespace MarketPlace.Infrastructure.EfCore.Repository.Site
{
    public class ContactUsRepository :Repository<ContactUs>, IContactUsRepository
    {
        private readonly MarketPlaceContext _context;

        public ContactUsRepository(MarketPlaceContext context) : base(context) => _context = context;
    }
}
