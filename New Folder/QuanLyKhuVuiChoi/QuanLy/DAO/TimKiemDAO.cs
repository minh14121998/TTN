using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace QuanLy.DAO
{
    public class TimKiemDAO
    {
       private static TimKiemDAO istance;

       public static TimKiemDAO Istance
       {
           get
           {
               if (istance == null)
                   istance = new TimKiemDAO();
               return istance;
           }
           private set { istance = value; }
       }
       private TimKiemDAO() { }

       public void TimNhanVien(string TuKhoa)
       {
           string query = "sp_Tim_Nhanvien @TuKhoa";
           DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { TuKhoa });
       }
    }
}
