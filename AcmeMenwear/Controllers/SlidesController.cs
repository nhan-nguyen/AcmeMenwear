using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AcmeMenwear.DBContext;
using AcmeMenwear.Models;
using System.Data.Entity.Infrastructure;

namespace AcmeMenwear.Controllers
{
    public class SlidesController : Controller
    {
        private AMContext db = new AMContext();

        // GET: Slides
        public ActionResult Index()
        {
            return View(db.Slides.ToList());
        }

        // GET: Slides/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slide slide = db.Slides.Include(s => s.SlideImg).SingleOrDefault(s => s.SlideId == id); ;
            if (slide == null)
            {
                return HttpNotFound();
            }
            return View(slide);
        }

        // GET: Slides/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Slides/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SlideId,SlideLink,SlideDescription")] Slide slide, HttpPostedFileBase upload)
        {
            try {
                if (ModelState.IsValid)
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        var img = new SlideImg
                        {
                            SlideImgName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.Image,
                            SlideImgContentType = upload.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            img.SlideImgContent = reader.ReadBytes(upload.ContentLength);
                        }
                        slide.SlideImg = new List<SlideImg> { img };
                    }
                    db.Slides.Add(slide);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(slide);
            }
            catch (RetryLimitExceededException)
            {
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
                return View(slide);
            }
        }

        // GET: Slides/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slide slide = db.Slides.Find(id);
            if (slide == null)
            {
                return HttpNotFound();
            }
            return View(slide);
        }

        // POST: Slides/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SlideId,SlideLink,SlideDescription")] Slide slide)
        {
            if (ModelState.IsValid)
            {
                db.Entry(slide).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slide);
        }

        // GET: Slides/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slide slide = db.Slides.Find(id);
            if (slide == null)
            {
                return HttpNotFound();
            }
            return View(slide);
        }

        // POST: Slides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slide slide = db.Slides.Find(id);
            db.Slides.Remove(slide);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
