using System.ComponentModel.DataAnnotations;

namespace Cinema.Data.Models
{
    public abstract class BaseModel
    {
        [Key]
        public int Id { get; set; }

    }
}
