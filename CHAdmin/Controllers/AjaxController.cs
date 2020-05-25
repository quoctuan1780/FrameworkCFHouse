using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Newtonsoft.Json;

namespace CHAdmin.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public ActionResult Index()
        {
            return View();
        }

        public string getSanpham()
        {
            AjaxDao ajaxDao = new AjaxDao();
            var list = ajaxDao.GetDoanhthutheosanpham();
            var json = JsonConvert.SerializeObject(list);
            return json;
        } 

        public string getLoaikhachhang(int lkh)
        {
            AjaxDao ajaxDao = new AjaxDao();
            return ajaxDao.getLoaikhachhang(lkh);
        }
    }
}