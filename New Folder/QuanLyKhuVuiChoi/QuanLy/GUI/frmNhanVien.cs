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
    public partial class frmNhanVien : Form
    {
        BindingSource NhanVien = new BindingSource();
        NhanvienBLL Nhanvien = new NhanvienBLL();
        public frmNhanVien()
        {
            InitializeComponent();
            LoadData();
        }
        int PageIndex = 1;
        int PageSize = 10;
        int PageNumber = 0;
        int FistRow, LastRow;
        int rows;
        void LoadData()
        {
            Clear_BindingNV();
            FistRow = PageSize * (PageIndex - 1); //Dòng đầu
            LastRow = PageSize * (PageIndex);//Dòng cuối cùng của trang được chọn
            dtgNhanVien.DataSource = Nhanvien.Nhanvien_select(PageIndex, PageSize);
        }
        int MaNV;
        int MaPB = -1;
        int MaKhu = -1;
        int MaTro = -1;
        string NgaySinh;
        string GioiTinh;
        int Luong;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMaPB.Text != "")
                MaPB = Convert.ToInt32(txtMaPB.Text);
            if (txtMaKhu.Text != "")
                MaKhu = Convert.ToInt32(txtMaKhu.Text);
            if (txtMaTro.Text != "")
                MaTro = Convert.ToInt32(txtMaTro.Text);
            Luong = Convert.ToInt32(txtLuong.Text);
            NgaySinh = dtpNgaySinh.Value.ToString("MM/dd/yyyy");
            GioiTinh = cbbGioiTinh.Text;
            if (txtMaKhu.Text == "" && txtMaPB.Text == "" && txtMaTro.Text == "")
            {
                NhanVien NV = new NhanVien(-1, txtTenNV.Text, NgaySinh, GioiTinh, txtQueQuan.Text, txtChucVu.Text, Luong, MaPB, MaKhu, MaTro);
                if(Nhanvien.Nhanvien_Insert(NV))
                    LoadData();
                else
                    MessageBox.Show("Thất bại");
            }

            else if (txtMaKhu.Text == "" && txtMaPB.Text == "")
            {
                if (Nhanvien.CheckMaTro(MaTro))
                {
                    NhanVien NV = new NhanVien(-1, txtTenNV.Text, NgaySinh, GioiTinh, txtQueQuan.Text, txtChucVu.Text, Luong, MaPB, MaKhu, MaTro);
                    if (Nhanvien.Nhanvien_Insert(NV))
                        LoadData();
                    else
                        MessageBox.Show("Thất bại");
                }
                else
                    MessageBox.Show("Mã trò chơi không tồn tại", "Thông báo");
            }
            else if (txtMaKhu.Text == "" && txtMaTro.Text == "")
            {
                if (Nhanvien.CheckMaPB(MaPB))
                {
                    NhanVien NV = new NhanVien(-1, txtTenNV.Text, NgaySinh, GioiTinh, txtQueQuan.Text, txtChucVu.Text, Luong, MaPB, MaKhu, MaTro);
                    if(Nhanvien.Nhanvien_Insert(NV))
                        LoadData();
                    else
                        MessageBox.Show("Thất bại");
                }
                else
                    MessageBox.Show("Mã phòng ban không tồn tại", "Thông báo");
            }
            else if (txtMaTro.Text == "" && txtMaPB.Text == "")
            {
                if (Nhanvien.CheckMaKhu(MaKhu))
                {
                    NhanVien NV = new NhanVien(-1, txtTenNV.Text, NgaySinh, GioiTinh, txtQueQuan.Text, txtChucVu.Text, Luong, MaPB, MaKhu, MaTro);
                    if (Nhanvien.Nhanvien_Insert(NV))
                        LoadData();
                    else
                        MessageBox.Show("Thất bại");
                }
                else
                    MessageBox.Show("Mã khu không tồn tại", "Thông báo");
            }
            else if (txtMaKhu.Text == "")
            {
                if (Nhanvien.CheckMaPB(MaPB) && Nhanvien.CheckMaTro(MaTro))
                {
                    NhanVien NV = new NhanVien(-1, txtTenNV.Text, NgaySinh, GioiTinh, txtQueQuan.Text, txtChucVu.Text, Luong, MaPB, MaKhu, MaTro);
                    if (Nhanvien.Nhanvien_Insert(NV))
                        LoadData();
                    else
                        MessageBox.Show("Thất bại");
                }
                else
                    MessageBox.Show("Mã phòng ban hoặc mã trò không tồn tại", "Thông báo");
            }
            else if (txtMaPB.Text == "")
            {
                if (Nhanvien.CheckMaTro(MaTro) && Nhanvien.CheckMaKhu(MaKhu))
                {
                    NhanVien NV = new NhanVien(-1, txtTenNV.Text, NgaySinh, GioiTinh, txtQueQuan.Text, txtChucVu.Text, Luong, MaPB, MaKhu, MaTro);
                    if (Nhanvien.Nhanvien_Insert(NV))
                        LoadData();
                    else
                        MessageBox.Show("Thất bại");
                }
                else
                    MessageBox.Show("Mã khu hoặc mã trò không tồn tại", "Thông báo");
            }
            else if (txtMaTro.Text == "")
            {
                if (Nhanvien.CheckMaKhu(MaKhu) && Nhanvien.CheckMaPB(MaPB))
                {
                    NhanVien NV = new NhanVien(-1, txtTenNV.Text, NgaySinh, GioiTinh, txtQueQuan.Text, txtChucVu.Text, Luong, MaPB, MaKhu, MaTro);
                    if (Nhanvien.Nhanvien_Insert(NV))
                        LoadData();
                    else
                        MessageBox.Show("Thất bại");
                }
                else
                    MessageBox.Show("Mã khu hoặc phòng ban không tồn tại", "Thông báo");
            }
            else
            {
                if (Nhanvien.CheckMaKhu(MaKhu) && Nhanvien.CheckMaPB(MaPB) && Nhanvien.CheckMaTro(MaTro))
                {
                    NhanVien NV = new NhanVien(-1, txtTenNV.Text, NgaySinh, GioiTinh, txtQueQuan.Text, txtChucVu.Text, Luong, MaPB, MaKhu, MaTro);
                    if (Nhanvien.Nhanvien_Insert(NV))
                        LoadData();
                    else
                        MessageBox.Show("Thất bại");
                }
                else
                    MessageBox.Show("Mã khu, mã trò chơi hoặc mã phòng ban không tồn tại", "Thông báo");
            }
            DemPage();
            
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            MaNV = Convert.ToInt32(txtMaNV.Text);
            if (MessageBox.Show("Bạn có thực sự muốn xóa??", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                NhanVien NV = new NhanVien(MaNV,"","", "", "","", -1, -1, -1, -1);
                if (Nhanvien.Nhanvien_Delete(NV))
                    LoadData();
                else
                    MessageBox.Show("Thất bại");
                DemPage();
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if(txtMaNV.Text != "")
                MaNV = Convert.ToInt32(txtMaNV.Text);
            if (txtMaPB.Text != "")
                MaPB = Convert.ToInt32(txtMaPB.Text);
            if(txtMaKhu.Text != "")
                MaKhu = Convert.ToInt32(txtMaKhu.Text);
            if(txtMaTro.Text != "")
                MaTro = Convert.ToInt32(txtMaTro.Text);
            Luong = Convert.ToInt32(txtLuong.Text);
            NgaySinh = dtpNgaySinh.Value.ToString("MM/dd/yyyy");
            GioiTinh = cbbGioiTinh.Text;
            if (txtMaKhu.Text == "" && txtMaPB.Text == "" && txtMaTro.Text == "")
            {
                NhanVien NV = new NhanVien(MaNV, txtTenNV.Text, NgaySinh, GioiTinh, txtQueQuan.Text, txtChucVu.Text, Luong,MaPB, MaKhu, MaTro);
                if (Nhanvien.Nhanvien_Update(NV))
                    LoadData();
                else
                    MessageBox.Show("Thất bại");
            }

            else if (txtMaKhu.Text == "" && txtMaPB.Text == "")
            {
                if (Nhanvien.CheckMaTro(MaTro))
                {
                    NhanVien NV = new NhanVien(MaNV, txtTenNV.Text, NgaySinh, GioiTinh, txtQueQuan.Text, txtChucVu.Text, Luong, MaPB, MaKhu, MaTro);
                    if (Nhanvien.Nhanvien_Update(NV))
                        LoadData();
                    else
                        MessageBox.Show("Thất bại");
                }
                else
                    MessageBox.Show("Mã trò chơi không tồn tại", "Thông báo");
            }
            else if (txtMaKhu.Text == "" && txtMaTro.Text == "")
            {
                if (Nhanvien.CheckMaPB(MaPB))
                {
                    NhanVien NV = new NhanVien(MaNV, txtTenNV.Text, NgaySinh, GioiTinh, txtQueQuan.Text, txtChucVu.Text, Luong, MaPB, MaKhu, MaTro);
                    if (Nhanvien.Nhanvien_Update(NV))
                        LoadData();
                    else
                        MessageBox.Show("Thất bại");
                }
                else
                    MessageBox.Show("Mã phòng ban không tồn tại", "Thông báo");
            }
            else if (txtMaTro.Text == "" && txtMaPB.Text == "")
            {
                if (Nhanvien.CheckMaKhu(MaKhu))
                {
                    NhanVien NV = new NhanVien(MaNV, txtTenNV.Text, NgaySinh, GioiTinh, txtQueQuan.Text, txtChucVu.Text, Luong, MaPB, MaKhu, MaTro);
                    if (Nhanvien.Nhanvien_Update(NV))
                        LoadData();
                    else
                        MessageBox.Show("Thất bại");
                }
                else
                    MessageBox.Show("Mã khu không tồn tại", "Thông báo");
            }
            else if (txtMaKhu.Text == "")
            {
                if (Nhanvien.CheckMaPB(MaPB) && Nhanvien.CheckMaTro(MaTro))
                {
                    NhanVien NV = new NhanVien(MaNV, txtTenNV.Text, NgaySinh, GioiTinh, txtQueQuan.Text, txtChucVu.Text, Luong, MaPB, MaKhu, MaTro);
                    if (Nhanvien.Nhanvien_Update(NV))
                        LoadData();
                    else
                        MessageBox.Show("Thất bại");
                }
                else
                    MessageBox.Show("Mã phòng ban hoặc mã trò không tồn tại", "Thông báo");
            }
            else if (txtMaPB.Text == "")
            {
                if (Nhanvien.CheckMaTro(MaTro) && Nhanvien.CheckMaKhu(MaKhu))
                {
                    NhanVien NV = new NhanVien(MaNV, txtTenNV.Text, NgaySinh, GioiTinh, txtQueQuan.Text, txtChucVu.Text, Luong, MaPB, MaKhu, MaTro);
                    if (Nhanvien.Nhanvien_Update(NV))
                        LoadData();
                    else
                        MessageBox.Show("Thất bại");
                }
                else
                    MessageBox.Show("Mã khu hoặc mã trò không tồn tại", "Thông báo");
            }
            else if (txtMaTro.Text == "")
            {
                if (Nhanvien.CheckMaKhu(MaKhu) && Nhanvien.CheckMaPB(MaPB))
                {
                    NhanVien NV = new NhanVien(MaNV, txtTenNV.Text, NgaySinh, GioiTinh, txtQueQuan.Text, txtChucVu.Text, Luong, MaPB, MaKhu, MaTro);
                    if (Nhanvien.Nhanvien_Update(NV))
                        LoadData();
                    else
                        MessageBox.Show("Thất bại");
                }
                else
                    MessageBox.Show("Mã khu hoặc phòng ban không tồn tại", "Thông báo");
            }
            else
            {
                if (Nhanvien.CheckMaKhu(MaKhu) && Nhanvien.CheckMaPB(MaPB) && Nhanvien.CheckMaTro(MaTro))
                {
                    NhanVien NV = new NhanVien(MaNV, txtTenNV.Text, NgaySinh, GioiTinh, txtQueQuan.Text, txtChucVu.Text, Luong, MaPB, MaKhu, MaTro);
                    if (Nhanvien.Nhanvien_Update(NV))
                        LoadData();
                    else
                        MessageBox.Show("Thất bại");
                }
                else
                    MessageBox.Show("Mã khu, mã trò chơi hoặc mã phòng ban không tồn tại", "Thông báo");
            }
            DemPage();
        }
        void PhanTrangTK()
        {
            string TuKhoa = txtTim.Text;
            Clear_BindingNV();
            FistRow = PageSize * (PageIndex - 1); //Dòng đầu
            LastRow = PageSize * (PageIndex);//Dòng cuối cùng của trang được chọn
            dtgNhanVien.DataSource = Nhanvien.PhanTrangTK(PageSize,PageIndex,TuKhoa);
            BindingNV();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            if (txtTim.Text.Trim() != "")
            {
                string TuKhoa = txtTim.Text;
                if (Nhanvien.CheckNhanVien(TuKhoa) == true)
                {
                    rows = Nhanvien.DemNV_TK(TuKhoa);
                    PageTotal();
                    PhanTrangTK();
                }
                else
                    MessageBox.Show("Không có dữ liệu thỏa mãn -_-","Thông báo");
            }
            else
                MessageBox.Show("Mời bạn nhập khóa tìm kiếm","Thông báo");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        void BindingNV()
        {
            txtMaNV.DataBindings.Add(new Binding( "Text", dtgNhanVien.DataSource, "MaNV", true, DataSourceUpdateMode.Never));
            txtTenNV.DataBindings.Add(new Binding("Text", dtgNhanVien.DataSource, "HoTen", true, DataSourceUpdateMode.Never));
            dtpNgaySinh.DataBindings.Add(new Binding("Value", dtgNhanVien.DataSource, "NgaySinh", true, DataSourceUpdateMode.Never));
            txtQueQuan.DataBindings.Add(new Binding("Text", dtgNhanVien.DataSource, "QueQuan", true, DataSourceUpdateMode.Never));
            txtChucVu.DataBindings.Add(new Binding("Text", dtgNhanVien.DataSource, "ChucVu", true, DataSourceUpdateMode.Never));
            txtMaKhu.DataBindings.Add(new Binding("Text", dtgNhanVien.DataSource, "MaKhu", true, DataSourceUpdateMode.Never));
            txtMaPB.DataBindings.Add(new Binding("Text", dtgNhanVien.DataSource, "MaPB", true, DataSourceUpdateMode.Never));
            txtMaTro.DataBindings.Add(new Binding("Text", dtgNhanVien.DataSource, "MaTro", true, DataSourceUpdateMode.Never));
            txtLuong.DataBindings.Add(new Binding("Text", dtgNhanVien.DataSource, "Luong", true, DataSourceUpdateMode.Never));
            cbbGioiTinh.SelectedIndex.ToString("Text");
            cbbGioiTinh.DataBindings.Add(new Binding("Text", dtgNhanVien.DataSource, "GioiTinh", true, DataSourceUpdateMode.Never));

        }
        void Clear_BindingNV()
        {
            txtMaNV.DataBindings.Clear();
            txtTenNV.DataBindings.Clear();
            dtpNgaySinh.DataBindings.Clear();
            txtQueQuan.DataBindings.Clear();
            txtChucVu.DataBindings.Clear();
            txtMaKhu.DataBindings.Clear();
            txtMaPB.DataBindings.Clear();
            txtMaTro.DataBindings.Clear();
            txtLuong.DataBindings.Clear();
            cbbGioiTinh.DataBindings.Clear();
        }
        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {
            string MaNV = txtMaNV.Text;
            if (KiemTraDAO.Istance.CheckMaNV(MaNV))
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
            rows = Nhanvien.DemNV();
            PageTotal();
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
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
            string TuKhoa = txtTim.Text;
            PageIndex = Convert.ToInt32(cbPage.Text);
            if (Nhanvien.CheckNhanVien(TuKhoa) == false && txtTim.Text == "")
            {
                LoadData();
            }
            else
            {
                PhanTrangTK();
            }
        }

        private void dtgNhanVien_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Clear_BindingNV();
            BindingNV();
            
        }

        //private void dtgNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    BindingNV();
        //}

        
    }
}
