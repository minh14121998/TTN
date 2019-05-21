using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLy.Entity;
using QuanLy.DAO;
using System.Data;
namespace QuanLy.BLL
{
    public class KhutrochoiBLL
    {
        private static KhutrochoiBLL istance;

        public static KhutrochoiBLL Istance
        {
            get
            {
                if (istance == null)
                    istance = new KhutrochoiBLL();
                return istance; }
            private set { istance = value; }
        }
        public KhutrochoiBLL() { }

        public KhuTroChoiDAO Khutrochoi = new KhuTroChoiDAO();

        public DataTable Khutrochoi_Select()
        {
            return Khutrochoi.Khutrochoi_Select();
        }
        public bool Khutrochoi_Insert(KhuTroChoi KTC)
        {
            return Khutrochoi.Khutrochoi_Insert(KTC);
        }
        public bool Khutrochoi_Update(KhuTroChoi KTC)
        {
            return Khutrochoi.Khutrochoi_Update(KTC);
        }
        public bool Khutrochoi_Delete(KhuTroChoi KTC)
        {
            return Khutrochoi.Khutrochoi_Delete(KTC);
        }
        public bool CheckMaKhu(int MaKhu)
        {
            return Khutrochoi.CheckMaKhu(MaKhu);
        }
    }
}
