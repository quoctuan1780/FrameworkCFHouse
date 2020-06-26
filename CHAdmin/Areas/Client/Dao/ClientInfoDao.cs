using CHAdmin.Models;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHAdmin.Areas.Client.Dao
{
    public class ClientInfoDao
    {
        private CoffeeHouseDbContext context = new CoffeeHouseDbContext();

        //public struct ClientInfoUnit
        //{
        //    public int idUser { get; set; }
        //    public int idKH { get; set; }
        //    public string tenKH { get; set; }
        //    public string email { get; set; }
        //    public string tenTK { get; set; }
        //    public string gioiTinh { get; set; }
        //    public string diaChi { get; set; }
        //    public string sdt { get; set; }
        //}
        public infoClientModel LoadInfo(int makh)
        {
            var query = (from u in context.users
                         join kh in context.khachhangs 
                         on u.id equals kh.matk
                         where kh.makh==makh
                         select new
                         {
                             idUser = u.id,
                             idKH = kh.makh,
                             tenKH = kh.hoten,
                             email = kh.email,
                             tenTK=u.tentk,
                             gioiTinh=kh.gioitinh,
                             diaChi=kh.diachi,
                             sdt=kh.sodt
                         }).FirstOrDefault();

            infoClientModel info = new infoClientModel();
            info.diachi = query.diaChi;
            info.email = query.email;
            info.gioitinh = query.gioiTinh;
            info.hoten = query.tenKH;
            info.sodt = query.sdt;
            info.tenTk = query.tenTK;
            info.idUser = (int)query.idUser;
            info.idKH = (int)query.idKH;
            return info;

            //ClientInfoUnit clientInfoUnit = new ClientInfoUnit();
            //clientInfoUnit.idUser = (int)query.idUser;
            //clientInfoUnit.idKH = (int)query.idKH;
            //clientInfoUnit.tenKH = query.tenKH;
            //clientInfoUnit.gioiTinh = query.gioiTinh;
            //clientInfoUnit.diaChi = query.diaChi;
            //clientInfoUnit.sdt = query.sdt;
            //return clientInfoUnit;
        }

        public void ThayDoiInfo(infoClientModel info, int makh)
        {
            khachhang kh = context.khachhangs.FirstOrDefault(x => x.makh == makh);
            if (kh != null)
            {
                kh.sodt = info.sodt;
                kh.diachi = info.diachi;
                context.SaveChanges();
            }
            user u = context.users.FirstOrDefault(x => x.id == kh.matk);
            if (u != null)
            {
                u.tentk = info.tenTk;
                context.SaveChanges();
            }
        }
    }
}