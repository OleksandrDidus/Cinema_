using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Data.Models
{
    public class Employee: BaseModel
    {
        
        public string FullName { set; get; }
        public string JobTtle { set; get; }//должность 
    }
}
