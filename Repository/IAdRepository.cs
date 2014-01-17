using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Repository
{
    public interface IAdRepository
    {
         void CreateAd(Ad ad);
         ICollection<Ad> FindAll();
         Ad FindByAdId(int adId);
        
    }
}
