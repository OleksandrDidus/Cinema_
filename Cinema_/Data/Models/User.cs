using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Data.Models
{
    public class User:BaseModel
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        [ForeignKey("Role")]
        public int? RolesId { get; set; }
        public Role Role { get; set; }
    }
}
