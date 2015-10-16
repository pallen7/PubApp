using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubApp.Domain.Entities
{
    public class Pub
    {
        public int PubId { get; set;}
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public double Rating { get; set; }
    }
}
