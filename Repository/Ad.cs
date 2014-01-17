using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Repository
{
    public class Ad
    {
        public int AdId { get; set; }
        public string AdName { get; set; }
        public string AdContent { get; set; }
        public ICollection<Newspaper> Newspapers { get; set; } 
        public Ad ()
        {
            Newspapers = new List<Newspaper>();
        }
        
   
    }
}
