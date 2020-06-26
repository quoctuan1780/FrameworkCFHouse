using CHAdmin.Areas.Client.Dao;
using CHAdmin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHAdmin.Areas.Client.Controllers
{
    public class ClientInfoController : Controller
    {
        // GET: Client/ClientInfo
        [HttpGet]
        public string Index()
        {
            int id = (int)Session["idKH"];
            ViewData["info"] = new ClientInfoDao().LoadInfo(id);
            var result = new ClientInfoDao().LoadInfo(id);
            return JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public ActionResult ThayDoiInfo(infoClientModel info)
        {
            if (ModelState.IsValid)
            {
                int id = (int)Session["idKH"];
                new ClientInfoDao().ThayDoiInfo(info, id);
                infoClientModel inf= new infoClientModel();
                ViewBag.success = "Cập nhật thành công thông tin";
            }
            return View();
        }
    }
}