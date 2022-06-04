using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Data.Models
{
    public class Ticket: BaseModel
    {
        public virtual  Sessions  sessions { set; get; }//сеансы
        public virtual Place place { set; get; }
        public virtual Employee? Employee { set; get; }
        public bool paid { set; get; } //оплачено 
        public bool reservation { set; get; }//бронь 
        public bool destroyed { set; get; }//уничтожен
        public int price { set; get; }


    }
}
