using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLy.Entity
{
    public class NhanVien
    {
        private int _ID;
        private string _Hoten;
        private string _Ngaysinh;
        private string _Gioitinh;
        private string _Quequan;
        private string _Chucvu;
        private int _Luong;
        private int _MaPB;
        private int _MaKhu;
        private int _MaTro;
        public NhanVien()
        {
            _ID = -1;
            _Hoten = " ";
            _Ngaysinh = "";
            _Gioitinh = " ";
            _Quequan = " ";
            _Chucvu = " ";
            _Luong = -1;
            _MaPB = -1;
            _MaKhu = -1;
            _MaTro = -1;
        }
        public NhanVien(int ID, string Hoten, string Ngaysinh, string GioiTinh, string Quequan, string Chucvu, int Luong, int MaPB, int MaKhu, int MaTro)
        {
            this._ID = ID;
            this._Hoten = Hoten;
            this._Ngaysinh = Ngaysinh;
            this._Gioitinh = GioiTinh;
            this._Quequan = Quequan;
            this._Chucvu = Chucvu;
            this._Luong = Luong;
            this._MaPB = MaPB;
            this._MaKhu = MaKhu;
            this._MaTro = MaTro;
        }
        public int ID {
            set {
                this._ID = value;
            }
            get {
                return this._ID;
            }
        }
        public string Hoten
        {
            set
            {
                this._Hoten = value;
            }
            get
            {
                return this._Hoten;
            }
        }
        public string Ngaysinh
        {
            set
            {
                this._Ngaysinh = value;
            }
            get
            {
                return this._Ngaysinh;
            }
        }
        public string Gioitinh
        {
            set
            {
                this._Gioitinh = value;
            }
            get
            {
                return this._Gioitinh;
            }
        }
        public string Quequan
        {
            set
            {
                this._Quequan = value;
            }
            get
            {
                return this._Quequan;
            }
        }
        public string Chucvu
        {
            set
            {
                this._Chucvu = value;
            }
            get
            {
                return this._Chucvu;
            }
        }
        public int Luong
        {
            set
            {
                this._Luong = value;
            }
            get
            {
                return this._Luong;
            }
        }
        public int MaPB
        {
            set
            {
                this._MaPB = value;
            }
            get
            {
                return this._MaPB;
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
        public int MaTro
        {
            set
            {
                this._MaTro = value;
            }
            get
            {
                return this._MaTro;
            }
        }
    }
}
