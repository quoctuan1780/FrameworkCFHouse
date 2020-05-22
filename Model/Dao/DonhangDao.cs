using Model.EF;
using Org.BouncyCastle.Crypto.Agreement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class DonhangDao
    {
        CoffeeHouse db;

        public DonhangDao()
        {
            db = new CoffeeHouse();
        }

        public struct donhang
        {
            public int madh;
            public string hoten;
            public string ngaydat;
            public double tongtien;
            public string httt;
            public int tttt;
            public string ghichu;
        }

        public struct chitietdonhang
        {
            public string tensp;
            public string hinhanh;
            public int soluong;
            public double dongia;
            public double thanhtien;
            public int tttt;
            public string ngaydat;
            public string httt;
        }

        public List<donhang> getDonhang()
        {
            List<donhang> donhangs = new List<donhang>();
            var donhang = (from dh in db.donhangs
                           join kh in db.khachhangs on (int)dh.makh equals (int)kh.makh
                           select new
                           {
                               dh.madh,
                               kh.hoten,
                               dh.ngaydat,
                               dh.tongtien,
                               dh.httt,
                               dh.tttt,
                               dh.ghichu
                           });
            foreach (var dhm in donhang)
            {
                donhang dh = new donhang();
                dh.madh = (int)dhm.madh;
                dh.hoten = dhm.hoten;
                dh.ngaydat = dhm.ngaydat.ToString();
                dh.tongtien = (double)dhm.tongtien;
                dh.httt = dhm.httt;
                dh.tttt = dhm.tttt;
                if (dhm.ghichu == null)
                    dh.ghichu = "Không có";
                else
                    dh.ghichu = dhm.ghichu;
                donhangs.Add(dh);
            }
            return donhangs;
        }
        public List<donhang> getDonhangmoi()
        {
            DateTime ngaydat = DateTime.Now.Date;
            ngaydat.ToString("yyyy-MM-dd");
            var donhangmoi = (from dh in db.donhangs
                             join kh in db.khachhangs on (int)dh.makh equals (int)kh.makh
                             where dh.ngaydat == ngaydat
                             select new
                             {
                                 dh.madh,
                                 kh.hoten,
                                 dh.ngaydat,
                                 dh.tongtien,
                                 dh.httt,
                                 dh.tttt,
                                 dh.ghichu
                             });
            List<donhang> donhangmois = new List<donhang>();
            foreach(var dhm in donhangmoi)
            {
                donhang dh = new donhang();
                dh.madh = (int) dhm.madh;
                dh.hoten = dhm.hoten;
                dh.ngaydat = dhm.ngaydat.ToString();
                dh.tongtien = (double)dhm.tongtien;
                dh.httt = dhm.httt;
                dh.tttt = dhm.tttt;
                if (dhm.ghichu == null)
                    dh.ghichu = "Không có";
                else
                    dh.ghichu = dhm.ghichu;
                donhangmois.Add(dh);
            }
            return donhangmois;
        }

        public IQueryable<khachhang> getKhachhangDonhang(int madh)
        {
            var truyvan = from kh in db.khachhangs
                        join dh in db.donhangs on (int)kh.makh equals (int)dh.makh
                        select kh;
            return truyvan;
        }

        public List<chitietdonhang> getChitietdonhang(int madh)
        {
            List<chitietdonhang> chitietdonhangs = new List<chitietdonhang>();
            var truyvan = (from dh in db.donhangs join
                         ct in db.ctdhs on dh.madh equals ct.madh join 
                         sp in db.sanphams on ct.masp equals sp.masp
                         where dh.madh == madh
                         select new
                         {
                             sp.tensp,
                             sp.hinhanh,
                             ct.soluong,
                             ct.gia,
                             dh.ngaydat,
                             dh.tongtien,
                             dh.tttt,
                             dh.httt
                         });
                       
            foreach(var dulieu in truyvan)
            {
                chitietdonhang ct = new chitietdonhang();
                ct.tensp = dulieu.tensp;
                ct.hinhanh = dulieu.hinhanh;
                ct.soluong = dulieu.soluong;
                ct.dongia = dulieu.gia;
                ct.thanhtien = (double) dulieu.tongtien;
                ct.tttt = dulieu.tttt;
                ct.ngaydat = dulieu.ngaydat.ToString();
                ct.httt = dulieu.httt;
                chitietdonhangs.Add(ct);
            }
            return chitietdonhangs;
        }
    }
}
