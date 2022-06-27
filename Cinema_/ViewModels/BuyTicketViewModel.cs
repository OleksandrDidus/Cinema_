using Cinema.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Cinema.ViewModels
{
    public class BuyTicketViewModel
    {
        public Session Session { get; set; }

        // Places to dropdown to select one Seat
        public List<SelectListItem> Places { get; set; }

        public int SelectPlaceId { get; set; }
        public bool SelectPayment { get; set; }
    }
}
