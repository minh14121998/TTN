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
    public partial class frmHoadon_Dichvu : Form
    {
        BindingSource LoadHDDV = new BindingSource();
        HoaDon_ChiTietBLL Hoadon = new HoaDon_ChiTietBLL();
        public frmHoadon_Dichvu()
        {
            InitializeComponent();
            LoadHoaDon_ChiTiet();
        }
        int MaHD;
        int MaDV;
        int SoLuong;
        string TenKH;
        void LoadHoaDon_ChiTiet()
        {
            Clear_Binding();
            FistRow = PageSize * (PageIndex - 1); //Dòng đầu
            LastRow = PageSize * (PageIndex);//Dòng cuối cùng của trang được chọn
            //string query = "sp_HoaDon_CT_Phantrang @PageSize , @PageIndex";
            //dtgHoaDon_DichVu.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] { PageSize, PageIndex });
            dtgHoaDon_DichVu.DataSource = Hoadon.HoaDon_ChiTiet_Select(PageIndex,PageSize);
            Binding();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text != "")
                MaHD = Convert.ToInt32(txtMaHD.Text);
            if (txtMaDV.Text != "")
                MaDV = Convert.ToInt32(txtMaDV.Text);
            if (txtSL.Text != "")
                SoLuong = Convert.ToInt32(txtSL.Text);
            if (Hoadon.CheckMaHD(MaHD) && Hoadon.CheckMaDV(MaDV))
            {
                HoaDon_ChiTiet HD = new HoaDon_ChiTiet(MaHD, MaDV, SoLuong, txtTenKH.Text);
                //string query = "sp_Hoadon_ChiTiet_Insert '" + txtMaHD.Text + "' , '" + txtMaDV.Text + "','" + txtSL.Text + "',N'" + txtTenKH.Text + "'";
                //DataProvider.Instance.ExecuteNonQuery(query);
                if (Hoadon.HoaDon_ChiTiet_Insert(HD))
                    LoadHoaDon_ChiTiet();
                else
                    MessageBox.Show("Thất bại");
                DemPage();
            }
            else
                MessageBox.Show("Mã hóa đơn hoặc mã dịch vụ không tồn tại","Thông báo");
        
        }
        private void btnChange_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text != "")
                MaHD = Convert.ToInt32(txtMaHD.Text);
            if (txtMaDV.Text != "")
                MaDV = Convert.ToInt32(txtMaDV.Text);
            if(txtSL.Text != "")
                SoLuong = Convert.ToInt32(txtSL.Text);
            if (Hoadon.CheckMaHD(MaHD) && Hoadon.CheckMaDV(MaDV))
            {
                HoaDon_ChiTiet HD = new HoaDon_ChiTiet(MaHD, MaDV, SoLuong, txtTenKH.Text);
                //string query = "sp_Hoadon_ChiTiet_Update '" + txtMaHD.Text + "', '" + txtMaDV.Text + "','" + txtSL.Text + "',N'" + txtTenKH.Text + "'";
                //DataProvider.Instance.ExecuteNonQuery(query);
                if(Hoadon.HoaDon_ChiTiet_Update(HD))
                    LoadHoaDon_ChiTiet();
                else
                    MessageBox.Show("Thất bại");
            }
            else
                MessageBox.Show("Mã hóa đơn hoặc mã dịch vụ không tồn tại", "Thông báo");
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text != "")
                MaHD = Convert.ToInt32(txtMaHD.Text);
            if (txtMaDV.Text != "")
                MaDV = Convert.ToInt32(txtMaDV.Text);
            if (MessageBox.Show("Bạn có thực sự muốn xóa??", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                HoaDon_ChiTiet HD = new HoaDon_ChiTiet(MaHD, MaDV,-1,"");
                //string query = "sp_Hoadon_ChiTiet_Delete '" + txtMaHD.Text + "', '" + txtMaDV.Text + "'";
                //DataProvider.Instance.ExecuteNonQuery(query);
                if(Hoadon.HoaDon_ChiTiet_Delete(HD))
                    LoadHoaDon_ChiTiet();
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
            txtMaHD.DataBindings.Add(new Binding("Text", dtgHoaDon_DichVu.DataSource, "MaHD", true,DataSourceUpdateMode.Never));
            txtMaDV.DataBindings.Add(new Binding("Text", dtgHoaDon_DichVu.DataSource, "MaDV", true, DataSourceUpdateMode.Never));
            txtSL.DataBindings.Add(new Binding("Text", dtgHoaDon_DichVu.DataSource, "SoLuong", true, DataSourceUpdateMode.Never));
            txtTenKH.DataBindings.Add(new Binding("Text", dtgHoaDon_DichVu.DataSource, "TenKH", true, DataSourceUpdateMode.Never));
        }
        void Clear_Binding()
        {
            txtMaHD.DataBindings.Clear();
            txtMaDV.DataBindings.Clear();
            txtSL.DataBindings.Clear();
            txtTenKH.DataBindings.Clear();
        }
        void TextChange()
        {
            if(txtMaHD.Text != "")
                MaHD = Convert.ToInt32(txtMaHD.Text);
            if(txtMaDV.Text != "")
                MaDV = Convert.ToInt32(txtMaDV.Text);
            if (Hoadon.CheckHD_CT(MaHD,MaDV))
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
        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {
            TextChange();
        }

        private void txtMaDV_TextChanged(object sender, EventArgs e)
        {
            TextChange();
        }
        int PageIndex = 1;
        int PageSize = 10;
        int PageNumber = 0;
        int FistRow, LastRow;
        int rows;
        void DemPage()
        {
            rows = Hoadon.DemHD_CT();
            PageTotal();
        }
        private void frmHoadon_Dichvu_Load(object sender, EventArgs e)
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

        private void cbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Clear_Binding();
            PageIndex = Convert.ToInt32(cbPage.Text);
            //FistRow = PageSize * (PageIndex - 1); //Dòng đầu
            //LastRow = PageSize * (PageIndex);//Dòng cuối cùng của trang được chọn
            //string query = "sp_HoaDon_CT_Phantrang @PageSize , @PageIndex";
            //dtgHoaDon_DichVu.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] { PageSize, PageIndex });
            LoadHoaDon_ChiTiet();
            //Binding();
        }
     
    }
}
