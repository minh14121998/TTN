using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLy.Entity
{
    public class HoaDon_ChiTiet
    {
        private int _MaHD;
        private int _MaDV;
        private int _SoLuong;
        private string _TenKH;

        public HoaDon_ChiTiet()
        {
            _MaHD = -1;
            _MaDV = -1;
            _SoLuong = -1;
            _TenKH = "";
        }
        public HoaDon_ChiTiet(int MaHD, int MaDV, int SoLuong,string TenKH)
        {
            this._MaHD = MaHD;
            this._MaDV = MaDV;
            this._SoLuong = SoLuong;
            this._TenKH = TenKH;
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
        public int MaDV
        {
            set
            {
                this._MaDV = value;
            }
            get
            {
                return this._MaDV;
            }
        }
        public int SoLuong
        {
            set
            {
                this._SoLuong = value;
            }
            get
            {
                return this._SoLuong;
            }
        }
        public string TenKH
        {
            set
            {
                this._TenKH = value;
            }
            get
            {
                return this._TenKH;
            }
        }
    }
}
