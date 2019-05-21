using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLy.Entity
{
    public class PhongBan
    {
        private int _ID;
        private string _TenPB;
        private int _MaTP;
        private string _NgayNC;
        private string _DiaDiem;
        public PhongBan()
        {
            _ID = -1;
            _TenPB = " ";
            _MaTP = -1;
            _NgayNC = "";
            _DiaDiem = " ";
        }
        public PhongBan(int ID, string TenPB, int MaTP, string NgayNC, string DiaDiem)
        {
            this._ID = ID;
            this._TenPB = TenPB;
            this._MaTP = MaTP;
            this._NgayNC = NgayNC;
            this._DiaDiem = DiaDiem;
        }
        public int ID {
            set {
                this._ID = value;
            }
            get {
                return this._ID;
            }
        }
        public string TenPB
        {
            set
            {
                this._TenPB = value;
            }
            get
            {
                return this._TenPB;
            }
        }
        public int MaTP
        {
            set
            {
                this._MaTP = value;
            }
            get
            {
                return this._MaTP;
            }
        }
        public string NgayNC
        {
            set
            {
                this._NgayNC = value;
            }
            get
            {
                return this._NgayNC;
            }
        }
        public string DiaDiem
        {
            set
            {
                this._DiaDiem = value;
            }
            get
            {
                return this._DiaDiem;
            }
        }
    }
}
