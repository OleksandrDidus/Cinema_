using System.Collections.Generic;

namespace Cinema.Data.Models
{
    public class Role : BaseModel
    {
        public string Name { get; set; }

        public virtual List<User> Users { get; set; }
    }
}
