using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLy.Entity
{
    class TroChoi
    {
        private int _IDGame;
        private string _TenTro;
        private int _IDGround;
        public TroChoi()
        {
            _IDGame = -1;
            _TenTro = " ";
            _IDGround = -1;
        }
        public TroChoi(int IDGame, string TenTro, int IDGround)
        {
            this._IDGame = IDGame;
            this._TenTro = TenTro;
            this._IDGround = IDGround;
        }
        public int IDGame
        {
            set {
                this._IDGame = value;
            }
            get {
                return this._IDGame;
            }
        }
        public string TenTro
        {
            set
            {
                this._TenTro = value;
            }
            get
            {
                return this._TenTro;
            }
        }
        public int IDGround
        {
            set
            {
                this._IDGround = value;
            }
            get
            {
                return this._IDGround;
            }
        }
    }
}
