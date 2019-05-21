using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLy.DAO;
using QuanLy.Entity;
using System.Data;
namespace QuanLy.BLL
{
    public class DichVuBLL
    {
        private static DichVuBLL istance;

        public static DichVuBLL Istance
        {
            get
            {
                if (istance == null)
                    istance = new DichVuBLL();
                return istance; }
            private set { istance = value; }
        }
        public DichVuBLL() { }

        public DichVuDAO Dichvu = new DichVuDAO();

        public DataTable Dichvu_Select()
        {
            return Dichvu.DichVu_Select();
        }
        public bool Dichvu_Insert(DichVu DV)
        {
            return Dichvu.DichVu_Insert(DV);
        }
        public bool Dichvu_Update(DichVu DV)
        {
            return Dichvu.DichVu_Update(DV);
        }
        public bool Dichvu_Delete(DichVu DV)
        {
            return Dichvu.DichVu_Delete(DV);
        }
        public bool CheckMa(int MaKhu)
        {
            return Dichvu.CheckMaKhu(MaKhu);
        }
    }
}
