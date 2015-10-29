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
                new Pub { PubId = 1, Name = "PUB1" },
                new Pub { PubId = 2, Name = "PUB2" },
                new Pub { PubId = 3, Name = "PUB3" },
                new Pub { PubId = 4, Name = "PUB4" },
                new Pub { PubId = 5, Name = "PUB5" },
                new Pub { PubId = 6, Name = "PUB6" }
            });

            PubController controller = new PubController(mock.Object);
            controller.PageSize = 3;

            IEnumerable<Pub> result = (IEnumerable<Pub>)controller.List(2).Model;

            Pub[] pubArray = result.ToArray();

            Assert.IsTrue(pubArray.Length == 3);
            Assert.AreEqual(pubArray[0].Name, "PUB4");
            Assert.AreEqual(pubArray[1].Name, "PUB5");
            Assert.AreEqual(pubArray[2].Name, "PUB6");
        }
    }
}
