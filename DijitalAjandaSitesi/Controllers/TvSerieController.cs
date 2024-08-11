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
    public class TvSerieController : Controller
    {
        //HeadingManager hm = new HeadingManager(new EfHeadingDal());

        //CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        TvSerieManager sm = new TvSerieManager(new EfTvSerieDal());
        public ActionResult Index()
        {
            var authorName = HttpContext.User.Identity.Name;
            var author = wm.GetByName(authorName);
            var headingvalues = sm.GetList(author.WriterID);
            return View(headingvalues);
        }

        [HttpGet]
        public ActionResult AddTvSerie()
        {

            return View(new TvSerie());
        }

        [HttpPost]
        public ActionResult AddTvSerie(TvSerie p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            var authorName = HttpContext.User.Identity.Name;
            var author = wm.GetByName(authorName);
            if (author != null)
            {
                // Kitap modeline yazarı ekle
                p.WriterID = author.WriterID;

                // Kitap ekleme işlemini gerçekleştir
                sm.TvSerieAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                // Eğer kullanıcı bulunamazsa, uygun bir hata döndürür
                return View("Error", new { message = "Yazar bulunamadı." });
            }
        }

        [HttpGet]
        public ActionResult EditTvSerie(int id)
        {


            var TvSerieValue = sm.GetByID(id);
            return View(TvSerieValue);
        }

        [HttpPost]
        public ActionResult EditTvSerie(TvSerie p)
        {
            sm.TvSerieUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteTvSerie(int id)
        {
            var HeadingValue = sm.GetByID(id);
            HeadingValue.IsRead = false;
            sm.TvSerieDelete(HeadingValue);
            return RedirectToAction("Index");
        }
    }
}