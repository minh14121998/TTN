using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLy.DAO;
using QuanLy.Entity;
using System.Data;

namespace QuanLy.DAO
{
    public class VeDAO
    {
        private static VeDAO istance;
        public static VeDAO Istance
       {
           get
           {
               if (istance == null)
                   istance = new VeDAO();
               return istance;
           }
           private set { istance = value; }
       }
        public VeDAO() { }

        public DataTable Ve_Select(int PageSize, int PageIndex)
        {
            PageSize = 10;
            PageIndex = 1;
            string query = "sp_Ve_Phantrang @PageSize , @PageIndex";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { PageSize, PageIndex });
            return result;
        }
        public bool Ve_Insert(Ve Ve)
        {
            if (Ve.ChietKhau == -1)
            {
                string query = "sp_ve_insert '" + Ve.Ngayban + "','" + Ve.SLTE + "','" + Ve.SLNL + "','" + Ve.MaNV + "','" + Ve.MaKhu + "',null";
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                if (result > 0)
                    return true;
            }
            else
            {
                string query = "sp_ve_insert '" + Ve.Ngayban + "','" + Ve.SLTE + "','" + Ve.SLNL + "','" + Ve.MaNV + "','" + Ve.MaKhu + "','" + Ve.ChietKhau + "'";
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                if (result > 0)
                    return true;
            }
            
            return false;
        }
        public bool Ve_Update(Ve Ve)
        {
            if (Ve.ChietKhau == -1)
            {
                string query = "sp_ve_Update '" + Ve.ID + "','" + Ve.Ngayban + "','" + Ve.SLTE + "','" + Ve.SLNL + "','" + Ve.MaNV + "','" + Ve.MaKhu + "',null";
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                if (result > 0)
                    return true;
            }
            else {
                string query = "sp_ve_Update '" + Ve.ID + "','" + Ve.Ngayban + "','" + Ve.SLTE + "','" + Ve.SLNL + "','" + Ve.MaNV + "','" + Ve.MaKhu + "','" + Ve.ChietKhau + "'";
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                if (result > 0)
                    return true;
            }
            
            return false;
        }
        public bool Ve_Delete(Ve Ve)
        {
            string query = "sp_ve_Delete '"+Ve.ID+"'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            if (result > 0)
                return true;
            return false;
        }
        public bool CheckMaNV(int MaNV)
        {
            string query = "sp_CheckMaNV @MaNV";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { MaNV });
            return result.Rows.Count > 0;
        }
        public bool CheckMaKhu(int MaKhu)
        {
            string query = "sp_CheckMaKhu @MaKhu";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { MaKhu });
            return result.Rows.Count > 0;
        }
        public int DemVe()
        {
            string query = "select count(*) as Max from Ve";
            int result =Convert.ToInt32( DataProvider.Instance.ExecuteScalar(query));
            return result;
        }
        public DataTable PhanTrangVe(int PageSize, int PageIndex, string TuKhoa)
        {
            string query = "sp_TimVe_PhanTrang @PageSize , @PageIndex , @TuKhoa";
            DataTable result  = DataProvider.Instance.ExecuteQuery(query, new object[] { PageSize, PageIndex, TuKhoa });
            return result;
        }
        public int DemVe_TK(string TuKhoa)
        {
            string query = "sp_Dem_Ve_PhanTrang @TuKhoa";
            int rows = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query, new object[] { TuKhoa }));
            return rows;
        }
        public bool CheckDemVe_TK(string TuKhoa)
        {
            string query = "sp_Dem_Ve_PhanTrang @TuKhoa";
            int rows = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query, new object[] { TuKhoa }));
            if (rows > 0)
                return true;
            return false;
        }
    }
}
