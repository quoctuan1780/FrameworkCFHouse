using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHAdmin.Controllers
{
    public class PhanhoiController : Controller
    {
        PhanhoiDao phanhoiDao = new PhanhoiDao();
        // GET: Phanhoi
        public ActionResult Danhsachphanhoi()
        {
            ViewData["danhsachphanhoi"] = phanhoiDao.getDanhsachphanhoi();
            return View();
        }

        public int Xoaphanhoi(int maph)
        {
            int ketqua = phanhoiDao.getXoaphanhoi(maph);
            return ketqua;
        }
    }
}