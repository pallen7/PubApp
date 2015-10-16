using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PubApp.Domain.Entities;
using System.Data.Entity;

namespace PubApp.Domain.Concrete
{
    public class EFDbContext: DbContext
    {
        public DbSet<Pub> Pubs { get; set; }
    }
}
