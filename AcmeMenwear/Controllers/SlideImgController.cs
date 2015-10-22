using AcmeMenwear.DBContext;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcmeMenwear.Controllers
{
    public class SlideImgController : Controller
    {

        private AMContext db = new AMContext();

        // GET: SlideImg
        public ActionResult Index(int id)
        {
            var fileToRetrieve = db.SlideImg.Find(id);
            return File(fileToRetrieve.SlideImgContent, fileToRetrieve.SlideImgContentType);
        }
        
    }
}