using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLy.BLL;
using QuanLy.DAO;
using QuanLy.Entity;
namespace QuanLy.GUI
{
    public partial class frmPhongBan : Form
    {
        BindingSource LoadPB = new BindingSource();
        PhongbanBLL Phongban = new PhongbanBLL();
        public frmPhongBan()
        {
            InitializeComponent();
            LoadData();
            AddDepartBinding();
        }
        void LoadData()
        {
            dtgPhongBan.DataSource = LoadPB;
            LoadPB.DataSource = Phongban.Phongban_Select();
            dtgPhongBan.Refresh();
        }
        int MaPB;
        int MaTP;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMaTP.Text != "")
                MaTP = Convert.ToInt32(txtMaTP.Text);
            string MaNV = txtMaTP.Text;
            if (KiemTraDAO.Istance.CheckMaNV(MaNV))
            {
                PhongBan PB = new PhongBan(-1, txtTenPB.Text, MaTP, dtpNgayNC.Value.ToString("MM/dd/yyyy"), txtDiaDiem.Text);
                if(Phongban.Phongban_Insert(PB))
                    LoadData();
                else 
                    MessageBox.Show("Thất bại");
            }
            else
                MessageBox.Show("Không tồn tại nhân viên có mã: "+MaNV,"Thông báo");
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtMaTP.Text != "")
                MaTP = Convert.ToInt32(txtMaTP.Text);
            if (txtMaPB.Text != "")
                MaPB = Convert.ToInt32(txtMaPB.Text);
            if (MessageBox.Show("Bạn có thực sự muốn xóa??", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                PhongBan PB = new PhongBan(MaPB, "",-1, "","");
                if(Phongban.Phongban_Delete(PB))
                    LoadData();
                else
                    MessageBox.Show("Thất bại");
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (txtMaTP.Text != "")
                MaTP = Convert.ToInt32(txtMaTP.Text);
            if (txtMaPB.Text != "")
                MaPB = Convert.ToInt32(txtMaPB.Text);
            string MaNV = txtMaTP.Text;
            if (KiemTraDAO.Istance.CheckMaNV(MaNV))
            {
                PhongBan PB = new PhongBan(MaPB, txtTenPB.Text, MaTP, dtpNgayNC.Value.ToString("MM/dd/yyyy"), txtDiaDiem.Text);
                if(Phongban.Phongban_Update(PB))
                    LoadData();
                else
                    MessageBox.Show("Thất bại");
            }
            else
                MessageBox.Show("Không tồn tại nhân viên có mã: " + MaNV, "Thông báo");
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        void AddDepartBinding()
        {
            txtMaPB.DataBindings.Add(new Binding("Text", dtgPhongBan.DataSource, "MaPB",true,DataSourceUpdateMode.Never));
            txtTenPB.DataBindings.Add(new Binding("Text", dtgPhongBan.DataSource, "TenPB",true,DataSourceUpdateMode.Never));
            txtMaTP.DataBindings.Add(new Binding("Text", dtgPhongBan.DataSource, "MaTP",true,DataSourceUpdateMode.Never));
            dtpNgayNC.DataBindings.Add(new Binding("Value", dtgPhongBan.DataSource, "NgayNC", true,DataSourceUpdateMode.Never));
            txtDiaDiem.DataBindings.Add(new Binding("Text", dtgPhongBan.DataSource, "DiaDiem",true,DataSourceUpdateMode.Never));

        }

        private void txtMaPB_TextChanged(object sender, EventArgs e)
        {
            string MaPB = txtMaPB.Text;
            if (KiemTraDAO.Istance.CheckMaPB(MaPB))
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

        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            
        }
    }
}
