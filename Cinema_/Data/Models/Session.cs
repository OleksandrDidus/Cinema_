using Cinema.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Data.Models
{
    public class Session : BaseModel
    {
        public DateTime Start { set; get; }

        public DateTime End { set; get; }

        public virtual Film Film { set; get; }

        [ForeignKey("Film")]
        public int FilmId { set; get; }

        public virtual IEnumerable<Ticket> Tickets{set;get; }

        public int Price { get; set; }

        public Hall Hall { get; set; }
    }
}
