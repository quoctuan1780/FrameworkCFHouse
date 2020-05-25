using CHAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;
using CHAdmin.Common;

namespace CHAdmin.Controllers
{
    public class AccountController : Controller
    {
        // GET: 
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(loginModel model)
        {
            var dao = new DangnhapDao();
            var result = dao.Login(model.userName, Encrypt.MD5Hash(model.password));
            if (result)
            {
                var user = dao.getById(model.userName);
                var userSession = new Userlogin();
                userSession.userName = user.email;
                userSession.UserID = user.id;
                Session.Add(Constants.USER_SESSION, userSession);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ModelState.AddModelError("", "Email hoặc password không đúng");
            }
            return View(model);
        }
    }
}