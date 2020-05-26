using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class PhanhoiDao
    {
        CoffeeHouseDbContext db = null;
        public PhanhoiDao()
        {
            db = new CoffeeHouseDbContext();
        }

        public IQueryable<phanhoi> getPhanhoimoi()
        {
            string date = "2019-12-23";
            var Date = DateTime.Parse(date);
            Date.ToString("yyyy-MM-dd");
            var phm = db.phanhois.Where(x => x.ngayph == Date);
            return phm;
        }
    }
}
