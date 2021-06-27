using System.Threading.Tasks;
using Framework.Application;
using MarketPlace.ApplicationContract.ViewModels.Tickets;

namespace MarketPlace.ApplicationContract.AI.Tickets
{
    public interface ITicketApplication
    {
        Task<OperationResult> Create(CreateTicketVM command);
        Task<OperationResult> AddMessage(AddMessageTicketVM command);
    }
}