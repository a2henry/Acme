using Acme.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Tests.FakeRepository
{
    class FakeNewspaperRepository : INewspaperRepository
    {
        List<Newspaper> newsPaperList = new List<Newspaper>();
        public void CreateNewspaper(Newspaper newspaper)
        {
            newspaper.NewspaperId = newsPaperList.Count;
            newsPaperList.Add(newspaper);
        }

        public ICollection<Newspaper> FindAll()
        {
            return newsPaperList;
        }

        public ICollection<Newspaper> FindByAdId(int adId)
        {
            List<Newspaper> hasAdList = new List<Newspaper>();
            foreach (var p in newsPaperList)
            {
                foreach (var a in p.Ads)
                {
                    if (a.AdId==adId)
                    {
                        hasAdList.Add(p);
                        break;
                    }
                }
            }
            return hasAdList;
        }
    }
}
