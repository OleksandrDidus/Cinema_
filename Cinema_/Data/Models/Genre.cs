using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Data.Models
{
    public class Genre: BaseModel
    {

        public string name { set; get; }
        public virtual IEnumerable<Film> films { set; get; }
    }
}
