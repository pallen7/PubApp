using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PubApp.Domain.Entities;

namespace PubApp.Domain.Abstract
{
    public interface IPubRepository 
    {
        IEnumerable<Pub> Pubs { get; }
    }
}
