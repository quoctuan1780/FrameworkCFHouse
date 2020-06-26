using CHAdmin.Areas.Client.Dao;
using CHAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHAdmin.Areas.Client.Controllers
{
    public class CheckOutController : Controller
    {
        // GET: Client/CheckOut
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(CheckOutInfoModel model)
        {
            if (ModelState.IsValid)
            {
                List<cartModel> li = Session["giohang"] as List<cartModel>;
                var id = Session["idKH"];
                if (id == null)
                {
                    new CheckOutDao().ThanhToanKoCoSan(li, model);
                    ViewBag.success = "Đặt hàng thành công";
                    CheckOutInfoModel md = new CheckOutInfoModel();
                }
                else
                {
                    new CheckOutDao().ThanhToan(li, (int)id, model);
                    ViewBag.success = "Đặt hàng thành công";
                    CheckOutInfoModel md = new CheckOutInfoModel();
                }
                Session["giohang"] = null;
            }
            return View();
        }
        //[HttpPost]
        //public void Index(CheckOutInfoModel model)
        //{
        //    List<cartModel> li = Session["giohang"] as List<cartModel>;
        //    var id = Session["idKH"];
        //}
    }
}