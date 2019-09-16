using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Group4LMS.Models
{
    public class Group4LMSContext : DbContext
    {
        public Group4LMSContext (DbContextOptions<Group4LMSContext> options)
            : base(options)
        {
        }

        public DbSet<Group4LMS.Models.Book> Book { get; set; }
    }
}
