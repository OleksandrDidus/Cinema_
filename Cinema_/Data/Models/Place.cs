using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Data.Models
{
    public class Place: BaseModel
    {
        
        public int hall { set; get; }
        public int row_number { set; get; }
        public int place_number { set; get; }
    }
}
