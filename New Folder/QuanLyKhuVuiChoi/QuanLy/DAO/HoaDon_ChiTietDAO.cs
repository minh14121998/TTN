using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLy.Entity;

namespace QuanLy.DAO
{
    public class HoaDon_ChiTietDAO
    {
        private static HoaDon_ChiTietDAO istance;

        public static HoaDon_ChiTietDAO Istance
        {
            get
            {
                if (istance == null)
                    istance = new HoaDon_ChiTietDAO();
                return istance; }
            private set { istance = value; }
        }
        public HoaDon_ChiTietDAO() { }

        public DataTable HoaDon_ChiTiet_Select(int PageIndex, int PageSize)
        {
            string query = "sp_HoaDon_CT_Phantrang @PageSize , @PageIndex";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { PageSize, PageIndex });
            return result;
        }
        public bool HoaDon_ChiTiet_Insert(HoaDon_ChiTiet HD)
        {
            try
            {
                string query = "sp_Hoadon_ChiTiet_Insert '" + HD.MaHD + "' , '" + HD.MaDV + "','" + HD.SoLuong + "',N'" + HD.TenKH + "'";
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception e)
            { }
            return false;
        }
        public bool HoaDon_ChiTiet_Delete(HoaDon_ChiTiet HD)
        {
            try
            {
                string query = "sp_Hoadon_ChiTiet_Delete '" + HD.MaHD + "','"+HD.MaDV+"'";
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception e)
            { }
            return false;
        }
        public bool HoaDon_ChiTiet_Update(HoaDon_ChiTiet HD)
        {
            try
            {
                string query = "sp_Hoadon_ChiTiet_Update '" + HD.MaHD + "' , '" + HD.MaDV + "','" + HD.SoLuong + "',N'" + HD.TenKH + "'";
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception e)
            { }
            return false;
        }
        public bool CheckMaDV(int MaDV)
        {
            string query = "sp_CheckMaDV @MaDV";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { MaDV });
            return result.Rows.Count > 0;
        }
        public bool CheckMaHD(int MaHD)
        {
            string query = "sp_CheckMaHD @MaHD";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { MaHD });
            return result.Rows.Count > 0;
        }
        public bool CheckHD_CT(int MaHD, int MaDV)
        {
            string query = "sp_CheckHD_CT @MaHD , @MaDV";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { MaHD, MaDV });
            return result.Rows.Count > 0;
        }
        public int DemHD_CT()
        {
            string query = "select count(*) as Max from HoaDon_Chitiet";
            int result = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query));
            return result;
        }
    }
}
