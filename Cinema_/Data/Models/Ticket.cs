namespace Cinema.Data.Models
{
    public class Ticket: BaseModel
    {
        public bool IsPaid { set; get; }
        
        public bool IsDestroyed { set; get; }

        public decimal Price { set; get; }

        public virtual Session Session { set; get; }

        public int SessionId { set; get; }

        public virtual Place Place { set; get; }

        public int PlaceId { set; get; }

        public virtual Employee Employee { set; get; }

        public int EmployeeId { set; get; }

        public string BookingCode { set; get; }
        public string SoldTicketQRCode { set; get; }

    }
}
