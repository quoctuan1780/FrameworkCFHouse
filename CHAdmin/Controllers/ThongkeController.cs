using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHAdmin.Controllers
{
    public class ThongkeController : Controller
    {
        ThongkeDao thongkeDao = new ThongkeDao();
        // GET: Thongke
        public ActionResult Thongketheobieudo()
        {
            ViewData["nams"] = thongkeDao.getNam();
            return View();
        }

        public string DoanhthutheolspNam(int nam)
        {
            string ketqua = thongkeDao.getDoanhthutheolspnam(nam);
            return ketqua;
        }

        public string Doanhthutheoloaisanpham()
        {
            string ketqua = thongkeDao.getDoanhthutheoloaisanpham();
            return ketqua;
        }

        public string Doanhthutheosanpham(int nam)
        {
            string ketqua = thongkeDao.getDoanhthutheosanpham(nam);
            return ketqua;
        }

        public ActionResult Thongketheohoadon()
        {
            return View();
        }
    }
}