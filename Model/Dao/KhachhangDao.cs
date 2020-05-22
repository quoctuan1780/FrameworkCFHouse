using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class KhachhangDao
    {
        CoffeeHouse db = null;

        public KhachhangDao()
        {
            db = new CoffeeHouse();
        }

        public IQueryable<dknt> getDangkinhantinmoi()
        {
            string date = "2019-12-09";
            var Date = DateTime.Parse(date);
            Date.ToString("yyyy-DD-mm");
            var dkntMoi = db.dknts.Where(x => x.ngaydk == Date);
            return dkntMoi;
        }
    }
}
