using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;

namespace QuanLy.GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }


        private void thôngTinQuảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongTinTK fAccPro = new frmThongTinTK();
            fAccPro.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhanVien frmEpl = new frmNhanVien();
            frmEpl.ShowDialog();
        }
        private void cSKHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.facebook.com/hoang.phon.79");
        }

        private void khuVuiChơiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhuTroChoi fplay = new frmKhuTroChoi();
            fplay.ShowDialog();
        }

        private void tròChơiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTroChoi fgame = new frmTroChoi();
            fgame.ShowDialog();
        }

        private void phòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhongBan PB = new frmPhongBan();
            PB.ShowDialog();
        }

        private void dịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDichVu fser = new frmDichVu();
            fser.ShowDialog();
        }

        private void véToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVe fve = new frmVe();
            fve.ShowDialog();
        }

        private void nhânViênToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmNhanVien fNV = new frmNhanVien();
            fNV.ShowDialog();
        }

        private void hóaĐơnToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmHoaDon fhd = new frmHoaDon();
            fhd.ShowDialog();
        }

        private void hóaĐơnDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoadon_Dichvu fhddv = new frmHoadon_Dichvu();
            fhddv.ShowDialog();
        }
    }
}
