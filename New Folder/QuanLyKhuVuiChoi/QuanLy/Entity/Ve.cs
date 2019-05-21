using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLy.Entity
{
    public class Ve
    {
        private int _ID;
        private string _Ngayban;
        private int _SLTE;
        private int _SLNL;
        private int _MaNV;
        private int _MaKhu;
        private int _ChietKhau;
        public Ve()
        {
            _ID = -1;
            _Ngayban = "";
            _SLTE = -1;
            _SLNL = -1;
            _MaNV = -1;
            _MaKhu = -1;
            _ChietKhau = -1;
        }
        public Ve(int ID, string Ngayban, int SLTE, int SLNL, int MaNV, int MaKhu,int ChietKhau)
        {
            this._ID = ID;
            this._Ngayban = Ngayban;
            this._SLTE = SLTE;
            this._SLNL = SLNL;
            this._MaNV = MaNV;
            this._MaKhu = MaKhu;
            this._ChietKhau = ChietKhau;
        }
        public int ID {
            set {
                this._ID = value;
            }
            get {
                return this._ID;
            }
        }
        public string Ngayban
        {
            set
            {
                this._Ngayban = value;
            }
            get
            {
                return this._Ngayban;
            }
        }
        public int SLTE
        {
            set
            {
                this._SLTE = value;
            }
            get
            {
                return this._SLTE;
            }
        }
        public int SLNL
        {
            set
            {
                this._SLNL = value;
            }
            get
            {
                return this._SLNL;
            }
        }
        public int MaNV
        {
            set
            {
                this._MaNV = value;
            }
            get
            {
                return this._MaNV;
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
        public int ChietKhau
        {
            set
            {
                this._ChietKhau = value;
            }
            get
            {
                return this._ChietKhau;
            }
        }
    }
}
