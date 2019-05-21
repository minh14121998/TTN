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
using QuanLy.BLL;
using QuanLy.Entity;
namespace QuanLy.GUI
{
    public partial class frmHoaDon : Form
    {
        BindingSource HoaDon = new BindingSource();
        HoaDonBLL Hoadon = new HoaDonBLL();
        public frmHoaDon()
        {
            InitializeComponent();
            LoadHoaDon();
        }
        int PageIndex = 1;
        int PageSize = 10;
        int PageNumber = 0;
        int FistRow, LastRow;
        int rows;
        void LoadHoaDon()
        {
            Clear_Binding();
            FistRow = PageSize * (PageIndex - 1); //Dòng đầu
            LastRow = PageSize * (PageIndex);//Dòng cuối cùng của trang được chọn
            dtgHoaDon.DataSource = Hoadon.HoaDon_Select(PageIndex, PageSize);
            Binding();
            lbSumPage.Refresh();
        }
        int MaHD;
        string NgaySD;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            NgaySD = dtpNgaySD.Value.ToString("MM/dd/yyyy");
            HoaDon HD = new HoaDon(-1, NgaySD);
            if (Hoadon.HoaDon_Insert(HD))
                LoadHoaDon();
            else
                MessageBox.Show("Thất bại");
            DemPage();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            MaHD = Convert.ToInt32(txtMaHD.Text);
            NgaySD = dtpNgaySD.Value.ToString("MM/dd/yyyy");
            HoaDon HD = new HoaDon(MaHD, NgaySD);
            if(Hoadon.HoaDon_Update(HD))
                LoadHoaDon();
            else
                MessageBox.Show("Thất bại");
            DemPage();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MaHD = Convert.ToInt32(txtMaHD.Text);
            NgaySD = dtpNgaySD.Value.ToString("MM/dd/yyyy");
            if (MessageBox.Show("Bạn có thực sự muốn xóa??", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                HoaDon HD = new HoaDon(MaHD, NgaySD);
                if(Hoadon.HoaDon_Delete(HD))
                    LoadHoaDon();
                else
                    MessageBox.Show("Thất bại");
                DemPage();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        void Binding()
        {
            txtMaHD.DataBindings.Add(new Binding("Text", dtgHoaDon.DataSource, "MaHD", true, DataSourceUpdateMode.Never));
            dtpNgaySD.DataBindings.Add(new Binding("Value", dtgHoaDon.DataSource, "NgaySD", true, DataSourceUpdateMode.Never));
        }
        void Clear_Binding()
        { 
            txtMaHD.DataBindings.Clear();
            dtpNgaySD.DataBindings.Clear();
        }
        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {
            string MaHD = txtMaHD.Text;
            if (KiemTraDAO.Istance.CheckMaHD(MaHD))
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
        void DemPage()
        {
            rows = Hoadon.DemHD();
            PageTotal();
        }
        private void frmHoaDon_Load(object sender, EventArgs e)
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
            cbPage.SelectedIndex = PageIndex-1;
        }
        void PhanTrangHoaDon()
        {
            string TuKhoa = txtTim.Text;
            Clear_Binding();
            FistRow = PageSize * (PageIndex - 1); //Dòng đầu
            LastRow = PageSize * (PageIndex);//Dòng cuối cùng của trang được chọn
            dtgHoaDon.DataSource = Hoadon.HoaDon_TK_PT(PageSize, PageIndex, TuKhoa);
            Binding();
        }
        private void cbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string TuKhoa = txtTim.Text;
            PageIndex = Convert.ToInt32(cbPage.Text);
            if (Hoadon.CheckHD(TuKhoa) == false && txtTim.Text.Trim() == "")
            {
                LoadHoaDon();
            }
            else
                PhanTrangHoaDon();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtTim.Text.Trim() != "")
            {
                string TuKhoa = txtTim.Text;
                if (Hoadon.DemHD_TK(TuKhoa)>0)
                {
                    rows = Hoadon.DemHD_TK(TuKhoa);
                    PageTotal();
                    PhanTrangHoaDon();
                }
                else
                    MessageBox.Show("Không có dữ liệu thỏa mãn -_-", "Thông báo");
            }
            else
                MessageBox.Show("Mời bạn nhập khóa tìm kiếm", "Thông báo");
        }
    }
}
