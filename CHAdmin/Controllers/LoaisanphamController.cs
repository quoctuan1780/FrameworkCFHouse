using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHAdmin.Controllers
{
    public class LoaisanphamController : BaseController
    {
        // GET: Loaisanpham
        public ActionResult Danhsachloaisanpham()
        {
            LoaisanphamDao loaisanphamDao = new LoaisanphamDao();
            ViewData["loaisp"] = loaisanphamDao.getLoaisanpham();
            return View();
        }

        public ActionResult Themloaisanpham()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Themloaisanpham(loaisanpham lsp)
        {
            LoaisanphamDao loaisanphamDao = new LoaisanphamDao();
            int ketqua = loaisanphamDao.postLoaisanpham(lsp);
            if (ketqua != 0)
            {
                ViewData["thongbao"] = "ok";
                return View();
            }
            else
            {
                ViewData["thongbao"] = "error";
                return View();
            }
        }

        public ActionResult Xoaloaisanpham(int maloaisp)
        {
            LoaisanphamDao loaisanphamDao = new LoaisanphamDao();
            int ketqua = loaisanphamDao.getXoaloaisanpham(maloaisp);
            if (ketqua != 0)
            {
                ViewData["thongbaoxoa"] = "xoathanhcong";
                return Redirect("/Loaisanpham/Danhsachloaisanpham");
            }
            else
            {
                ViewData["thongbaoxoa"] = "xoakhongthanhcong";
                return Redirect("/Loaisanpham/Danhsachloaisanpham");
            }
            
        }
    }
}