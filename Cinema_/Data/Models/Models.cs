using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Data.Models
{
    public class LoginModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
    public class RegisterModel
    {
        public string Login { set; get; }
        public string Password { get; set; }

        
    }
}
