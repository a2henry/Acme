using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Repository
{
    public interface INewspaperRepository
    {
         void CreateNewspaper(Newspaper newspaper);
         ICollection<Newspaper> FindAll();
         ICollection<Newspaper> FindByAdId(int adId);
    }
}
