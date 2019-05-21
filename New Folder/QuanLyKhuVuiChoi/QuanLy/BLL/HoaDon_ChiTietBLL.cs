using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLy.Entity;
using QuanLy.DAO;

namespace QuanLy.BLL
{
    public class HoaDon_ChiTietBLL
    {
        private static HoaDon_ChiTietBLL istance;
        public static HoaDon_ChiTietBLL Istance
       {
           get
           {
               if (istance == null)
                   istance = new HoaDon_ChiTietBLL();
               return istance;
           }
           private set { istance = value; }
       }
        public HoaDon_ChiTietBLL() { }

        HoaDon_ChiTietDAO HoaDon = new HoaDon_ChiTietDAO();
        public DataTable HoaDon_ChiTiet_Select(int PageIndex, int PageSize)
        {
            return HoaDon.HoaDon_ChiTiet_Select(PageIndex, PageSize);
        }
        public bool HoaDon_ChiTiet_Insert(HoaDon_ChiTiet HD)
        {
            return HoaDon.HoaDon_ChiTiet_Insert(HD);
        }
        public bool HoaDon_ChiTiet_Delete(HoaDon_ChiTiet HD)
        {
            return HoaDon.HoaDon_ChiTiet_Delete(HD);
        }
        public bool HoaDon_ChiTiet_Update(HoaDon_ChiTiet HD)
        {
            return HoaDon.HoaDon_ChiTiet_Update(HD);
        }
        public bool CheckMaHD(int MaHD)
        {
            return HoaDon.CheckMaHD(MaHD);
        }
        public bool CheckMaDV(int MaDV)
        {
            return HoaDon.CheckMaDV(MaDV);
        }
        public bool CheckHD_CT(int MaHD, int MaDV)
        {
            return HoaDon.CheckHD_CT(MaHD, MaDV);
        }
        public int DemHD_CT()
        {
            return HoaDon.DemHD_CT();
        }
    }
}
