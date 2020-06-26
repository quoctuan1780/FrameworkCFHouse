using Microsoft.Ajax.Utilities;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHAdmin.Areas.Client.Dao
{
    public class DetailDao
    {
        private CoffeeHouseDbContext context = new CoffeeHouseDbContext();
        public sanpham getDetail(int id)
        {
            sanpham sp = (sanpham)context.sanphams.FirstOrDefault(x=>x.masp==id);
            return sp;
        }
        public List<sanpham> getTuongTu(int maLoaiSP)
        {
            return context.sanphams.Where(x => x.maloaisp == maLoaiSP).ToList();
        }
        //public List<sanpham> getBanChay()
        //{
        //    List<cthd> ma = context.cthds.GroupBy(x => x.masp).OrderByDescending(x => x.Count());
        //    return x;
        //}
    }
}