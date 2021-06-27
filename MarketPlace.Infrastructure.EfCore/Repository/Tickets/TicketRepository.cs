using Framework.Infrastructure;
using MarketPlace.Domain.Entities.Tickets;
using MarketPlace.Domain.RI.Tickets;
using MarketPlace.Infrastructure.EfCore.Context;

namespace MarketPlace.Infrastructure.EfCore.Repository.Tickets
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        private readonly MarketPlaceContext _context;

        public TicketRepository(MarketPlaceContext context) : base(context) => _context = context;
    }
}
