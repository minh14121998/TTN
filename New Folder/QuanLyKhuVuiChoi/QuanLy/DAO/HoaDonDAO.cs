using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLy.Entity;
namespace QuanLy.DAO
{
    public class HoaDonDAO
    {
        public HoaDonDAO() { }
        public DataTable HoaDon_Select(int PageIndex, int PageSize)
        {
            PageIndex = 1;
            PageSize = 10;
            string query = "sp_HoaDon_Phantrang @PageSize , @PageIndex";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { PageSize, PageIndex });
            return result;
        }
        public bool HoaDon_Insert(HoaDon HD)
        {
            try
            {
                string query = " sp_Hoadon_Insert '" +HD.NgaySD+ "'";
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception e)
            { }
            return false;
        }
        public bool HoaDon_Delete(HoaDon HD)
        {
            try
            {
                string query = " sp_HoaDon_Delete '" + HD.MaHD + "'";
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception e)
            { }
            return false;
        }
        public bool HoaDon_Update(HoaDon HD)
        {
            try
            {
                string query = " sp_HoaDon_update '" +HD.MaHD+ "',N'" +HD.NgaySD+ "'";
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception e)
            { }
            return false;
        }
        public DataTable PhanTrangTK(int PageSize, int PageIndex, string TuKhoa)
        {
            string query = "sp_TimHoaDon_PhanTrang @PageSize , @PageIndex , @TuKhoa";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { PageSize, PageIndex, TuKhoa });
            return result;
        }
        public bool CheckHD(string TuKhoa)
        {
            string query = "sp_Dem_HoaDon_PhanTrang @TuKhoa";
            int rows = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query, new object[] { TuKhoa }));
            if (rows != 0)
                return true;
            return false;
        }
        public int DemHD_TK(string TuKhoa)
        {
            string query = "sp_Dem_HoaDon_PhanTrang @TuKhoa";
            int rows = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query, new object[] { TuKhoa }));
            return rows;
        }
        public int DemHD()
        {
            string query = "select count(*) as Max from HoaDon";
            int rows = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query));
            return rows;
        }
    }
}
