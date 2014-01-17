using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme;
using Acme.Controllers;
using Acme.Repository;
using Acme.Tests.FakeRepository;
using Acme.Models;

namespace Acme.Tests.Controllers
{
    [TestClass]
    public class AdControllerTest
    {
        INewspaperRepository newspaperRepository=new FakeNewspaperRepository();
        IAdRepository adRepository=new FakeAdRepository();
        const string fakeAd = "Fake Ad";
        const string fakeAd2 = "Fake Ad2";
        const string newAd = "new Ad";
        const string newContent = "new Content";

        const string fakePaper = "Fake Paper";
        const string fakePaper2 = "Fake Paper 2";
        [TestMethod]
        public void AdIndex()
        {
            // Arrange
            SetUpEnv();
            AdController controller = new AdController(adRepository, newspaperRepository);

            // Act
            ViewResult result = controller.Index() as ViewResult;
            ICollection<Ad> model = result.ViewData.Model as ICollection<Ad>;
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(model.Count, 2);
            Assert.AreEqual(model.ElementAt(0).AdName, fakeAd);
            Assert.AreEqual(model.ElementAt(1).AdName, fakeAd2);
        }



        [TestMethod]
        public void AdCreateGet()
        {
            SetUpEnv();
            AdController controller = new AdController(adRepository, newspaperRepository);

            // Act
            ViewResult result = controller.Create() as ViewResult;

            AdSelectNews model = result.ViewData.Model as AdSelectNews;

            // Assert
            Assert.IsNotNull(model);

            Assert.AreEqual(model.AllPapers.Count, 2);
            Assert.AreEqual(model.AllPapers.ElementAt(0).NewspaperName, fakePaper);
            Assert.AreEqual(model.AllPapers.ElementAt(1).NewspaperName, fakePaper2); 
        }
        [TestMethod]
        public void AdCreatePost()
        {
            SetUpEnv();

            //we started with two ads
            Assert.AreEqual(adRepository.FindAll().Count, 2);

            AdController controller = new AdController(adRepository, newspaperRepository);

            FormCollection collection = new FormCollection();
            collection["Ad.AdName"] = newAd;
            collection["Ad.AdContent"] = newContent;

            //Add the add to two papers
            collection[AdController.prefix + 1.ToString()] = 1.ToString();
             collection[AdController.prefix + 2.ToString()] = 2.ToString();
            // Act
            ViewResult result = controller.Create(collection) as ViewResult;

           // Assert
            Assert.AreEqual(adRepository.FindAll().Count, 3);
            Assert.AreEqual(adRepository.FindAll().ElementAt(2).AdName, newAd);
            Assert.AreEqual(adRepository.FindAll().ElementAt(2).AdContent, newContent);
            Assert.AreEqual(adRepository.FindAll().ElementAt(2).Newspapers.Count , 2);
            Assert.AreEqual(adRepository.FindAll().ElementAt(2).Newspapers.ElementAt(0).NewspaperId, 1);
 
        }

        #region helpers
        private void SetUpEnv()
        {
            Newspaper p1 = new Newspaper { NewspaperName = fakePaper };
            Newspaper p2 = new Newspaper { NewspaperName = fakePaper2 };
            newspaperRepository.CreateNewspaper(p1);
            newspaperRepository.CreateNewspaper(p2);
            Ad a1 = new Ad { AdName = fakeAd, AdContent = "Fake Content" };
            a1.Newspapers.Add(p1);
            a1.Newspapers.Add(p2);
            Ad a2 = new Ad { AdName = fakeAd2, AdContent = "Fake Content2" };
            adRepository.CreateAd(a1);
            adRepository.CreateAd(a2);
        }
        #endregion
    }
}
