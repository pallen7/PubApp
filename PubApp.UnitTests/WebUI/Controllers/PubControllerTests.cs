using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PubApp.Domain.Abstract;
using PubApp.Domain.Entities;
using PubApp.WebUI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PubApp.WebUI.Models;
using PubApp.WebUI.HtmlHelpers;
using System.Web.Mvc;

namespace PubApp.UnitTests.WebUI.Controllers
{
    [TestClass]
    public class PubControllerTests
    {
        [TestMethod]   
        public void Can_Paginate()
        {
            Mock<IPubRepository> mock = new Mock<IPubRepository>();
            mock.Setup(m => m.Pubs).Returns(new Pub[]
            {
                new Pub {PubId = 1, Name = "The Vine", Description = "Local to work", Category="Pub" },
                new Pub {PubId = 2, Name = "The City Arms", Description = "Local to work", Category="Pub" },
                new Pub {PubId = 3, Name = "The Waterhouse", Description = "Local to work", Category="Pub" },
                new Pub {PubId = 4, Name = "Beef & Pudding", Description = "Local eaterie", Category="Restaurant" },
                new Pub {PubId = 5, Name = "Town Hall Tavern", Description = "Local to work", Category="Pub" }
            });

            PubController controller = new PubController(mock.Object);
            controller.PageSize = 3;

            PubsListViewModel result = (PubsListViewModel)controller.List(2).Model;

            Pub[] pubArray = result.Pubs.ToArray();

            Assert.IsTrue(pubArray.Length == 2);
            Assert.AreEqual(pubArray[0].Name, "Beef & Pudding");
            Assert.AreEqual(pubArray[1].Name, "Town Hall Tavern");
        }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            HtmlHelper myHelper = null;

            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };

            Func<int, string> pageUrlDelegate = i => "Page" + i;

            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
            + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
            + @"<a class=""btn btn-default"" href=""Page3"">3</a>", result.ToString());
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            Mock<IPubRepository> mock = new Mock<IPubRepository>();
            mock.Setup(m => m.Pubs).Returns(new Pub[]
            {
                new Pub {PubId = 1, Name="The Vine" },
                new Pub {PubId = 2, Name="The City Arms" },
                new Pub {PubId = 3, Name="The Waterhouse" },
                new Pub {PubId = 4, Name="Beef & Pudding" },
                new Pub {PubId = 5, Name="Town Hall Tavern" }
            });

            PubController controller = new PubController(mock.Object);

            PubsListViewModel result = (PubsListViewModel)controller.List(2).Model;

            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2, "CurrentPage");
            Assert.AreEqual(pageInfo.ItemsPerPage, 2, "ItemsPerPage");
            Assert.AreEqual(pageInfo.TotalItems, 5, "TotalItems");
            Assert.AreEqual(pageInfo.TotalPages, 3, "TotalPages");
        }
    }

    
}
