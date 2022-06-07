namespace Cinema.Data.Models
{
    public class Ticket: BaseModel
    {
        public bool IsPaid { set; get; }
        
        public bool IsDestroyed { set; get; }

        public decimal Price { set; get; }

        public virtual Session Sessions { set; get; }

        public virtual Place Places { set; get; }

        public virtual Employee Employee { set; get; }
    }
}
