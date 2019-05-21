using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLy.Entity;
namespace QuanLy.DAO
{
    public class NhanvienDAO
    {
        public NhanvienDAO() { }
        public DataTable Nhanvien_Select(int PageIndex, int PageSize)
        { 
            PageIndex = 1;
            PageSize = 10;
            string query = "sp_Nhanvien_Phantrang @PageSize , @PageIndex";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { PageSize, PageIndex });
            return result;
        }
        public bool Nhanvien_Insert(NhanVien NV)
        {
            string query;
            try
            {
                if (NV.MaKhu == -1 && NV.MaPB == -1 && NV.MaTro == -1)
                {
                    query = " sp_Nhanvien_Insert N'" + NV.Hoten + "','" + NV.Ngaysinh + "',N'" + NV.Gioitinh + "',N'" + NV.Quequan + "',N'" + NV.Chucvu + "','" + NV.Luong + "',null,null,null";
                }
                else if (NV.MaKhu == -1 && NV.MaPB == -1)
                {
                    query = " sp_Nhanvien_Insert N'" + NV.Hoten + "','" + NV.Ngaysinh + "',N'" + NV.Gioitinh + "',N'" + NV.Quequan + "',N'" + NV.Chucvu + "','" + NV.Luong + "',null,null,'" + NV.MaTro + "'";
                }
                else if (NV.MaKhu == -1 && NV.MaTro == -1)
                {
                    query = " sp_Nhanvien_Insert ,N'" + NV.Hoten + "','" + NV.Ngaysinh + "',N'" + NV.Gioitinh + "',N'" + NV.Quequan + "',N'" + NV.Chucvu + "','" + NV.Luong + "','" + NV.MaPB + "',null,null";
                }
                else if (NV.MaTro == -1 && NV.MaPB == -1)
                {
                    query = " sp_Nhanvien_Insert ,N'" + NV.Hoten + "','" + NV.Ngaysinh + "',N'" + NV.Gioitinh + "',N'" + NV.Quequan + "',N'" + NV.Chucvu + "','" + NV.Luong + "',null,'" + NV.MaKhu + "',null";
                }
                else if (NV.MaKhu == -1)
                {
                    query = " sp_Nhanvien_Insert ,N'" + NV.Hoten + "','" + NV.Ngaysinh + "',N'" + NV.Gioitinh + "',N'" + NV.Quequan + "',N'" + NV.Chucvu + "','" + NV.Luong + "','" + NV.MaPB + "',null,'" + NV.MaTro + "'";
                }
                else if (NV.MaTro == -1)
                {
                    query = " sp_Nhanvien_Insert ,N'" + NV.Hoten + "','" + NV.Ngaysinh + "',N'" + NV.Gioitinh + "',N'" + NV.Quequan + "',N'" + NV.Chucvu + "','" + NV.Luong + "','" + NV.MaPB + "','" + NV.MaKhu + "',null";
                }
                else if (NV.MaPB == -1)
                {
                    query = " sp_Nhanvien_Insert ,N'" + NV.Hoten + "','" + NV.Ngaysinh + "',N'" + NV.Gioitinh + "',N'" + NV.Quequan + "',N'" + NV.Chucvu + "','" + NV.Luong + "',null,'" + NV.MaKhu + "','" + NV.MaTro + "'";
                }
                else
                    query = " sp_Nhanvien_Insert ,N'" + NV.Hoten + "','" + NV.Ngaysinh + "',N'" + NV.Gioitinh + "',N'" + NV.Quequan + "',N'" + NV.Chucvu + "','" + NV.Luong + "','" + NV.MaPB + "','" + NV.MaKhu + "','" + NV.MaTro + "'";

                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return true;
            }
            catch(Exception e)
            {}
            return false;
        }
        public bool Nhanvien_Delete(NhanVien NV)
        {
            try
            {
                string query = " sp_Nhanvien_Delete '" + NV.ID + "'";
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception e)
            { }
            return false;
        }
        public bool Nhanvien_Update(NhanVien NV)
        {
            string query;
            try
            {
                if (NV.MaKhu == -1 && NV.MaPB == -1 && NV.MaTro == -1)
                {
                    query = " sp_Nhanvien_update '" + NV.ID + "',N'" + NV.Hoten + "','" + NV.Ngaysinh + "',N'" + NV.Gioitinh + "',N'" + NV.Quequan + "',N'" + NV.Chucvu + "','" + NV.Luong + "',null,null,null";
                }
                else if (NV.MaKhu == -1 && NV.MaPB == -1)
                {
                    query = " sp_Nhanvien_update '" + NV.ID + "',N'" + NV.Hoten + "','" + NV.Ngaysinh + "',N'" + NV.Gioitinh + "',N'" + NV.Quequan + "',N'" + NV.Chucvu + "','" + NV.Luong + "',null,null,'"+NV.MaTro+"'";
                }
                else if (NV.MaKhu == -1 && NV.MaTro == -1)
                {
                    query = " sp_Nhanvien_update '" + NV.ID + "',N'" + NV.Hoten + "','" + NV.Ngaysinh + "',N'" + NV.Gioitinh + "',N'" + NV.Quequan + "',N'" + NV.Chucvu + "','" + NV.Luong + "','"+NV.MaPB+"',null,null";
                }
                else if (NV.MaTro == -1 && NV.MaPB == -1)
                {
                    query = " sp_Nhanvien_update '" + NV.ID + "',N'" + NV.Hoten + "','" + NV.Ngaysinh + "',N'" + NV.Gioitinh + "',N'" + NV.Quequan + "',N'" + NV.Chucvu + "','" + NV.Luong + "',null,'"+NV.MaKhu+"',null";
                }
                else if (NV.MaKhu == -1)
                {
                    query = " sp_Nhanvien_update '" + NV.ID + "',N'" + NV.Hoten + "','" + NV.Ngaysinh + "',N'" + NV.Gioitinh + "',N'" + NV.Quequan + "',N'" + NV.Chucvu + "','" + NV.Luong + "','" + NV.MaPB + "',null,'"+NV.MaTro+"'";
                }
                else if (NV.MaTro == -1)
                {
                    query = " sp_Nhanvien_update '" + NV.ID + "',N'" + NV.Hoten + "','" + NV.Ngaysinh + "',N'" + NV.Gioitinh + "',N'" + NV.Quequan + "',N'" + NV.Chucvu + "','" + NV.Luong + "','" + NV.MaPB + "','" + NV.MaKhu + "',null";
                }
                else if (NV.MaPB == -1)
                {
                    query = " sp_Nhanvien_update '" + NV.ID + "',N'" + NV.Hoten + "','" + NV.Ngaysinh + "',N'" + NV.Gioitinh + "',N'" + NV.Quequan + "',N'" + NV.Chucvu + "','" + NV.Luong + "',null,'" + NV.MaKhu + "','"+NV.MaTro+"'";
                }
                else
                    query = " sp_Nhanvien_update '" + NV.ID + "',N'" + NV.Hoten + "','" + NV.Ngaysinh + "',N'" + NV.Gioitinh + "',N'" + NV.Quequan + "',N'" + NV.Chucvu + "','" + NV.Luong + "','" + NV.MaPB + "','" + NV.MaKhu + "','" + NV.MaTro + "'";
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception e)
            { }
            return false;
        }
        public bool CheckMaPB(int MaPB)
        {
            string query = "sp_CheckMaPB @MaPB";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { MaPB });
            return result.Rows.Count > 0;
        }
        public bool CheckMaKhu(int MaKhu)
        {
            string query = "sp_CheckMaKhu @MaKhu";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { MaKhu });
            return result.Rows.Count > 0;
        }
        public bool CheckMaTro(int MaTro)
        {
            string query = "sp_CheckMaTro @MaTro";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { MaTro });
            return result.Rows.Count > 0;
        }
        public DataTable PhanTrangTK(int PageSize, int PageIndex, string TuKhoa)
        {
            string query = "sp_TimKiemNV_PhanTrang @PageSize , @PageIndex , @TuKhoa";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { PageSize, PageIndex, TuKhoa });
            return result;
        }
        public bool CheckNhanVien(string TuKhoa)
        {
            string query = "sp_Dem_TK_PhanTrang @TuKhoa";
            int result = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query, new object[] { TuKhoa }));
            if (result != 0)
                return true;
            return false;
        }
        public int DemNV_TK(string TuKhoa)
        {
            string query = "sp_Dem_TK_PhanTrang @TuKhoa";
            int rows = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query, new object[] { TuKhoa }));
            return rows;
        }
        public int DemNV()
        {
            string query = "select count(*) as Max from NhanVien";
            int rows = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query));
            return rows;
        }
    }
}
