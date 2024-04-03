using QuanLyBanHangWinmart.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHangWinmart
{
    public partial class frmNhanVien : Form
    {
        NhanVienBLL nhanVienBLL = new NhanVienBLL();

        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = nhanVienBLL.getALLNhanVien();

            dgvNhanVien.Columns[0].HeaderText = "Mã NV";
            dgvNhanVien.Columns[1].HeaderText = "Tên NV";
            dgvNhanVien.Columns[2].HeaderText = "Giới tính";
            dgvNhanVien.Columns[3].HeaderText = "Quê quán";
            dgvNhanVien.Columns[4].HeaderText = "Ngày sinh";
            dgvNhanVien.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvNhanVien.Columns[5].HeaderText = "Ngày vào làm";
            dgvNhanVien.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvNhanVien.Columns[6].HeaderText = "SDT";
            dgvNhanVien.Columns[7].HeaderText = "Trạng thái";

            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            txtMaNV.Enabled = false;

            dtpNgayVaoLam.Value = DateTime.Today;
            dtpNgaySinhStart.Value = dtpNgaySinhStart.MinDate;
            dtpNgayVaoLamStart.Value = dtpNgayVaoLamStart.MinDate;
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || !btnThem.Enabled)
                return;

            if (tabContainer.SelectedTab == tpTimKiem)
            {
                tabContainer.SelectedTab = tpChinhSua;
            }

            txtMaNV.Text = dgvNhanVien.CurrentRow.Cells["sMaNV"].Value.ToString();
            txtTenNV.Text = dgvNhanVien.CurrentRow.Cells["sTenNV"].Value.ToString();
            cboGioiTinh.Text = dgvNhanVien.CurrentRow.Cells["bGioiTinh"].Value.ToString();
            txtQueQuan.Text = dgvNhanVien.CurrentRow.Cells["sQueQuan"].Value.ToString();
            dtpNgaySinh.Text = dgvNhanVien.CurrentRow.Cells["dNgaySinh"].Value.ToString();
            dtpNgayVaoLam.Text = dgvNhanVien.CurrentRow.Cells["dNgayVaoLam"].Value.ToString();
            txtSDT.Text = dgvNhanVien.CurrentRow.Cells["sSDT"].Value.ToString();
            cboTrangThai.Text = dgvNhanVien.CurrentRow.Cells["bTrangThai"].Value.ToString();

            if (btnThem.Enabled == true)
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtMaNV.Enabled = false;
            }
        }

        private void resetValue()
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            cboGioiTinh.Text = "";
            txtQueQuan.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            dtpNgayVaoLam.Value = DateTime.Now;
            txtSDT.Clear();
            cboTrangThai.Text = "";
        }

        private void resetValueS()
        {
            txtMaNVS.Clear();
            txtTenNVS.Clear();
            cboGioiTinhS.Text = "";
            txtQueQuanS.Clear();
            dtpNgaySinhStart.Value = dtpNgaySinhStart.MinDate;
            dtpNgaySinhEnd.Value = DateTime.Now;
            dtpNgayVaoLamStart.Value = dtpNgayVaoLamStart.MinDate;
            dtpNgayVaoLamEnd.Value = DateTime.Now;
            txtSDTS.Clear();
            cboTrangThaiS.Text = "";
        }

        private bool validate()
        {
            bool check = true;
            errorValidate.Clear();

            if (txtTenNV.Text.Trim() == "")
            {
                errorValidate.SetError(txtTenNV, "Không được để trống!");
                check = false;
            } 
            else if (txtTenNV.Text.Length > 70)
            {
                errorValidate.SetError(txtTenNV, "Không được quá 70 kí tự!");
                check = false;
            }

            if (cboGioiTinh.Text.Trim() == "")
            {
                errorValidate.SetError(cboGioiTinh, "Không được để trống!");
                check = false;
            }

            if (txtQueQuan.Text.Trim() == "")
            {
                errorValidate.SetError(txtQueQuan, "Không được để trống!");
                check = false;
            }
            else if (txtQueQuan.Text.Length > 255)
            {
                errorValidate.SetError(txtQueQuan, "Không được quá 255 kí tự!");
                check = false;
            }

            if (DateTime.Now < dtpNgayVaoLam.Value)
            {
                errorValidate.SetError(dtpNgayVaoLam, "Không được vượt quá thời gian hiện tại!");
                check = false;
            }
            else if (dtpNgayVaoLam.Value.Year - dtpNgaySinh.Value.Year < 18)
            {
                errorValidate.SetError(dtpNgaySinh, "Khi vào làm nhân viên phải đủ 18 tuổi!");
                errorValidate.SetError(dtpNgayVaoLam, "Khi vào làm nhân viên phải đủ 18 tuổi!");
                check = false;
            }

            Regex isPhoneNumber = new Regex(@"^(84|0[3|5|7|8|9])+([0-9]{8})\b$");
            if (txtSDT.Text.Trim() == "")
            {
                errorValidate.SetError(txtSDT, "Không được để trống!");
                check = false;
            }
            else if (!isPhoneNumber.IsMatch(txtSDT.Text))
            {
                errorValidate.SetError(txtSDT, "Số điện thoại không hợp lệ!");
                check = false;
            }

            if (cboTrangThai.Text.Trim() == "")
            {
                errorValidate.SetError(cboTrangThai, "Không được để trống!");
                check = false;
            }

            return check;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnSua.Enabled == true)
                resetValue();

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;

            txtMaNV.Text = nhanVienBLL.taoMaNhanVien();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (validate())
                {
                    if (MessageBox.Show($"Bạn có muốn sửa nhân viên {txtMaNV.Text}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        nhanVienBLL.suaNhanVien(
                            txtMaNV.Text.Trim(),
                            txtTenNV.Text.Trim(),
                            cboGioiTinh.Text == "Nam",
                            txtQueQuan.Text.Trim(),
                            dtpNgaySinh.Value.Date,
                            dtpNgayVaoLam.Value.Date,
                            txtSDT.Text.Trim(),
                            cboTrangThai.Text == "Đang làm");

                        resetValue();

                        dgvNhanVien.DataSource = nhanVienBLL.getALLNhanVien();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra! {ex}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Bạn có muốn xóa nhân viên {txtMaNV.Text}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    nhanVienBLL.xoaNhanVien(txtMaNV.Text);

                    resetValue();

                    dgvNhanVien.DataSource = nhanVienBLL.getALLNhanVien();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra! {ex}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (validate())
                {
                    nhanVienBLL.themNhanVien(
                        txtMaNV.Text.Trim(),
                        txtTenNV.Text.Trim(),
                        cboGioiTinh.Text == "Nam",
                        txtQueQuan.Text.Trim(),
                        dtpNgaySinh.Value.Date,
                        dtpNgayVaoLam.Value.Date,
                        txtSDT.Text.Trim(),
                        cboTrangThai.Text == "Đang làm");

                    btnThem.Enabled = true;
                    btnLuu.Enabled = false;

                    resetValue();

                    dgvNhanVien.DataSource = nhanVienBLL.getALLNhanVien();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra! {ex}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            errorValidate.Clear();

            txtMaNV.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;

            if (btnThem.Enabled == false && tabContainer.SelectedTab == tpChinhSua)
            {
                btnThem.Enabled = true;
                btnLuu.Enabled = false;
            }

            resetValue();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                dgvNhanVien.DataSource = nhanVienBLL.timKiemNhanVien(
                    txtMaNVS.Text.Trim(),
                    txtTenNVS.Text.Trim(),
                    cboGioiTinhS.Text.Trim(),
                    txtQueQuanS.Text.Trim(),
                    dtpNgaySinhStart.Value.Date.ToString("yyyy/MM/dd"),
                    dtpNgaySinhEnd.Value.Date.ToString("yyyy/MM/dd"),
                    dtpNgayVaoLamStart.Value.Date.ToString("yyyy/MM/dd"),
                    dtpNgayVaoLamEnd.Value.Date.ToString("yyyy/MM/dd"),
                    txtSDTS.Text.Trim(),
                    cboTrangThaiS.Text.Trim()
                );

                lblSoLuong.Text = dgvNhanVien.RowCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra! {ex}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHienTatCa_Click(object sender, EventArgs e)
        {
            resetValueS();

            dgvNhanVien.DataSource = nhanVienBLL.getALLNhanVien();

            lblSoLuong.Text = dgvNhanVien.RowCount.ToString();
        }
    }
}
