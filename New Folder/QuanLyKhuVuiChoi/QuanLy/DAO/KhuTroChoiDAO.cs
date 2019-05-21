using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLy.Entity;
namespace QuanLy.DAO
{
    public class KhuTroChoiDAO
    {
        private static KhuTroChoiDAO istance;

        public static KhuTroChoiDAO Istance
        {
            get
            {
                if (istance == null)
                    istance = new KhuTroChoiDAO();
                return istance; }
            private set { istance = value; }
        }
        public KhuTroChoiDAO() { }

        public DataTable Khutrochoi_Select()
        {
            string query = "sp_Khutrochoi_Select";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
        public bool Khutrochoi_Insert(KhuTroChoi KTC)
        {
            try
            {
                string query = " sp_Khutrochoi_Insert N'" +KTC.Tenkhu+ "','" +KTC.Giatreem+
                "','" +KTC.Gianguoilon+ "','" +KTC.Giomocua+ 
                "','" +KTC.Giodongcua+ "'";
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                if (result > 0)
                    return true;
            }
            catch (Exception e)
            { }
            return false;
        }
        public bool Khutrochoi_Update(KhuTroChoi KTC)
        {
            try
            {
                string query = " sp_Khutrochoi_Update '"+KTC.ID+"',N'" + KTC.Tenkhu + "','" + KTC.Giatreem +
                "','" + KTC.Gianguoilon + "','" + KTC.Giomocua +
                "','" + KTC.Giodongcua + "'";
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                if (result > 0)
                    return true;
            }
            catch (Exception e)
            { }
            return false;
        }
        public bool Khutrochoi_Delete(KhuTroChoi KTC)
        {
            try
            {
                string query = " sp_Khutrochoi_Delete '"+KTC.ID+"'";
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                if (result > 0)
                    return true;
            }
            catch (Exception e)
            { }
            return false;
        }
        public bool CheckMaKhu(int MaKhu)
        {
            string query = "sp_CheckMaKhu @MaKhu";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { MaKhu });
            return result.Rows.Count > 0;
        }

    }
}
