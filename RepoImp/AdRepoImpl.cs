using Acme.DataAccess;
using Acme.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Acme.RepoImp
{
    public class AdRepoImpl : IAdRepository
    {
        AcmeEntities _dbContext;
        public AdRepoImpl()
        {
            _dbContext = new AcmeEntities();

        }
        #region IAdRepository

        public void CreateAd(Ad userAd)
        {
            //first create Ad
            ad dao = new ad
            {
                ad_content = userAd.AdContent,
                ad_name = userAd.AdName
            };
            ICollection<Newspaper> papers=userAd.Newspapers;
            _dbContext.ads.Add(dao);
            foreach (var p in papers)
            {
              var npDao=  _dbContext.newspapers.Find(p.NewspaperId);
              if (npDao != null)
              {
                  dao.newspapers.Add(npDao);
              }
            }
            _dbContext.SaveChanges();
        }

        public ICollection<Ad> FindAll()
        {
            var ads = from a in _dbContext.ads
                      select a;

            return ConvertToDomainList(ads.ToList());
        }

        public Ad FindByAdId(int adId)
        {
            var ad = from a in _dbContext.ads
                     where a.ad_id == adId
                     select a;
           ad rad= ad.FirstOrDefault();
            Ad result=null;
           if (rad != null)
           {
               result =new Ad{
                         AdId = rad.ad_id,
                         AdContent = rad.ad_content,
                         AdName = rad.ad_name,
                         Newspapers = ConvertToDomainNewspaper(rad.newspapers)
               };
           }

           return result;
        }

        #endregion

        #region helpers
        static IList<Ad> ConvertToDomainList(ICollection<ad> daoAd)
        {
            List<Ad> ads = new List<Ad>();
            if (daoAd != null)
            {
                foreach (var a in daoAd)
                {
                    Ad np = new Ad
                    {
                        AdId = a.ad_id,
                        AdContent = a.ad_content,
                        AdName = a.ad_name,
                        Newspapers = ConvertToDomainNewspaper(a.newspapers)
                    };
                    ads.Add(np);
                }
            }
            return ads;

        }

        internal static ICollection<Newspaper> ConvertToDomainNewspaper(ICollection<newspaper> papers)
        {
            List<Newspaper> newspapers = new List<Newspaper>();
            foreach (var p in papers)
            {
                Newspaper np = new Newspaper { 
                    NewspaperId=p.newspaper_id,
                    NewspaperName=p.newspaper_name,
                    //Don't worry about ads
                };
                newspapers.Add(np);
            }
            return newspapers;
        }
        #endregion
    }
}
