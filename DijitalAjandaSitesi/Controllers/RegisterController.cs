using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace DijitalAjandaSitesi.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {

        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Writer writer)
        {
            Context c = new Context();
            if (ModelState.IsValid)
            {
                
              

                WriterManager wm = new WriterManager(new EfWriterDal()); 
                writer.WriterStatus = true;
                wm.WriterAdd(writer);
                c.SaveChanges();
                return RedirectToAction("WriterLogin", "Login");
            }
            return View(writer);
        }
    }
}