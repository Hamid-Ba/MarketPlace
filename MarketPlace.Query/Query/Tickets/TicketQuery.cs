using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketPlace.Infrastructure.EfCore.Context;
using MarketPlace.Query.Contract.Tickets;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Query.Query.Tickets
{
    public class TicketQuery : ITicketQuery
    {
        private readonly MarketPlaceContext _context;

        public TicketQuery(MarketPlaceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TicketQueryVM>> GetUserTicketsBy(long userId)
        {
            var result = await _context.Tickets.Where(t => t.UserId == userId)
                .Select(t => new TicketQueryVM()
                {
                    UserId = t.UserId,
                    Title = t.Title,
                    Necessary = t.Necessary,
                    Section = t.Section,
                    Status = t.Status
                }).AsNoTracking().ToListAsync();

            return result;
        } 

    }
}