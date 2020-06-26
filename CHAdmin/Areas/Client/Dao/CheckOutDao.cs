using CHAdmin.Models;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHAdmin.Areas.Client.Dao
{
    public class CheckOutDao
    {
        private CoffeeHouseDbContext context = new CoffeeHouseDbContext();
        public void ThanhToan(List<cartModel> li, int makh, CheckOutInfoModel info)
        {
            try
            {
                khachhang kh = context.khachhangs.FirstOrDefault(x => x.makh == makh);
                kh.diachi = info.diaChi;
                kh.email = info.gmail;
                kh.ghichu = null;
                kh.gioitinh = info.gioitinh;
                kh.hoten = info.tenKH;
                kh.sodt = info.sdt;
                kh.matk = null;
                context.khachhangs.Add(kh);
                context.SaveChanges();

                donhang dh = new donhang();
                dh.makh = makh;
                dh.ngaydat = DateTime.Today;
                dh.tongtien = cartModel.tongTien;
                dh.ghichu = info.ghichu;
                dh.httt = info.httt;
                dh.tttt = 0;
                context.donhangs.Add(dh);
                context.SaveChanges();
                donhang temp = context.donhangs.Find(dh.madh);
                foreach(var sp in li)
                {
                    ctdh ct = new ctdh();
                    ct.madh = temp.madh;
                    ct.masp = sp.maSP;
                    ct.soluong = sp.soLuong;
                    ct.gia = sp.donGia;
                    context.ctdhs.Add(ct);
                }
                context.SaveChanges();
                cartModel.tongSoHang = 0;
                cartModel.tongTien = 0;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void ThanhToanKoCoSan(List<cartModel> li, CheckOutInfoModel info)
        {
            try
            {
                khachhang kh = new khachhang();
                kh.diachi = info.diaChi;
                kh.email = info.gmail;
                kh.ghichu = null;
                kh.gioitinh = info.gioitinh;
                kh.hoten = info.tenKH;
                kh.sodt = info.sdt;
                kh.matk = null;
                context.khachhangs.Add(kh);
                context.SaveChanges();
                khachhang temp = context.khachhangs.Find(kh.makh);

                donhang dh = new donhang();
                dh.makh = temp.makh;
                dh.ngaydat = DateTime.Today;
                dh.tongtien = cartModel.tongTien;
                dh.ghichu = null;
                dh.httt = info.httt;
                context.donhangs.Add(dh);
                context.SaveChanges();
                donhang dhtemp = context.donhangs.Find(dh.madh);
                foreach (var sp in li)
                {
                    ctdh ct = new ctdh();
                    ct.madh = dhtemp.madh;
                    ct.masp = sp.maSP;
                    ct.soluong = sp.soLuong;
                    ct.gia = sp.donGia;
                    context.ctdhs.Add(ct);
                }
                context.SaveChanges();
                cartModel.tongSoHang = 0;
                cartModel.tongTien = 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}