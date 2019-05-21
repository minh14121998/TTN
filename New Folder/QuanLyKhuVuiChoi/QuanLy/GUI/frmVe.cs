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
    public partial class frmVe : Form
    {
        BindingSource Ve = new BindingSource();
        VeDAO ve = new VeDAO();
        public frmVe()
        {
            InitializeComponent();
            LoadVe();
        }
        int MaVe;
        string NgaySD;
        int SLTE;
        int SLNL;
        int MaKhu;
        int MaNV;
        int ChietKhau;
        void LoadVe()
        {
            Clear_Binding();
            dtgVe.DataSource = Ve;
            FistRow = PageSize * (PageIndex - 1); //Dòng đầu
            LastRow = PageSize * (PageIndex);//Dòng cuối cùng của trang được chọn
            Ve.DataSource = ve.Ve_Select(PageSize, PageIndex);
            Binding();
            dtgVe.Refresh();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtSLTE.Text != "")
                SLTE = Convert.ToInt32(txtSLTE.Text);
            if (txtSLNL.Text != "")
                SLNL = Convert.ToInt32(txtSLNL.Text);
            if (txtMaKhu.Text != "")
                MaKhu = Convert.ToInt32(txtMaKhu.Text);
            if (txtMaNV.Text != "")
                MaNV = Convert.ToInt32(txtMaNV.Text);
            if (txtKhuyenMai.Text != "")
                ChietKhau = Convert.ToInt32(txtKhuyenMai.Text);
            if (txtKhuyenMai.Text == "")
                ChietKhau = -1;
            if (ve.CheckMaNV(MaNV)&& ve.CheckMaKhu(MaKhu))
            {
                Ve v = new Entity.Ve(-1, dtpNgayban.Value.ToString("MM/dd/yyyy"), SLTE, SLNL, MaNV, MaKhu,ChietKhau);
                if (ve.Ve_Insert(v))
                    LoadVe();
                else
                    MessageBox.Show("Thất bại");
                DemPage();
            }
            else
                MessageBox.Show("Mã nhân viên hoặc mã khu không tồn tại ", "Thông báo");

            
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (txtMave.Text != "")
                MaVe = Convert.ToInt32(txtMave.Text);
            if (txtSLTE.Text != "")
                SLTE = Convert.ToInt32(txtSLTE.Text);
            if (txtSLNL.Text != "")
                SLNL = Convert.ToInt32(txtSLNL.Text);
            if (txtMaKhu.Text != "")
                MaKhu = Convert.ToInt32(txtMaKhu.Text);
            if (txtMaNV.Text != "")
                MaNV = Convert.ToInt32(txtMaNV.Text);
            if (txtKhuyenMai.Text != "")
                ChietKhau = Convert.ToInt32(txtKhuyenMai.Text);
            if (txtKhuyenMai.Text == "")
                ChietKhau = -1;
            if (ve.CheckMaNV(MaNV) && ve.CheckMaKhu(MaKhu))
            {
                Ve v = new Entity.Ve(MaVe, dtpNgayban.Value.ToString("MM/dd/yyyy"), SLTE, SLNL, MaNV, MaKhu,ChietKhau);
                if(ve.Ve_Update(v))
                    LoadVe();
                else
                    MessageBox.Show("Thất bại");
            }
            else
                MessageBox.Show("Không tồn tại nhân viên có mã: " + MaNV, "Thông báo");
            DemPage();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtMave.Text != "")
                MaVe = Convert.ToInt32(txtMave.Text);
            if (MessageBox.Show("Bạn có thực sự muốn xóa??", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Ve v = new Entity.Ve(MaVe,"", -1, -1, -1, -1, -1);
                if(ve.Ve_Delete(v))
                    LoadVe();
                else
                    MessageBox.Show("Thất bại");
            }
            DemPage();
        }
        void Binding()
        {
            txtMave.DataBindings.Add(new Binding("Text", dtgVe.DataSource, "MaVe", true, DataSourceUpdateMode.Never));
            dtpNgayban.DataBindings.Add(new Binding("Value", dtgVe.DataSource, "NgayBan", true, DataSourceUpdateMode.Never));
            txtSLTE.DataBindings.Add(new Binding("Text", dtgVe.DataSource, "SLTE", true, DataSourceUpdateMode.Never));
            txtSLNL.DataBindings.Add(new Binding("Text", dtgVe.DataSource, "SLNL", true, DataSourceUpdateMode.Never));
            txtMaNV.DataBindings.Add(new Binding("Text", dtgVe.DataSource, "MaNV", true, DataSourceUpdateMode.Never));
            txtMaKhu.DataBindings.Add(new Binding("Text", dtgVe.DataSource, "MaKhu", true, DataSourceUpdateMode.Never));
            //txtKhuyenMai.DataBindings.Add(new Binding("Text", dtgVe.DataSource, "ChietKhau", true, DataSourceUpdateMode.Never));
        }
        void Clear_Binding()
        { 
            txtMave.DataBindings.Clear();
            dtpNgayban.DataBindings.Clear();
            txtSLTE.DataBindings.Clear();
            txtSLNL.DataBindings.Clear();
            txtMaNV.DataBindings.Clear();
            txtMaKhu.DataBindings.Clear();
        }
        private void txtMave_TextChanged(object sender, EventArgs e)
        {
            string MaVe = txtMave.Text;
            if (KiemTraDAO.Istance.CheckMaVe(MaVe))
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
        int PageIndex = 1;
        int PageSize = 10;
        int PageNumber = 0;
        int FistRow, LastRow;
        int rows;
        void DemPage()
        {
            rows = ve.DemVe();
            PageTotal();
        }
        private void frmVe_Load(object sender, EventArgs e)
        {
            DemPage();
        }
        void PageTotal()
        {
            PageNumber = rows % PageSize != 0 ? rows / PageSize + 1 : rows / PageSize; //Tính xem có báo nhiêu trang nếu có pageSize trên trang
            lbSumPage.Text = " / " + PageNumber.ToString();
            cbPage.Items.Clear();
            for (int i = 1; i <= PageNumber; i++)
                cbPage.Items.Add(i + "");
            cbPage.SelectedIndex = PageIndex - 1;
        }

        //private void cbPage_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    PageIndex = Convert.ToInt32(cbPage.Text);
        //    string TuKhoa = txtTim.Text;
        //    LoadVe();
        //    //if (ve.CheckDemVe_TK(TuKhoa) == false && txtTim.Text.Trim() == "")
        //    //{
        //    //    LoadVe();
        //    //}
        //    //else
        //    //    PhanTrangVe();
        //}
        void PhanTrangVe()
        {
            string TuKhoa = txtTim.Text;
            Clear_Binding();
            FistRow = PageSize * (PageIndex - 1); //Dòng đầu
            LastRow = PageSize * (PageIndex);//Dòng cuối cùng của trang được chọn
            dtgVe.DataSource = ve.PhanTrangVe(PageSize, PageIndex, TuKhoa);
            Binding();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtTim.Text.Trim() != "")
            {
                string TuKhoa = txtTim.Text;
                if (ve.CheckDemVe_TK(TuKhoa) == true)
                {
                    rows = ve.DemVe_TK(TuKhoa);
                    PageTotal();
                    PhanTrangVe();
                }
                else
                    MessageBox.Show("Không có dữ liệu thỏa mãn -_-", "Thông báo");
            }
            else
                MessageBox.Show("Mời bạn nhập khóa tìm kiếm", "Thông báo");
        }

        private void cbPage_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            PageIndex = Convert.ToInt32(cbPage.Text);
            string TuKhoa = txtTim.Text;
            if (ve.CheckDemVe_TK(TuKhoa) == false && txtTim.Text.Trim() == "")
            {
                LoadVe();
            }
            else
                PhanTrangVe();
        }


    }
}
