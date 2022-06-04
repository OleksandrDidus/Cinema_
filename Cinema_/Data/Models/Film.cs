using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Data.Models
{
    public class Film: BaseModel
    {
        [Display(Name="Name")]  
        public string Name { set; get; }
        public string desc { set; get; }
        public DateTime date_of_release { set; get; }
        public uint age { set; get; }
        public string orig_name { set; get; }
        public string director { set; get; }
        public virtual IEnumerable<Genre> genre { set; get; }
        public string production { set; get; }
        public string studio { set; get; }
        public string starring { set; get; }
        public string img { set; get; }
    }
}
