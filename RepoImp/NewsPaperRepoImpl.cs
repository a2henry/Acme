using Acme.DataAccess;
using Acme.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.RepoImp
{
    public class NewspaperRepoImpl: INewspaperRepository
    {

         AcmeEntities _dbContext;
        public NewspaperRepoImpl()
        {
            _dbContext = new AcmeEntities();

        }

        #region INewspaperRepository
        public void CreateNewspaper(Newspaper paper)
        {
            newspaper np=new newspaper
            {
                newspaper_name=paper.NewspaperName,

            };
            var newNp = _dbContext.newspapers.Add(np);
            _dbContext.SaveChanges();
        }


        public ICollection<Newspaper> FindAll()
        {
            var nps = from n in _dbContext.newspapers
                      select n;

            return ConvertToDomainList(nps.ToList());
        }

        public ICollection<Newspaper> FindByAdId(int adId)
        {
            var ad = from a in _dbContext.ads
                     where a.ad_id == adId
                     select a;

            var adSelected=ad.FirstOrDefault();
               if (adSelected !=null)
               {
                   return AdRepoImpl.ConvertToDomainNewspaper(adSelected.newspapers);
               }
               return null;    
        }

        #endregion

        #region helpers

        static IList<Newspaper> ConvertToDomainList(ICollection<newspaper> daoNP)
        {
            List<Newspaper> newspapers=new List<Newspaper>();
            if (daoNP != null)
            {
                foreach (var p in daoNP)
                {
                    Newspaper np = new Newspaper
                    {
                        NewspaperName = p.newspaper_name,
                        NewspaperId = p.newspaper_id,
                        Ads = ConvertToDomainAd(p.ads)
                    };
                    newspapers.Add(np);
                }
            }
            return newspapers;

        }
        static ICollection<Ad> ConvertToDomainAd(ICollection<ad> ads)
        {
            List<Ad> Ads = new List<Ad>();
            foreach (var a in ads)
            {
                Ad ad = new Ad
                {
                    AdId = a.ad_id,
                    AdName = a.ad_name,
                    AdContent = a.ad_content,
                    //Don't worry about newspaper
                };
                Ads.Add(ad);
            };
            return Ads;
        }
        #endregion
    }
}
