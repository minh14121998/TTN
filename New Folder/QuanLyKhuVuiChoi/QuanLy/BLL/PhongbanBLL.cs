using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLy.DAO;
using QuanLy.Entity;
namespace QuanLy.BLL
{
    public class PhongbanBLL
    {
        private static PhongbanBLL istance;

        public static PhongbanBLL Istance
        {
            get
            {
                if (istance == null)
                    istance = new PhongbanBLL();
                return istance; }
            private set { istance = value; }
        }
        public PhongbanBLL() { }
        PhongbanDAO Phongban = new PhongbanDAO();
        public DataTable Phongban_Select()
        {
            return Phongban.Phongban_Select();
        }
        public bool Phongban_Insert(PhongBan PB)
        {
            return Phongban.Phongban_Insert(PB);
        }
        public bool Phongban_Delete(PhongBan PB)
        {
            return Phongban.Phongban_Delete(PB);
        }
        public bool Phongban_Update(PhongBan PB)
        {
            return Phongban.Phongban_Update(PB);
        }
    }
}
