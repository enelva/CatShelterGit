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
        CatShelterContext context;
        public HomeController(CatShelterContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var cats = context.Cats
                .OrderBy(o => o.Name)
                .Select(o => new CatListVM
                {
                    Name = o.Name,
                    Friendly = o.Kindness > 60 ? true : false
                })
                .ToArray();

            return View(cats);
        }
    }
}
