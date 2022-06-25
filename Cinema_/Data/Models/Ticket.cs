using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Data.Models
{
    public class Ticket : BaseModel
    {
        public bool IsPaid { set; get; }
        
        public bool IsDestroyed { set; get; }

        public decimal Price { set; get; }

        [ForeignKey("Session")]
        public int SessionId { set; get; }

        public virtual Session Session { set; get; }

        [ForeignKey("Place")]
        public int PlaceId { set; get; }

        public virtual Place Place { set; get; }

        [ForeignKey("AssignedUser")]
        public int UserId { set; get; }

        public virtual User AssignedUser { set; get; }

        [ForeignKey("VerifiedCashier")]
        public int? CashierId { set; get; }

        public virtual User? VerifiedCashier { set; get; }

        public string BookingCode { set; get; }

        public string SoldTicketQRCode { set; get; }
    }
}
