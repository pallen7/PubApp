using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PubApp.Domain.Abstract;
using PubApp.Domain.Entities;
using PubApp.WebUI.Models;

namespace PubApp.WebUI.Controllers
{
    public class PubController : Controller
    {
        private IPubRepository repository;
        public int PageSize = 2;
        public PubController(IPubRepository pubRepository)
        {
            this.repository = pubRepository;
        }
        public ViewResult List(int page = 1)
        {
            PubsListViewModel model = new PubsListViewModel
            {
                Pubs = repository.Pubs
                .OrderBy(p => p.PubId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Pubs.Count()
                }
            };
            return View(model);
        }
    }
}