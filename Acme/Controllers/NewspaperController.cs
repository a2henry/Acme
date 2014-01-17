using Acme.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Acme.Controllers
{
    public class NewspaperController : Controller
    {
        private readonly INewspaperRepository newspaperRepository;
        public NewspaperController(INewspaperRepository newspaperRepository){
            this.newspaperRepository = newspaperRepository;
        }
        //
        // GET: /Newspaper/
        public ActionResult Index()
        {
            
            return View(newspaperRepository.FindAll());
        }

 

        //
        // GET: /Newspaper/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Newspaper/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                string name = collection["NewspaperName"];
                Newspaper np = new Newspaper { NewspaperName = name };
                newspaperRepository.CreateNewspaper(np);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



    }
}
