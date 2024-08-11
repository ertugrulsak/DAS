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
    public class ToDoListController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());

        ToDoListManager tm = new ToDoListManager(new EfToDoListDal()); 
        public ActionResult Index()
        {
            var authorName = HttpContext.User.Identity.Name;
            var author = wm.GetByName(authorName);
            var headingvalues = tm.GetList(author.WriterID);
            return View(headingvalues);
        } 

        [HttpGet]
        public ActionResult AddToDoList()
        {

            return View(new ToDoList());
        }

        [HttpPost]
        public ActionResult AddToDoList(ToDoList p)
        {
            p.ToDoListDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            var authorName = HttpContext.User.Identity.Name;
            var author = wm.GetByName(authorName);
            if (author != null)
            {
                // Kitap modeline yazarı ekle
                p.WriterID = author.WriterID;

                // Kitap ekleme işlemini gerçekleştir
                tm.ToDoListAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                // Eğer kullanıcı bulunamazsa, uygun bir hata döndürebilirsiniz
                return View("Error", new { message = "Yazar bulunamadı." });
            }
        }

        [HttpGet]
        public ActionResult EditToDoList(int id)
        {


            var ToDoListValue = tm.GetByID(id);
            return View(ToDoListValue);
        }

        [HttpPost]
        public ActionResult EditToDoList(ToDoList p)
        {
            tm.ToDoListUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteToDoList(int id)
        { 
            var HeadingValue = tm.GetByID(id);
            HeadingValue.IsRead = false;
            tm.ToDoListDelete(HeadingValue);
            return RedirectToAction("Index");
        }
    }
}