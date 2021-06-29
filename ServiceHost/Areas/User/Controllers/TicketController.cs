using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Framework.Application.Authentication;
using Framework.Application.TicketComponents;
using MarketPlace.ApplicationContract.AI.Tickets;
using MarketPlace.ApplicationContract.ViewModels.Tickets;
using MarketPlace.Query.Contract.Tickets;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.User.Controllers
{
    public class TicketController : UserBaseController
    {
        private readonly ITicketQuery _ticketQuery;
        private readonly ITicketApplication _ticketApplication;

        public TicketController(ITicketQuery ticketQuery, ITicketApplication ticketApplication)
        {
            _ticketQuery = ticketQuery;
            _ticketApplication = ticketApplication;
        }

        [HttpGet("user-tickets")]
        public async Task<IActionResult> Index() => View(await _ticketQuery.GetUserTicketsBy(User.GetUserId()));

        [HttpGet("new-ticket")]
        public IActionResult CreateTicket() => View();

        [HttpPost("new-ticket"), ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTicket(CreateTicketVM command)
        {
            if (ModelState.IsValid)
            {
                command.UserId = User.GetUserId();
                var result = await _ticketApplication.Create(command);

                if (result.IsSucceeded)
                {
                    TempData[SuccessMessage] = result.Message;
                    return RedirectToAction("Index");
                }

                TempData[ErrorMessage] = result.Message;
            }

            return View(command);
        }

        [HttpGet("tickets/{ticketId}")]
        public async Task<IActionResult> Detail(long ticketId)
        {
            var ticket = await _ticketQuery.GetTicketDetailBy(ticketId, User.GetUserId());

            if (ticket is null)
            {
                TempData[ErrorMessage] = "شما دسترسی به تیکت بقیه ندارید";
                return RedirectToAction("Index");
            }

            return View(await _ticketQuery.GetTicketDetailBy(ticketId, User.GetUserId()));
        }

        [HttpPost("answer-ticket"), ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMessage(AddMessageTicketVM command)
        {
            command.UserId = User.GetUserId();
            
            if (ModelState.IsValid)
            {
                var result = await _ticketApplication.AddMessage(command);

                if (result.IsSucceeded)
                {
                    TempData[SuccessMessage] = result.Message;
                    return RedirectToAction("Detail", new { ticketId = command.TicketId, area = "User" });
                }

                TempData[ErrorMessage] = result.Message;
            }

            return RedirectToAction("Index");
        }
    }
}
