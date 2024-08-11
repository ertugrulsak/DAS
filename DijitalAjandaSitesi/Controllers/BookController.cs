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
    public class BookController : Controller
    {

        WriterManager wm = new WriterManager(new EfWriterDal());

        BookManager bm = new BookManager(new EfBookDal());
        public ActionResult Index()
        {
            var authorName = HttpContext.User.Identity.Name;
            var author = wm.GetByName(authorName);
            var headingvalues = bm.GetList(author.WriterID);
            return View(headingvalues);
        }

        [HttpGet]
        public ActionResult AddBook()
        {
           
            return View(new Book());
        }

        [HttpPost]
        public ActionResult AddBook(Book p)
        {
            p.BookDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            var authorName = HttpContext.User.Identity.Name;
            var author = wm.GetByName(authorName);
            if (author != null)
            {
                // Kitap modeline yazarı ekle
                p.WriterID = author.WriterID;

                // Kitap ekleme işlemini gerçekleştir
                bm.BookAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                // Eğer kullanıcı bulunamazsa, uygun bir hata döndürebilirsiniz
                return View("Error", new { message = "Yazar bulunamadı." });
            }
        }

        [HttpGet]
        public ActionResult EditBook(int id)
        {

            
            var BookValue = bm.GetByID(id);
            return View(BookValue);
        }

        [HttpPost]
        public ActionResult EditBook(Book p)
        {
            bm.BookUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteBook(int id)
        {
            var HeadingValue = bm.GetByID(id);
            HeadingValue.IsRead = false;
            bm.BookDelete(HeadingValue);
            return RedirectToAction("Index");
        }
    }
}