using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Repository
{
    public class Newspaper
    {
        public int NewspaperId { get; set; }
        public string NewspaperName { get; set; }
        public ICollection<Ad> Ads { get; set; }
        public Newspaper()
        {
            Ads = new List<Ad>();
        }
    }
}
