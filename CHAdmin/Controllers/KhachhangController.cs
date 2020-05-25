using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHAdmin.Controllers
{
    public class KhachhangController : BaseController
    {
        // GET: Khachhang
        public ActionResult Danhsachkhachhang()
        {
            KhachhangDao khachhangDao = new KhachhangDao();
            var dskh = khachhangDao.getKhachhang();
            ViewData["dskh"] = dskh;
            return View();
        }

        public ActionResult Dangkinhantinmoi()
        {
            KhachhangDao khachhangDao = new KhachhangDao();
            var dkntMoi = khachhangDao.getDangkinhantinmoi();
            ViewData["dkntmoi"] = dkntMoi;
            return View();
        }

        public ActionResult Dangkinhantin()
        {
            KhachhangDao khachhangDao = new KhachhangDao();
            var dknt = khachhangDao.getDangkinhantin();
            ViewData["dknt"] = dknt;
            return View();
        }
    }
}