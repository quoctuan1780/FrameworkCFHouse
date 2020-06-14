using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class LoaisanphamDao
    {
        CoffeeHouseDbContext db;
        public LoaisanphamDao()
        {
            db = new CoffeeHouseDbContext();
        }

        public IQueryable<loaisanpham> getLoaisanpham()
        {
            var loaisp = from lsp in db.loaisanphams
                         select lsp;
            return loaisp;
        }

        public int postLoaisanpham(loaisanpham lsp)
        {
            DateTime date = DateTime.Now.Date;
            List<loaisanpham> kiemtratontai = db.loaisanphams.Where(x => x.tenloaisp == lsp.tenloaisp).ToList();
            if(kiemtratontai.Count > 0)
            {
                return 0;
            }
            else
            {
                db.loaisanphams.Add(lsp);
                return db.SaveChanges();
            }
        }

        public int getXoaloaisanpham(int maloaisp)
        {
            List<sanpham> listsp = db.sanphams.Where(x => x.maloaisp == maloaisp).ToList();
            if(listsp.Count == 0)
            {
                var loaisp = db.loaisanphams.Where(x => x.maloaisp == maloaisp).FirstOrDefault();
                db.loaisanphams.Attach(loaisp);
                db.loaisanphams.Remove(loaisp);
                return db.SaveChanges();
            }
            else
            {
                foreach(var sp in listsp)
                {
                    var kiemtrasanphamCthd = from ct in db.cthds
                                         where ct.masp == sp.masp
                                         select ct;
                    if (kiemtrasanphamCthd.ToList().Count > 0) return 0;
                    
                    var kiemtrasanphamCtdh = from ct in db.ctdhs
                                                where ct.masp == sp.masp
                                                select ct;
                    if (kiemtrasanphamCtdh.ToList().Count > 0) return 0;
                    
                }
                db.sanphams.RemoveRange(db.sanphams.Where(x => x.maloaisp == maloaisp));
                var lsp = db.loaisanphams.Where(x => x.maloaisp == maloaisp).FirstOrDefault();
                db.loaisanphams.Attach(lsp);
                db.loaisanphams.Remove(lsp);
                return db.SaveChanges(); 
            }    
        }
    }
}
