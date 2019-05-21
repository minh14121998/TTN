using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLy.Entity
{
    public class DichVu
    {
        private int _MaDV;
        private string _TenDV;
        private int _GiaDV;
        private int _MaKhu;

        public DichVu()
        {
            _MaDV = -1;
            _TenDV = "";
            _GiaDV = -1;
            _MaKhu = -1;
        }
        public DichVu(int MaDV, string TenDV, int GiaDV, int MaKhu)
        {
            this._MaDV = MaDV;
            this._TenDV = TenDV;
            this._GiaDV = GiaDV;
            this._MaKhu = MaKhu;
        }
        public int MaDV
        {
            set {
                this._MaDV = value;
            }
            get {
                return this._MaDV;
            }
        }
        public string TenDV
        {
            set
            {
                this._TenDV = value;
            }
            get
            {
                return this._TenDV;
            }
        }
        public int GiaDV
        {
            set
            {
                this._GiaDV = value;
            }
            get
            {
                return this._GiaDV;
            }
        }
        public int MaKhu
        {
            set
            {
                this._MaKhu = value;
            }
            get
            {
                return this._MaKhu;
            }
        }
    }
}
