using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using PubApp.Domain.Abstract;
using PubApp.Domain.Entities;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PubApp.WebUI.Controllers;
using PubApp.WebUI.Models;
using PubApp.WebUI.HtmlHelpers;

namespace PubApp.UnitTests.WebUI.HtmlHelpers
{
    [TestClass]
    public class PagingHelperTests
    {
        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            HtmlHelper myHelper = null;
            PagingInfo pagingInfo = new PagingInfo { CurrentPage = 2, TotalItems = 28, ItemsPerPage = 10 };

            MvcHtmlString result = myHelper.PageLinks(pagingInfo, x => "Page" + x);

            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
                            + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
                            + @"<a class=""btn btn-default"" href=""Page3"">3</a>", result.ToString());
        }
    }
}
