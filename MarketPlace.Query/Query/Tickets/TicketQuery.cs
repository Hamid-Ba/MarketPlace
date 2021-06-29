using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Application;
using MarketPlace.Domain.Entities.Tickets;
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

        public async Task<IEnumerable<TicketQueryVM>> GetUserTicketsBy(long userId) => await _context.Tickets.Where(t => t.UserId == userId)
        .Select(t => new TicketQueryVM()
        {
            Id = t.Id,
            UserId = t.UserId,
            Title = t.Title,
            Necessary = t.Necessary,
            Section = t.Section,
            Status = t.Status,
            CreationDate = t.CreationDate.ToFarsi()
        }).AsNoTracking().ToListAsync();

        public async Task<TicketQueryVM> GetTicketDetailBy(long ticketId,long userId) => await _context.Tickets.Select(t =>
            new TicketQueryVM()
            {
                Id = t.Id,
                UserId = t.UserId,
                Title = t.Title,
                Necessary = t.Necessary,
                Section = t.Section,
                Status = t.Status,
                CreationDate = t.CreationDate.ToFarsi(),
                Messages = MapMessages(t.Messages)
            }).AsNoTracking().FirstOrDefaultAsync(t => t.Id == ticketId && t.UserId == userId);

        private static List<MessageQueryVM> MapMessages(List<TicketMessage> messages) => messages.Select(m =>
            new MessageQueryVM()
            {
                TicketId = m.TicketId,
                UserId = m.UserId,
                SentDate = m.CreationDate.ToFarsi(),
                Text = m.Text
            }).ToList();
    }
}