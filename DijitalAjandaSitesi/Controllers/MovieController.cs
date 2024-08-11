using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DijitalAjandaSitesi.Controllers
{
    public class MovieController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());

        MovieManager mm = new MovieManager(new EfMovieDal());
        public ActionResult Index()
        {
            var authorName = HttpContext.User.Identity.Name;
            var author = wm.GetByName(authorName);
            var headingvalues = mm.GetList(author.WriterID);
            return View(headingvalues);
        }

        [HttpGet]
        public ActionResult AddMovie()
        {

            return View(new Movie());
        }

        [HttpPost]
        public ActionResult AddMovie(Movie p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            var authorName = HttpContext.User.Identity.Name;
            var author = wm.GetByName(authorName);
            if (author != null)
            {
                // Kitap modeline yazarı ekle
                p.WriterID = author.WriterID;

                // Kitap ekleme işlemini gerçekleştir
                mm.Add(p);
                return RedirectToAction("Index");
            }
            else
            {
                // Eğer kullanıcı bulunamazsa, uygun bir hata döndürebilirsiniz
                return View("Error", new { message = "Yazar bulunamadı." });
            }
        }

        [HttpGet]
        public ActionResult EditMovie(int id)
        {


            var MovieValue = mm.GetByID(id);
            return View(MovieValue);
        }

        [HttpPost]
        public ActionResult EditMovie(Movie p)
        {
            mm.Update(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteMovie(int id) 
        {
            var HeadingValue = mm.GetByID(id);
            HeadingValue.IsRead = false;
            mm.Delete(HeadingValue);
            return RedirectToAction("Index");
        }
    }
}