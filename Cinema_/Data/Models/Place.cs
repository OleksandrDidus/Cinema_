using Cinema.Enums;

namespace Cinema.Data.Models
{
    public class Place: BaseModel
    {
        public Hall Hall { set; get; }

        public int Row { set; get; }

        public int Seat { set; get; }
    }
}
