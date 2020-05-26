using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CHAdmin
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Nhóm route admin
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Route tài khoản
            routes.MapRoute("Thongtintaikhoan",
                "Account/Thongtintaikhoan",
                new { controller = "Account", action = "Thongtintaikhoan" });

            routes.MapRoute("Danhsachtaikhoan",
                "Account/Danhsachtaikhoan",
                new { controller = "Account", action = "Danhsachtaikhoan" });

            routes.MapRoute("Dangxuat",
                "Account/Logout",
                new { controller = "Account", action = "Logout"});

            //Route Ajax
            routes.MapRoute(
                "Loaikhachhang",
                "Ajax/getLoaikhachhang/{lkh}",
                new {controller = "Ajax", action = "getLoaikhachhang", lkh = UrlParameter.Optional }
                );

            //Route loại sản phẩm
            routes.MapRoute("Danhsachloaisanpham",
                "Loaisanpham/Danhsachloaisanpham",
                new { controller = "Loaisanpham", action = "Danhsachloaisanpham" });

            routes.MapRoute("Themloaisanpham",
                "Loaisanpham/Themloaisanpham",
                new { controller = "Loaisanpham", action = "Themloaisanpham" });

            routes.MapRoute("Xoaloaisanpham",
                "Loaisanpham/Xoaloaisanpham/{maloaisp}",
                new { controller = "Loaisanpham", action = "Xoaloaisanpham", maloaisp = UrlParameter.Optional });

            //Route đơn hàng
            routes.MapRoute(
                "Danhsachdonhang",
                "Donhang/Danhsachdonhang",
                new { controller = "Donhang", action = "Danhsachdonhang" }
            );

            routes.MapRoute(
                "chitietdonhang",
                "Donhang/Chitietdonhang/{madh}",
                new { controller = "Donhang", action = "Chitietdonhang", madh = UrlParameter.Optional });

            routes.MapRoute(
                "donhangtheotrangthai",
                "Donhang/Donhangtheotrangthai/{tt}",
                new { controller = "Donhang", action = "Donhangtheotrangthai", tt = UrlParameter.Optional });

            routes.MapRoute(
                "Thanhtoandonhang",
                "Donhang/Thanhtoandonhang/{madh}",
                new { controller = "Donhang", action = "Thanhtoandonhang" }
                );

            //Route khách hàng
            routes.MapRoute(
                "Danhsachkhachhang",
                "Khachhang/Danhsachkhachhang",
                new {controller = "Khachhang", action = "Danhsachkhachhang"}
                );

            routes.MapRoute(
                "Dangkinhantinmoi",
                "Khachhang/Dangkinhantinmoi",
                new { controller = "Khachhang", action = "Dangkinhantinmoi" });

            routes.MapRoute(
                "Dangkinhantin",
                "Khachhang/Dangkinhantin",
                new { controller = "Khachhang", action = "Dangkinhantin" });
            //Route Trang chủ
            routes.MapRoute(
                "trangchu",
                "Admin/Index",
                new { controller = "Admin", action = "Index" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );
            //Kết thúc nhóm route admin
        }
    }
}
