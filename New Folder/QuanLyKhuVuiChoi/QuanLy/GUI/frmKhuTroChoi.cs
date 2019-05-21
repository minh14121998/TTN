using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLy.DAO;
using QuanLy.Entity;
using QuanLy.BLL;
namespace QuanLy.GUI
{
    public partial class frmKhuTroChoi : Form
    {
        BindingSource KhuTroChoi = new BindingSource();
        KhutrochoiBLL Khutrochoi = new KhutrochoiBLL();
        public frmKhuTroChoi()
        {
            InitializeComponent();
            LoadData();
            AddDepartBinding();
        }
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
        }


        private void btnFirst_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            
        }
        void LoadData()
        {
            dtgKhuTroChoi.DataSource = KhuTroChoi;
            KhuTroChoi.DataSource = Khutrochoi.Khutrochoi_Select();
            dtgKhuTroChoi.Refresh();
        }
        int MaKhu;
        int GiaTreEm;
        int GiaNguoiLon;
        string GioMo;
        string GioDong;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            GiaTreEm = Convert.ToInt32(txtGiaTE.Text);
            GiaNguoiLon = Convert.ToInt32(txtGiaNL.Text);
            GioMo = dtpGioMo.Value.ToString("HH:mm");
            GioDong = dtpGioDong.Value.ToString("HH:mm");
            KhuTroChoi KTC = new Entity.KhuTroChoi(-1,txtTenKhu.Text,GiaNguoiLon,GiaTreEm,GioMo,GioDong);
            if (Khutrochoi.Khutrochoi_Insert(KTC))
                LoadData();
            else
                MessageBox.Show("Thất bại");
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            MaKhu = Convert.ToInt32(txtMaKhu.Text);
            GiaTreEm = Convert.ToInt32(txtGiaTE.Text);
            GiaNguoiLon = Convert.ToInt32(txtGiaNL.Text);
            GioMo = dtpGioMo.Value.ToString("HH:mm");
            GioDong = dtpGioDong.Value.ToString("HH:mm");
            KhuTroChoi KTC = new Entity.KhuTroChoi(MaKhu, txtTenKhu.Text, GiaNguoiLon, GiaTreEm,GioMo ,GioDong);
            if (Khutrochoi.Khutrochoi_Update(KTC))
                LoadData();
            else
                MessageBox.Show("Thất bại");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn xóa??", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                MaKhu = Convert.ToInt32(txtMaKhu.Text);
                KhuTroChoi KTC = new Entity.KhuTroChoi(MaKhu,"",-1,-1,"","");
                Khutrochoi.Khutrochoi_Delete(KTC);
                LoadData();
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        void AddDepartBinding()
        {
            txtMaKhu.DataBindings.Add(new Binding("Text", dtgKhuTroChoi.DataSource, "MaKhu", true, DataSourceUpdateMode.Never));
            txtTenKhu.DataBindings.Add(new Binding("Text", dtgKhuTroChoi.DataSource, "TenKhu", true, DataSourceUpdateMode.Never));
            txtGiaTE.DataBindings.Add(new Binding("Text", dtgKhuTroChoi.DataSource, "GiaTreEm", true, DataSourceUpdateMode.Never));
            txtGiaNL.DataBindings.Add(new Binding("Text", dtgKhuTroChoi.DataSource, "GiaNguoiLon", true, DataSourceUpdateMode.Never));
            dtpGioMo.Value.ToString("Text");
            dtpGioDong.Value.ToString("Text");
            dtpGioMo.DataBindings.Add(new Binding("Text", dtgKhuTroChoi.DataSource, "GioMoCua", true, DataSourceUpdateMode.Never));
            dtpGioDong.DataBindings.Add(new Binding("Text", dtgKhuTroChoi.DataSource, "GioDongCua", true, DataSourceUpdateMode.Never));
        }

        private void txtMaKhu_TextChanged(object sender, EventArgs e)
        {
            int MaKhu =Convert.ToInt32(txtMaKhu.Text);
            if (Khutrochoi.CheckMaKhu(MaKhu))
            {
                btnAdd.Enabled = false;
                btnChange.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = true;
                btnChange.Enabled = false;
                btnDelete.Enabled = false;
            }
        }
    }
}
