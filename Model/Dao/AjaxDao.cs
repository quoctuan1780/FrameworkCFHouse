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
        CoffeeHouse db = null;

        public AjaxDao()
        {
            db = new CoffeeHouse();
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
    }
}
