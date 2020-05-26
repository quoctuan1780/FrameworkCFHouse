using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class DangnhapDao
    {
        CoffeeHouseDbContext db = null;

        public DangnhapDao()
        {
            db = new CoffeeHouseDbContext();
        }
        public long Insert(user entity)
        {
            db.users.Add(entity);
            db.SaveChanges();
            return entity.id;
        }
        public user getThongtintaikhoan(string userName)
        {
            return db.users.SingleOrDefault(x => x.email == userName);
        }

        public IQueryable<user> getDanhsachtaikhoan()
        {
            var user = db.users;
            return user;
        }
        public bool Login(string userName, string password)
        {
            var result = db.users.Count(x => x.email == userName && x.password == password);
            if (result > 0) return true;
            return false;
        }

        public void setTrangthaidangnhap(user taikhoan, int ttdn)
        {
            taikhoan.ttdn = ttdn;
            db.users.AddOrUpdate(taikhoan);
            db.SaveChanges();
        }
    }
}
