using Framework.Application.TicketComponents;

namespace MarketPlace.Query.Contract.Tickets
{
    public class TicketQueryVM
    {
        public long UserId { get; set; }
        public string Title { get; set; }
        public TicketSection Section { get; set; }
        public TicketStatus Status { get; set; }
        public TicketNecessary Necessary { get; set; }
    }
}
