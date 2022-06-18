using Cinema.Data.Models;
using System.Collections.Generic;

namespace Cinema.ViewModels
{
    public class BuyTicketViewModel
    {
        public Session Session { get; set; }

        public IEnumerable<Place> Places { get; set; }

        public int UserId { get; set; }
    }
}
