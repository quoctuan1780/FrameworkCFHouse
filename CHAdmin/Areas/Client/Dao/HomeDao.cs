using Microsoft.Ajax.Utilities;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CHAdmin.Areas.Client.Dao
{
    public class HomeDao
    {
        private static CoffeeHouseDbContext context= new CoffeeHouseDbContext();

        public static List<sanpham> getSPMoi()
        {
            var query = context.sanphams.OrderBy(x => x.ngaynhap).ToList();
            return query;
        }

        public static List<sanpham> getSPKM()
        {
            var query = context.sanphams.Where(x => x.giakm != 0).ToList();
            return query;
        }

        public static List<slide> getSlide()
        {
            var query = context.slides.ToList();
            return query;
        }

    }
}