using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLy.DAO;
using QuanLy.Entity;
using System.Data;
namespace QuanLy.BLL
{
    public class VeBLL
    {
        public VeBLL() { }
        VeDAO Ve = new VeDAO();

        public DataTable Ve_Select(int PageSize, int PageIndex)
        {
            return Ve.Ve_Select(PageSize,PageIndex);
        }
        public bool Ve_Insert(Ve ve)
        {
            return Ve.Ve_Insert(ve);
        }
        public bool Ve_Delete(Ve ve)
        {
            return Ve.Ve_Delete(ve);
        }
        public bool Ve_Update(Ve ve)
        {
            return Ve.Ve_Update(ve);
        }
        public bool CheckMaKhu(int MaKhu)
        {
            return Ve.CheckMaKhu(MaKhu);
        }
        public bool CheckMaNV(int MaNV)
        {
            return Ve.CheckMaNV(MaNV);
        }
        public int DemVe()
        {
            return Ve.DemVe();
        }
        public DataTable PhanTrangVe(int PageSize, int PageIndex, string TuKhoa)
        {
            return Ve.PhanTrangVe(PageSize, PageIndex, TuKhoa);
        }
        public int DemVe_TK(string TuKhoa)
        {
            return Ve.DemVe_TK(TuKhoa);
        }
        public bool CheckDemVe_TK(string TuKhoa)
        {
            return Ve.CheckDemVe_TK(TuKhoa);
        }
    }
}
