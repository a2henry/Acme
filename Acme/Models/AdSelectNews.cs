using Acme.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acme.Models
{
    public class AdSelectNews
    {
        public Ad Ad;
        public ICollection<Newspaper> AllPapers;
    }
}