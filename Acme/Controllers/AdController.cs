using Acme.Models;
using Acme.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Acme.Controllers
{
    public class AdController : Controller
    {
        private readonly INewspaperRepository newspaperRepository;
        private readonly IAdRepository adRepository;
        public readonly static string prefix = "Newspaper-";

        public AdController(IAdRepository adRepository, INewspaperRepository newspaperRepository)
        {
            this.adRepository = adRepository;
            this.newspaperRepository = newspaperRepository;
        }

        // GET: /Ad/
        public ActionResult Index()
        {
            var modelList=adRepository.FindAll();
            return View(modelList);
        }

        //
        // GET: /Ad/Create
        public ActionResult Create()
        {
            AdSelectNews model = new AdSelectNews();
            model.AllPapers = newspaperRepository.FindAll();
            return View(model);
        }

        //
        // POST: /Ad/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Ad newAd = new Ad();
                newAd.AdName = collection["Ad.AdName"];
                newAd.AdContent = collection["Ad.AdContent"];
                foreach  (var k in collection.Keys)
                {
                    if (k.ToString().StartsWith(prefix))
                    {
                        int newsId = Convert.ToInt32(k.ToString().Substring(prefix.Length));
                        newAd.Newspapers.Add(new Newspaper { NewspaperId = newsId });

                    }
                }
                adRepository.CreateAd(newAd);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

 


    }
}
