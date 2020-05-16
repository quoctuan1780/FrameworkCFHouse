using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class DangnhapDao
    {
        CoffeeHouse db = null;

        public DangnhapDao()
        {
            db = new CoffeeHouse();
        }
        public long Insert(user entity)
        {
            db.users.Add(entity);
            db.SaveChanges();
            return entity.id;
        }
        public user getById(string userName)
        {
            return db.users.SingleOrDefault(x => x.email == userName);
        }
        public bool Login(string userName, string password)
        {
            var result = db.users.Count(x => x.email == userName && x.password == password);
            if (result > 0) return true;
            return false;
        }
    }
}
