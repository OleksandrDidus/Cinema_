using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Data.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        [ForeignKey("Role")]
        public int? RoleId { get; set; }

        public Role Role { get; set; }
    }
}
