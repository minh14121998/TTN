using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLy.Entity;
using QuanLy.DAO;
namespace QuanLy.BLL
{
    public class HoaDonBLL
    {
        private static HoaDonBLL istance;

        public static HoaDonBLL Istance
        {
            get
            {
                if (istance == null)
                    istance = new HoaDonBLL();
                return istance;
            }
            private set { istance = value; }
        }
        public HoaDonBLL() { }
        public HoaDonDAO Hoadon = new HoaDonDAO();

        public DataTable HoaDon_Select(int PageIndex, int PageSize)
        {
            return Hoadon.HoaDon_Select(PageIndex, PageSize);
        }
        public bool HoaDon_Insert(HoaDon HD)
        {
            return Hoadon.HoaDon_Insert(HD);
        }
        public bool HoaDon_Update(HoaDon HD)
        {
            return Hoadon.HoaDon_Update(HD);
        }
        public bool HoaDon_Delete(HoaDon HD)
        {
            return Hoadon.HoaDon_Delete(HD);
        }
        public int DemHD()
        {
            return Hoadon.DemHD();
        }
        public DataTable HoaDon_TK_PT(int PageSize, int PageIndex, string TuKhoa)
        {
            return Hoadon.PhanTrangTK(PageSize, PageIndex, TuKhoa);
        }
        public int DemHD_TK(string TuKhoa)
        {
            return Hoadon.DemHD_TK(TuKhoa);
        }
        public bool CheckHD(string TuKhoa)
        {
            return Hoadon.CheckHD(TuKhoa);
        }
    }
}
