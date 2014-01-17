using Acme.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Tests.FakeRepository
{
    class FakeAdRepository: IAdRepository
    {
        List<Ad> adList = new List<Ad>();
        public void CreateAd(Ad ad)
        {
            adList.Add(ad);
        }

        public ICollection<Ad> FindAll()
        {
            return adList;
        }

        public Ad FindByAdId(int adId)
        {
            return adList.Find(a => a.AdId == adId);
        }
    }
}
