using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLy.DAO;

namespace QuanLy.GUI
{
    public partial class frmTroChoi : Form
    {
        BindingSource TroChoi = new BindingSource();
        public frmTroChoi()
        {
            InitializeComponent();
            LoadTroChoi();
            Binding();
        }
        void LoadTroChoi()
        {
            dtgTroChoi.DataSource = TroChoi;
            string query = "sp_Trochoi_Select";
            TroChoi.DataSource = DataProvider.Instance.ExecuteQuery(query);
            dtgTroChoi.Refresh();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string MaKhu = txtMaKhu.Text;
            if (KiemTraDAO.Istance.CheckMaKhu(MaKhu))
            {
                string query = "sp_TroChoi_Insert N'" + txtTenTro.Text + "','" + txtMaKhu.Text + "'";
                DataProvider.Instance.ExecuteNonQuery(query);
                LoadTroChoi();
            }
            else
                MessageBox.Show("Không tồn tại khu trò chơi có mã: "+MaKhu,"Thông báo");
            
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string MaKhu = txtMaKhu.Text;
            if (KiemTraDAO.Istance.CheckMaKhu(MaKhu))
            {
                string query = "sp_trochoi_Update '" + txtMaTro.Text + "',N'" + txtTenTro.Text + "','" + txtMaKhu.Text + "'";
                DataProvider.Instance.ExecuteNonQuery(query);
                LoadTroChoi();
            }
            else
                MessageBox.Show("Không tồn tại khu trò chơi có mã: " + MaKhu, "Thông báo");
            
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn xóa??", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                string query = "sp_TroChoi_Delete '" + txtMaTro.Text + "'";
                DataProvider.Instance.ExecuteNonQuery(query);
                LoadTroChoi();
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        void Binding()
        {
            txtMaTro.DataBindings.Add(new Binding("Text", dtgTroChoi.DataSource, "MaTro", true , DataSourceUpdateMode.Never));
            txtTenTro.DataBindings.Add(new Binding("Text", dtgTroChoi.DataSource, "TenTro", true, DataSourceUpdateMode.Never));
            txtMaKhu.DataBindings.Add(new Binding("Text", dtgTroChoi.DataSource, "MaKhu", true, DataSourceUpdateMode.Never));
        }

        private void txtMaTro_TextChanged(object sender, EventArgs e)
        {
            string MaTro = txtMaTro.Text;
            if (KiemTraDAO.Istance.CheckMaTro(MaTro))
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
