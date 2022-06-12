using Cinema.Data.Models;

namespace Cinema.ViewModels
{
    public class BuyTicketViewModel
    {
        public Session Session { get; set; }

        public int PlaceId { get; set; }

        public int UserId { get; set; }
    }
}
