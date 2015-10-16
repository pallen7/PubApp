using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PubApp.Domain.Abstract;
using PubApp.Domain.Entities;

namespace PubApp.Domain.Concrete
{
    public class PubRepository : IPubRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Pub> Pubs
        {
            get { return context.Pubs; }
        }
    }
}
