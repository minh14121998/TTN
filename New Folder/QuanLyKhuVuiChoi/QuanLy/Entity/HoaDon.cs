using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLy.Entity
{
    public class HoaDon
    {
        private int _MaHD;
        private string _NgaySD;

        public HoaDon()
        {
            _MaHD = -1;
            _NgaySD = "";
        }
        public HoaDon(int MaHD, string NgaySD)
        {
            this._MaHD = MaHD;
            this._NgaySD = NgaySD;
        }
        public int MaHD
        {
            set {
                this._MaHD = value;
            }
            get {
                return this._MaHD;
            }
        }
        public string NgaySD
        {
            set
            {
                this._NgaySD = value;
            }
            get
            {
                return this._NgaySD;
            }
        }
    }
}
