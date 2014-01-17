using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme;
using Acme.Controllers;
using Acme.Tests.FakeRepository;
using Acme.Repository;

namespace Acme.Tests.Controllers
{
    [TestClass]
    public class NewspaperControllerTest
    {

        const string fakePaper = "Fake Paper";
        const string fakePaper2 = "Fake Paper 2";
        const string addPaper = "added Paper";
        INewspaperRepository newspaperRepository = new FakeNewspaperRepository();
        [TestMethod]
        public void NewspaperIndex()
        {
            SetupEnv();

            // Arrange
            NewspaperController controller = new NewspaperController(newspaperRepository);

            // Act
            ViewResult result = controller.Index() as ViewResult;
            ICollection<Newspaper> model = result.ViewData.Model as ICollection<Newspaper>;
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(model.Count, 2);
            Assert.AreEqual(model.ElementAt(0).NewspaperName, fakePaper);
            Assert.AreEqual(model.ElementAt(1).NewspaperName, fakePaper2);
        }


        [TestMethod]
        public void NewspaperCreatePost()
        {
            // Arrange
            SetupEnv();


            NewspaperController controller = new NewspaperController(newspaperRepository);

            //we started with two papers
            Assert.AreEqual(newspaperRepository.FindAll().Count, 2);


            FormCollection collection = new FormCollection();
            collection["NewspaperName"] = addPaper;
            ViewResult result = controller.Create(collection) as ViewResult;

            // Assert
            Assert.AreEqual(newspaperRepository.FindAll().Count, 3);
            Assert.AreEqual(newspaperRepository.FindAll().ElementAt(2).NewspaperName, addPaper);
        

        }

        #region helpers

        private void SetupEnv()
        {
            Newspaper p1 = new Newspaper { NewspaperName = fakePaper };
            Newspaper p2 = new Newspaper { NewspaperName = fakePaper2 };
            newspaperRepository.CreateNewspaper(p1);
            newspaperRepository.CreateNewspaper(p2);
        }
        #endregion

    }
}
