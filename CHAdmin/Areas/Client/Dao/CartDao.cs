using CHAdmin.Models;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHAdmin.Areas.Client.Dao
{
    public class CartDao
    {
        //public string Hinh { get; set; }
        //public int maSP { get; set; }
        //public string tenSP { get; set; }
        //public int donGia { get; set; }
        //public int soLuong { get; set; }
        //public int donGiaKM { get; set; }
        //public int donGiaGoc{ get; set; }
        //public int thanhTien
        //{
        //    get
        //    {
        //        return soLuong * donGia;
        //    }
        //}

        //public static int TongTien { get => tongTien; set => tongTien = value; }
        //public static int TongSoHang { get => tongSoHang; set => tongSoHang = value; }

        //private static int tongTien=0;

        //private static int tongSoHang = 0;
        public static string Them1SPVaoCart(int idSP, List<cartModel> li)
        {
            var query = new CoffeeHouseDbContext().sanphams.Where(x => x.masp == idSP).FirstOrDefault();
            if (li.FirstOrDefault(x=>x.maSP==idSP)!=null)
            {
                cartModel item = li.FirstOrDefault(x => x.maSP == idSP);
                int index = li.IndexOf(item);
                item.soLuong++;
                cartModel.tongTien += item.donGia;
                if (index != -1) li[index] = item;
                return "ok";
            }
            else
            {
                cartModel cart = new cartModel();
                cart.maSP = (int)query.masp;
                cart.tenSP = query.tensp;
                cart.Hinh = query.hinhanh;
                cart.donGiaKM = (int)query.giakm;
                cart.donGiaGoc = (int)query.gia;
                if (query.giakm != 0)
                {
                    cart.donGia = (int)query.giakm;
                }
                else
                {
                    cart.donGia = (int)query.gia;
                }
                cart.soLuong = 1;
                cartModel.tongTien += cart.donGia;
                cartModel.tongSoHang += 1;
                li.Add(cart);
                return "ok";
            }
        }

        public static List<cartModel> ThemNSPVaoCart(int id, List<cartModel> li, int sl)
        {
            var query = new CoffeeHouseDbContext().sanphams.Where(x => x.masp == id).FirstOrDefault();
            if (li.FirstOrDefault(x => x.maSP == id) != null)
            {
                cartModel item = li.FirstOrDefault(x => x.maSP == id);
                item.soLuong += sl;
                cartModel.tongTien += item.donGia*sl;
                //return "ok";
                return li;
            }
            else
            {
                cartModel cart = new cartModel();
                cart.maSP = (int)query.masp;
                cart.tenSP = query.tensp;
                cart.Hinh = query.hinhanh;
                cart.donGiaKM = (int)query.giakm;
                cart.donGiaGoc = (int)query.gia;
                if (query.giakm != 0)
                {
                    cart.donGia = (int)query.giakm;
                }
                else
                {
                    cart.donGia = (int)query.gia;
                }
                cart.soLuong = sl;
                cartModel.tongTien += cart.donGia*sl;
                cartModel.tongSoHang += sl;
                li.Add(cart);
                //return "ok";
                return li;
            }
        }

        public static List<cartModel> SuaSoLuong(int id, int SLMoi,List<cartModel> li)
        {
            cartModel item = li.SingleOrDefault(x => x.maSP == id);
            if (item != null)
            {
                cartModel.tongTien -= item.thanhTien;
                cartModel.tongSoHang -= item.soLuong;
                item.soLuong = SLMoi;
                cartModel.tongTien += item.donGia;
                cartModel.tongSoHang += item.soLuong;
            }
            return li;
        }

        public static List<cartModel> XoaSPTrongCart(int idSP, List<cartModel> li)
        {
            
            cartModel item = li.SingleOrDefault(x => x.maSP == idSP);
            if (item != null)
            {
                li.Remove(item);
                cartModel.tongTien -= item.thanhTien;
                cartModel.tongSoHang -= item.soLuong;
            }
            return li;
        }

    }
}