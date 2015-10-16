using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PubApp.Domain.Abstract;
using PubApp.Domain.Entities;

namespace PubApp.WebUI.Controllers
{
    public class PubController : Controller
    {
        private IPubRepository repository;
        
        public PubController(IPubRepository pubRepository)
        {
            this.repository = pubRepository;
        }

        public ViewResult List()
        {
            return View(repository.Pubs);
        }
    }
}