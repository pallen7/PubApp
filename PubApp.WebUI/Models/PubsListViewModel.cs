using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PubApp.Domain.Entities;

namespace PubApp.WebUI.Models
{
    public class PubsListViewModel
    {
        public IEnumerable<Pub> Pubs { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
