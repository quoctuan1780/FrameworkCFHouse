using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class TrangchuDao
    {
        CoffeeHouse db = null;

        public TrangchuDao()
        {
            db = new CoffeeHouse();
        }

        public int getDangkinhantinmoi()
        {
            String n = "2019-12-09";
            var Date = DateTime.Parse(n);
            Date.ToString("yyyy-MM-dd");
            var result = db.dknts.Where(x => x.ngaydk == Date);
            int count = 0;
            foreach (dknt dh in result) count++;
            return count;
        }
        public int getDonhangmoi()
        {
            String n = "2019-12-04";
            var Date = DateTime.Parse(n);
            Date.ToString("yyyy-MM-dd");
            var result = db.donhangs.Where(x => x.ngaydat == Date);
            int count = 0;
            foreach (donhang dh in result) count++;
            return count;
        }

        public int getPhanhoimoi()
        {
            String n = "2019-12-23";
            var Date = DateTime.Parse(n);
            Date.ToString("yyyy-MM-dd");
            var result = db.phanhois.Where(x => x.ngayph == Date);
            int count = 0;
            foreach (phanhoi dh in result) count++;
            return count;
        }
    }
}
