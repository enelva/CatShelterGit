using CatShelter.Models;
using CatShelter.ViewModels;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatShelter.Controllers
{
    public class HomeController : Controller
    {
        ICatRepository repository;
        public HomeController(ICatRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            var model = repository.GetAll();
            return View(model);
        }
    }
}
