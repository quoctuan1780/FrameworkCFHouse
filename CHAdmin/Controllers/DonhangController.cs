using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;

namespace CHAdmin.Controllers
{
    public class DonhangController : BaseController
    {
        // GET: Donhang
        public ActionResult Danhsachdonhang()
        {
            DonhangDao donhangDao = new DonhangDao();
            var donhang = donhangDao.getDonhang();
            ViewData["donhang"] = donhang;
            return View();
        }

        [HttpGet]
        public ActionResult Chitietdonhang(string madh)
        {
            int ma = int.Parse(madh);
            DonhangDao donhangDao = new DonhangDao();
            var khachhang = donhangDao.getKhachhangDonhang(ma);
            var ctdh = donhangDao.getChitietdonhang(ma);
            ViewData["khachhangdonhang"] = khachhang;
            ViewData["ctdh"] = ctdh;
            ViewData["madh"] = madh;
            return View();
        }

        public string Thanhtoandonhang(int madh)
        {
            DonhangDao donhangDao = new DonhangDao();
            bool kiemtraThanhtoan = donhangDao.Thanhtoandonhang(madh);
            if (kiemtraThanhtoan) return "ok";
            else
                return "thanhtoanloi";
        }
        public string Donhangtheotrangthai(int tt)
        {
            AjaxDao ajaxDao = new AjaxDao();
            string json = ajaxDao.getTimkiemtrangthaiAjax(tt);
            return json;
        }
    }
}