using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcmeMenwear.Models;
using AcmeMenwear.DBContext;


namespace AcmeMenwear.Controllers
{
    public class HomeController : Controller
    {
        private AMContext db = new AMContext();

        public ActionResult Index()
        {
            HomepageViewModels viewModel = new HomepageViewModels();

            var lastProds = db.Products.OrderByDescending(p => p.ProductId).Take(3);
            viewModel.Products = lastProds;

            viewModel.Slides = db.Slides.ToList();

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}