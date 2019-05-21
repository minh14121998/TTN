using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLy.Entity;

namespace QuanLy.DAO
{
    public class PhongbanDAO
    {
        private static PhongbanDAO istance;

        public static PhongbanDAO Istance
        {
            get
            {
                if (istance == null)
                    istance = new PhongbanDAO();
                return istance; }
            private set { istance = value; }
        }
        public PhongbanDAO() { }
        public DataTable Phongban_Select()
        {
            string query = "sp_PhongBan_Select";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
        public bool Phongban_Insert(PhongBan PB)
        {
            string query = "sp_Phongban_insert  N'" + PB.TenPB + "','" +PB.MaTP+
                "','" +PB.NgayNC+ "',N'" + PB.DiaDiem + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            if (result > 0)
                return true;
            return false;
        }
        public bool Phongban_Delete(PhongBan PB)
        {
            string query = "sp_Phongban_Delete '" + PB.ID + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            if (result > 0)
                return true;
            return false;
        }
        public bool Phongban_Update(PhongBan PB)
        {
            string query = "sp_Phongban_Update '" + PB.ID + "',N'" + PB.TenPB + "','" + PB.MaTP +
                "','" + PB.NgayNC + "',N'" + PB.DiaDiem + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            if (result > 0)
                return true;
            return false;
        }
    }
}
