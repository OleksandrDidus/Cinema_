using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Data.Models
{
    public class Place: BaseModel
    {
        public int Hall { set; get; }

        public int Row { set; get; }

        public int Seat { set; get; }
    }
}
