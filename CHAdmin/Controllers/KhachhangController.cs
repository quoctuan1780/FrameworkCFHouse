using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHAdmin.Controllers
{
    public class KhachhangController : Controller
    {
        // GET: Khachhang
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dangkinhantinmoi()
        {
            KhachhangDao khachhangDao = new KhachhangDao();
            var dkntMoi = khachhangDao.getDangkinhantinmoi();
            ViewData["dkntmoi"] = dkntMoi;
            return View();
        }
    }
}