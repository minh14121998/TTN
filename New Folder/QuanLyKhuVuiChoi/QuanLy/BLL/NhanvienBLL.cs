using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLy.DAO;
using QuanLy.Entity;
namespace QuanLy.BLL
{
    public class NhanvienBLL
    {
        private static NhanvienBLL istance;

        public static NhanvienBLL Istance
        {
            get
            {
                if (istance == null)
                    istance = new NhanvienBLL();
                return istance; }
            private set { istance = value; }
        }
        public NhanvienBLL() { }
        NhanvienDAO Nhanvien = new NhanvienDAO();
        public DataTable Nhanvien_select(int PageIndex, int PageSize)
        {
            return Nhanvien.Nhanvien_Select(PageIndex, PageSize);
        }
        public bool Nhanvien_Insert(NhanVien NV)
        {
            return Nhanvien.Nhanvien_Insert(NV);
        }
        public bool Nhanvien_Delete(NhanVien NV)
        {
            return Nhanvien.Nhanvien_Delete(NV);
        }
        public bool Nhanvien_Update(NhanVien NV)
        {
            return Nhanvien.Nhanvien_Update(NV);
        }
        public bool CheckMaPB(int MaPB)
        {
            return Nhanvien.CheckMaPB(MaPB);
        }
        public bool CheckMaKhu(int MaKhu)
        {
            return Nhanvien.CheckMaKhu(MaKhu);
        }
        public bool CheckMaTro(int MaTro)
        {
            return Nhanvien.CheckMaTro(MaTro);
        }
        public DataTable PhanTrangTK(int PageSize, int PageIndex, string TuKhoa)
        {
            return Nhanvien.PhanTrangTK(PageSize, PageIndex, TuKhoa);
        }
        public bool CheckNhanVien(string TuKhoa)
        {
            return Nhanvien.CheckNhanVien(TuKhoa);
        }
        public int DemNV()
        {
            return Nhanvien.DemNV();
        }
        public int DemNV_TK(string TuKhoa)
        {
            return Nhanvien.DemNV_TK(TuKhoa);
        }
    }
}
