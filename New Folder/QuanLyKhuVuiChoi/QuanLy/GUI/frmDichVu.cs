using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLy.DAO;
using QuanLy.BLL;
using QuanLy.Entity;
namespace QuanLy.GUI
{
    public partial class frmDichVu : Form
    {
        BindingSource DichVu = new BindingSource();
        DichVuBLL Dichvu = new DichVuBLL();
        public frmDichVu()
        {
            InitializeComponent();
            LoadDichVu();
            Binding();
        }
        void LoadDichVu()
        {
            dtgDichVu.DataSource = DichVu;
            DichVu.DataSource = Dichvu.Dichvu_Select();
            dtgDichVu.Refresh();
        }
        int GiaDV;
        int MaKhu;
        int MaDV;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            GiaDV = Convert.ToInt32(txtGiaDV.Text);
            MaKhu = Convert.ToInt32(txtMaKhu.Text);
            DichVu DV = new Entity.DichVu(-1,txtTenDV.Text,GiaDV,MaKhu);
            if (Dichvu.CheckMa(MaKhu))
            {
                Dichvu.Dichvu_Insert(DV);
                LoadDichVu();
            }
            else
                MessageBox.Show("Mã khu bạn nhập không tồn tại ","Thông báo");
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            GiaDV = Convert.ToInt32(txtGiaDV.Text);
            MaKhu = Convert.ToInt32(txtMaKhu.Text);
            MaDV = Convert.ToInt32(txtMaDV.Text);
            DichVu DV = new Entity.DichVu(MaDV,txtTenDV.Text,GiaDV,MaKhu);
            if (Dichvu.CheckMa(MaKhu))
            {
                if (Dichvu.Dichvu_Update(DV))
                {
                    LoadDichVu();
                }
            }
            else
                MessageBox.Show("Mã khu bạn nhập không tồn tại", "Thông báo");
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            MaDV = Convert.ToInt32(txtMaDV.Text);
            DichVu DV = new Entity.DichVu(MaDV,"",-1,-1);
            if (MessageBox.Show("Bạn có thực sự muốn xóa??", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (Dichvu.Dichvu_Delete(DV))
                    LoadDichVu();
                else
                    MessageBox.Show("Xóa thất bại");
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        void Binding()
        {
            txtMaDV.DataBindings.Add(new Binding("Text", dtgDichVu.DataSource, "MaDV", true, DataSourceUpdateMode.Never));
            txtTenDV.DataBindings.Add(new Binding("Text", dtgDichVu.DataSource, "tenDV", true, DataSourceUpdateMode.Never));
            txtGiaDV.DataBindings.Add(new Binding("Text", dtgDichVu.DataSource, "GiaDV", true, DataSourceUpdateMode.Never));
            txtMaKhu.DataBindings.Add(new Binding("Text", dtgDichVu.DataSource, "MaKhu", true, DataSourceUpdateMode.Never));
        }

        private void txtMaDV_TextChanged(object sender, EventArgs e)
        {
            string MaDV = txtMaDV.Text;
            if (KiemTraDAO.Istance.CheckMaDV(MaDV))
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
