using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Model.Dao
{
    public class AjaxDao
    {
        CoffeeHouseDbContext db = null;

        public AjaxDao()
        {
            db = new CoffeeHouseDbContext();
        }

        public struct doanhthutheosp{
            public double y;
            public string label;
        }

        public List<doanhthutheosp> GetDoanhthutheosanpham()
        {
            List<doanhthutheosp> dtList = new List<doanhthutheosp>();
            var result = (from cthd in db.cthds
                          join sp in db.sanphams on cthd.masp equals sp.masp
                          group new { sp, cthd } by new { cthd.masp, sp.tensp } into g
                          select new
                          {
                              id = g.Key,
                              list = g.ToList()
                          });
            doanhthutheosp dtStruct;
            foreach(var a in result)
            {
                double gia = 0;
                foreach(var i in a.list)
                {
                    gia = i.cthd.gia * i.cthd.soluong;
                }
                dtStruct.label = a.id.tensp;
                dtStruct.y = gia;
                dtList.Add(dtStruct);
            }
            return dtList;
        }

        public string getTimkiemtrangthaiAjax(int trangthai)
        {
            var truyvan = from dh in db.donhangs join
                          kh in db.khachhangs on (int)dh.makh equals (int)kh.makh
                          where dh.tttt == trangthai
                          select new
                          {
                              kh.hoten,
                              dh.madh,
                              dh.ngaydat,
                              dh.tongtien,
                              dh.httt,
                              dh.tttt,
                              dh.ghichu
                          };

            var json = JsonConvert.SerializeObject(truyvan.ToList());
            return json;
        }

        public string getLoaikhachhang(int lkh)
        {
            string json = "";
            List<KhachhangDao.khachhangtaikhoan> listKhtk = new List<KhachhangDao.khachhangtaikhoan>();
            if (lkh == 1)
            {
                var truyvan = from kh in db.khachhangs
                              join
                                tk in db.users on (int)kh.matk equals (int)tk.id
                              select new
                              {
                                  tk.tentk,
                                  kh.makh,
                                  kh.hoten,
                                  kh.diachi,
                                  kh.gioitinh,
                                  kh.email,
                                  kh.sodt
                              };
                foreach (var dt in truyvan)
                {
                    KhachhangDao.khachhangtaikhoan khtk = new KhachhangDao.khachhangtaikhoan();
                    khtk.makh = (int)dt.makh;
                    khtk.tenkh = dt.hoten;
                    khtk.gioitinh = dt.gioitinh;
                    khtk.diachi = dt.diachi;
                    khtk.sdt = dt.sodt;
                    khtk.email = dt.email;
                    khtk.tentk = dt.tentk;
                    listKhtk.Add(khtk);
                }
                json = JsonConvert.SerializeObject(listKhtk);
            }
            else if(lkh == 2)
            {
                var truyvan = from kh in db.khachhangs
                              where kh.matk == null
                              select new
                              {
                                  kh.makh,
                                  kh.hoten,
                                  kh.diachi,
                                  kh.gioitinh,
                                  kh.email,
                                  kh.sodt
                              };
                foreach (var dt in truyvan)
                {
                    KhachhangDao.khachhangtaikhoan khtk = new KhachhangDao.khachhangtaikhoan();
                    khtk.makh = (int)dt.makh;
                    khtk.tenkh = dt.hoten;
                    khtk.gioitinh = dt.gioitinh;
                    khtk.diachi = dt.diachi;
                    khtk.sdt = dt.sodt;
                    khtk.email = dt.email;
                    khtk.tentk = "Không có";
                    listKhtk.Add(khtk);
                }
                json = JsonConvert.SerializeObject(listKhtk);
            }
            else
            {
                KhachhangDao khachhangDao = new KhachhangDao();
                var listkh = khachhangDao.getKhachhang().ToList();
                json = JsonConvert.SerializeObject(listkh);
            }
            return json;
        }
    }
}
