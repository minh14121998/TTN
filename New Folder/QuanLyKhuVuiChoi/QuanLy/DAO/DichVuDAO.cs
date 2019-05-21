using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLy.Entity;
namespace QuanLy.DAO
{
    public class DichVuDAO
    {
        private static DichVuDAO istance;

        public static DichVuDAO Istance
        {
            get
            {
                if (istance == null)
                    istance = new DichVuDAO();
                return istance; }
            private set { istance = value; }
        }
        public DichVuDAO() { }
        public DataTable DichVu_Select()
        {
            string query = "sp_Dichvu_Select";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
        public bool CheckMaKhu(int MaKhu)
        {
            string query = "sp_CheckMaKhu @MaKhu";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { MaKhu });
            return result.Rows.Count > 0;
        }
        public bool DichVu_Insert(DichVu DV)
        {
            try
            {
                string query = "sp_Dichvu_Insert N'" + DV.TenDV + "','" + DV.GiaDV + "','" + DV.MaKhu + "'";
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                if (result > 0)
                    return true;
            }
            catch(Exception e)
            {}
            return false;
        }
        public bool DichVu_Update(DichVu DV)
        {
            try
            {
                string query = "sp_DichVu_update '" + DV.MaDV + "', N'" + DV.TenDV + "','" + DV.GiaDV + "','" + DV.MaKhu + "'";
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                if (result > 0)
                    return true;
            }
            catch (Exception e)
            { }
            return false;
        }
        public bool DichVu_Delete(DichVu DV)
        {
            try
            {
                string query = "sp_DichVu_Delete '" + DV.MaDV + "'";
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                if (result > 0)
                    return true;
            }
            catch (Exception e)
            { }
            return false;
        }
    }
}
