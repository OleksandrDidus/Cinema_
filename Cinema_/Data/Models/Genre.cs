using System.Collections.Generic;

namespace Cinema.Data.Models
{
    public class Genre: BaseModel
    {
        public string Name { set; get; }

        public virtual IEnumerable<Film> Films { set; get; }
    }
}
