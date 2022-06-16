using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Data.Models
{
    public class UserContext:CinemaContext
    {
        public UserContext(DbContextOptions<CinemaContext> options)
           :base(options)
        {

        }
        
    }
}
