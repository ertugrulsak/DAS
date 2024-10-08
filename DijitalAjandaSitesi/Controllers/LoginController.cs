﻿using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DijitalAjandaSitesi.Controllers
{

    [AllowAnonymous]
    public class LoginController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context c= new Context();
            var adminuserinfo = c.Admins.FirstOrDefault(x=>x.AdminUserName == p.AdminUserName && 
            x.AdminPassword == p.AdminPassword);
            if(adminuserinfo != null) 
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName,false);
                Session["AdminUserName"]= adminuserinfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            Context c = new Context();
            var writeruserinfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail &&
            x.WriterPassword == p.WriterPassword);
            if (writeruserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
                Session["WriterMail"] = writeruserinfo.WriterMail;
                Session["Kullanici"] = writeruserinfo.WriterName + " " + writeruserinfo.WriterSurName;
                return RedirectToAction("AllHeading", "WriterPanel");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
            
        }
    }
}
