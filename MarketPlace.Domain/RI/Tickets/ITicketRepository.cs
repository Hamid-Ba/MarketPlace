using Framework.Domain;
using MarketPlace.Domain.Entities.Tickets;

namespace MarketPlace.Domain.RI.Tickets
{
    public interface ITicketRepository : IRepository<Ticket>
    {
    }
}
