using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Data.Models
{
    public class Sessions : BaseModel
    {

        public DateTime Start { set; get; }
        public DateTime End { set; get; }
        public virtual Film Film { set; get; }
        public virtual IEnumerable<Ticket> Tickets{set;get; }


    }
}
