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
                var user = dao.getThongtintaikhoan(model.userName);
                dao.setTrangthaidangnhap(user, 1);
                Session.Add(Constants.USER_SESSION, user);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ModelState.AddModelError("", "Email hoặc password không đúng");
            }
            return View(model);
        }


        public ActionResult Thongtintaikhoan()
        { 
            return View();
        }

        public ActionResult Danhsachtaikhoan()
        {
            DangnhapDao dangnhapDao = new DangnhapDao();
            ViewData["danhsachtk"] = dangnhapDao.getDanhsachtaikhoan();
            return View();
        }

        public ActionResult Logout()
        {
            DangnhapDao dangnhapDao = new DangnhapDao();
            user taikhoan = Session[Constants.USER_SESSION] as user;
            dangnhapDao.setTrangthaidangnhap(taikhoan, 0);
            Session.Clear();
            return Redirect("/Account/Login");
        }
    }
}