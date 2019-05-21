using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace QuanLy.Entity
{
    public class KhuTroChoi
    {
        private int _ID;
        private string _Tenkhu;
        private int _Gianguoilon;
        private int _Giatreem;
        private string _Giomocua;
        private string _Giodongcua;
        public KhuTroChoi()
        {
            _ID = -1;
            _Tenkhu = " ";
            _Gianguoilon = -1;
            _Giatreem = -1;
            _Giomocua = "";
            _Giodongcua = "";
        }
        public KhuTroChoi(int ID, string Tenkhu, int Gianguoilon, int Giatreem, string Giomocua, string Giodongcua)
        {
            this._ID = ID;
            this._Tenkhu = Tenkhu;
            this._Gianguoilon = Gianguoilon;
            this._Giatreem = Giatreem;
            this._Giomocua = Giomocua;
            this._Giodongcua = Giodongcua;
        }
        public int ID {
            set {
                this._ID = value;
            }
            get {
                return this._ID;
            }
        }
        public string Tenkhu
        {
            set
            {
                this._Tenkhu = value;
            }
            get
            {
                return this._Tenkhu;
            }
        }
        public int Gianguoilon
        {
            set
            {
                this._Gianguoilon = value;
            }
            get
            {
                return this._Gianguoilon;
            }
        }
        public int Giatreem
        {
            set
            {
                this._Giatreem = value;
            }
            get
            {
                return this._Giatreem;
            }
        }
        public string Giomocua
        {
            set
            {
                this._Giomocua = value;
            }
            get
            {
                return this._Giomocua;
            }
        }
        public string Giodongcua
        {
            set
            {
                this._Giodongcua = value;
            }
            get
            {
                return this._Giodongcua;
            }
        }
    }
}
