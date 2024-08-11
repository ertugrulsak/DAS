using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DijitalAjandaSitesi.Controllers
{
    public class ContactController : Controller
    {
      
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();
        MessageManager mm = new MessageManager(new EfMessageDal());


        public ActionResult Index()
        {
            var contactvalues = cm.GetList();
            return View(contactvalues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = cm.GetByID(id);
            return View(contactvalues);
        }

        public PartialViewResult MessageListMenu()
        {
            //var messagelist = mm.GetListInbox(Session["WriterMail"].ToString());
            //Session["GelenMail"] = messagelist.Count;
            //messagelist = mm.GetListSendbox(Session["WriterMail"].ToString());
            //Session["GönderilenMail"] = messagelist.Count;
            return PartialView();
        }
    }
}