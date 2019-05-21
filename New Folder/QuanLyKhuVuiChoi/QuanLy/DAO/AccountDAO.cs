using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace QuanLy.DAO
{
    public class AccountDAO
    {
        private static AccountDAO istance;

        public static AccountDAO Istance
        {
            get
            {
                if (istance == null)
                    istance = new AccountDAO();
                return istance; }
            private set { istance = value; }
        }
        private AccountDAO() { }
        public bool Login(string usename,string password)
        {
            string query = "sp_Login @usename , @password";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[]{usename, password});
            return result.Rows.Count > 0;
        }
    }
}
