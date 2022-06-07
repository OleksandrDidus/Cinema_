using System;
using System.Collections.Generic;

namespace Cinema.Data.Models
{
    public class Film : BaseModel
    {
        public string Name { set; get; }

        public string Description { set; get; }

        public DateTime ReleaseDate { set; get; }

        public string Director { set; get; }

        public string Studio { set; get; }

        public string ImageUrl { set; get; }

        public virtual IEnumerable<Genre> Genres { set; get; }
    }
}
