using QuanLyBanHangWinmart.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class frmHangHoa : Form
    {
        HangHoaBLL hangHoaBLL = new HangHoaBLL(); 
        LoaiHangHoaBLL loaiHangHoaBLL = new LoaiHangHoaBLL();

        public frmHangHoa()
        {
            InitializeComponent();
        }

        private void frmHangHoa_Load(object sender, EventArgs e)
        {
            DataTable tblHangHoa = hangHoaBLL.layTatCaHangHoa();
            dgvHangHoa.DataSource = tblHangHoa;

            dgvHangHoa.Columns[0].HeaderText = "Mã hàng";
            dgvHangHoa.Columns[1].HeaderText = "Tên hàng";
            dgvHangHoa.Columns[2].HeaderText = "Đơn giá";
            dgvHangHoa.Columns[3].HeaderText = "Số lượng";
            dgvHangHoa.Columns[4].HeaderText = "Đơn vị tính";
            dgvHangHoa.Columns[5].HeaderText = "NSX";
            dgvHangHoa.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvHangHoa.Columns[6].HeaderText = "HSD";
            dgvHangHoa.Columns[6].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvHangHoa.Columns[7].HeaderText = "Mã loại hàng";

            dgvHangHoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            txtMaHang.Enabled = false;

            DataTable tblMaLoaiHang = loaiHangHoaBLL.layMaLoaiHang();
            cboMaLoaiHang.DataSource = tblMaLoaiHang;
            cboMaLoaiHang.ValueMember = "sMaLoaiHang";
            cboMaLoaiHang.DisplayMember = "sMaLoaiHang";
            cboMaLoaiHangS.DataSource = tblMaLoaiHang;
            cboMaLoaiHangS.ValueMember = "sMaLoaiHang";
            cboMaLoaiHangS.DisplayMember = "sMaLoaiHang";

            DataTable tblDonViTinh = tblHangHoa.DefaultView.ToTable(true, "sDonViTinh");
            cboDonViTinh.DataSource = tblDonViTinh;
            cboDonViTinh.ValueMember = "sDonViTinh";
            cboDonViTinh.DisplayMember = "sDonViTinh";
            cboDonViTinhS.DataSource = tblDonViTinh;
            cboDonViTinhS.ValueMember = "sDonViTinh";
            cboDonViTinhS.DisplayMember = "sDonViTinh";

            dtpNSX.Value = DateTime.Today;
            dtpHSD.Value = DateTime.Today;
            dtpNSXStart.Value = dtpNSXStart.MinDate;
            dtpNSXEnd.Value = DateTime.Now;
            dtpHSDStart.Value = dtpHSDStart.MinDate;
            dtpHSDEnd.Value = dtpHSDEnd.MaxDate;
            cboMaLoaiHangS.SelectedValue = "";
            cboDonViTinhS.SelectedValue = "";
        }

        private void dgvHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || !btnThem.Enabled)
                return;

            if (tabContainer.SelectedTab == tpTimKiem)
            {
                tabContainer.SelectedTab = tpChinhSua;
            }

            txtMaHang.Text = dgvHangHoa.CurrentRow.Cells["sMaHang"].Value.ToString();
            txtTenHang.Text = dgvHangHoa.CurrentRow.Cells["sTenHang"].Value.ToString();
            txtDonGia.Text = dgvHangHoa.CurrentRow.Cells["fGia"].Value.ToString();
            txtSoLuong.Text = dgvHangHoa.CurrentRow.Cells["fSoLuong"].Value.ToString();
            cboDonViTinh.Text = dgvHangHoa.CurrentRow.Cells["sDonViTinh"].Value.ToString();
            dtpNSX.Text = dgvHangHoa.CurrentRow.Cells["dNSX"].Value.ToString();
            dtpHSD.Text = dgvHangHoa.CurrentRow.Cells["dHSD"].Value.ToString();
            cboMaLoaiHang.Text = dgvHangHoa.CurrentRow.Cells["sMaLoaiHang"].Value.ToString();

            if (btnThem.Enabled == true)
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtMaHang.Enabled = false;
            }
        }

        private void resetValue()
        {
            txtMaHang.Clear();
            txtTenHang.Clear();
            txtDonGia.Clear();
            txtSoLuong.Clear();
            cboDonViTinh.Text = "";
            dtpNSX.Value = DateTime.Now;
            dtpHSD.Value = DateTime.Now;
            cboMaLoaiHang.Text = "";
        }

        private void resetValueS()
        {
            txtMaHangS.Clear();
            txtTenHangS.Clear();
            txtDonGiaStart.Clear();
            txtDonGiaEnd.Clear();
            txtSoLuongStart.Clear();
            txtSoLuongEnd.Clear();
            cboDonViTinhS.Text = "";
            dtpNSXStart.Value = dtpNSXStart.MinDate;
            dtpNSXEnd.Value = DateTime.Now;
            dtpHSDStart.Value = dtpHSDStart.MinDate;
            dtpHSDEnd.Value = dtpHSDStart.MaxDate;
            cboMaLoaiHangS.Text = "";
        }

        private void reload()
        {
            DataTable tblHangHoa = hangHoaBLL.layTatCaHangHoa();
            dgvHangHoa.DataSource = tblHangHoa;
            cboDonViTinh.DataSource = tblHangHoa.DefaultView.ToTable(true, "sDonViTinh");
            cboDonViTinh.DisplayMember = "sDonViTinh";
        }

        private bool validate()
        {
            bool check = true;
            errorValidate.Clear();

            if (txtMaHang.Text.Trim() == "")
            {
                errorValidate.SetError(txtMaHang, "Không được để trống!");
                check = false;
            }
            else if (txtMaHang.Text.Length > 10)
            {
                errorValidate.SetError(txtMaHang, "Không được quá 10 kí tự!");
                check = false;
            }

            if (cboMaLoaiHang.Text.Trim() == "")
            {
                errorValidate.SetError(cboMaLoaiHang, "Không được để trống!");
                check = false;
            }

            if (txtTenHang.Text.Trim() == "")
            {
                errorValidate.SetError(txtTenHang, "Không được để trống!");
                check = false;
            }
            else if (txtTenHang.Text.Length > 100)
            {
                errorValidate.SetError(txtTenHang, "Không được quá 100 kí tự!");
                check = false;
            }

            if (txtSoLuong.Text.Trim() == "")
            {
                errorValidate.SetError(txtSoLuong, "Không được để trống!");
                check = false;
            }
            else
            {
                float soLuong = 0;
                if (!float.TryParse(txtSoLuong.Text, out soLuong))
                {
                    errorValidate.SetError(txtSoLuong, "Số lượng không hợp lệ!");
                    check = false;
                }
                else if (soLuong < 0)
                {
                    errorValidate.SetError(txtSoLuong, "Số lượng phải lớn hơn hoặc bằng 0!");
                    check = false;
                }
            }

            if (txtDonGia.Text.Trim() == "")
            {
                errorValidate.SetError(txtDonGia, "Không được để trống!");
                check = false;
            }
            else
            {
                float donGia = 0;
                if (!float.TryParse(txtDonGia.Text, out donGia))
                {
                    errorValidate.SetError(txtDonGia, "Đơn giá không hợp lệ!");
                    check = false;
                }
                else if (donGia <= 0)
                {
                    errorValidate.SetError(txtDonGia, "Đơn giá phải lớn hơn 0!");
                    check = false;
                }
            }

            if (cboDonViTinh.Text.Trim() == "")
            {
                errorValidate.SetError(cboDonViTinh, "Không được để trống!");
                check = false;
            }
            else if (cboDonViTinh.Text.Length > 50)
            {
                errorValidate.SetError(cboDonViTinh, "Không được quá 50 kí tự!");
                check = false;
            }

            if (dtpNSX.Value.Date > DateTime.Today)
            {
                errorValidate.SetError(dtpNSX, "NSX không được vượt quá thời gian hiện tại!");
                check = false;
            }
            else if (dtpNSX.Value > dtpHSD.Value)
            {
                errorValidate.SetError(dtpNSX, "HSD phải lớn hơn hoặc bằng NSX!");
                errorValidate.SetError(dtpHSD, "HSD phải lớn hơn hoặc bằng NSX!");
                check = false;
            }

            return check;
        }

        private bool validateS()
        {
            bool check = true;
            errorValidate.Clear();

            float num;

            if (txtSoLuongStart.Text.Trim() != "" && !float.TryParse(txtSoLuongStart.Text, out num))
            {
                errorValidate.SetError(txtSoLuongStart, "Số lượng không hợp lệ!");
                check = false;
            }
            if (txtSoLuongEnd.Text.Trim() != "" && !float.TryParse(txtSoLuongEnd.Text, out num))
            {
                errorValidate.SetError(txtSoLuongEnd, "Số lượng không hợp lệ!");
                check = false;
            }

            if (txtDonGiaStart.Text.Trim() != "" && !float.TryParse(txtDonGiaStart.Text, out num))
            {
                errorValidate.SetError(txtDonGiaStart, "Đơn giá không hợp lệ!");
                check = false;
            }
            if (txtDonGiaEnd.Text.Trim() != "" && !float.TryParse(txtDonGiaEnd.Text, out num))
            {
                errorValidate.SetError(txtDonGiaEnd, "Đơn giá không hợp lệ!");
                check = false;
            }

            return check;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnSua.Enabled == true)
                resetValue();

            txtMaHang.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (validate())
                {
                    if (MessageBox.Show($"Bạn có muốn sửa hàng hóa {txtMaHang.Text}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        hangHoaBLL.suaHangHoa(
                            txtMaHang.Text.Trim(),
                            txtTenHang.Text.Trim(),
                            txtDonGia.Text.Trim(),
                            txtSoLuong.Text.Trim(),
                            cboDonViTinh.Text,
                            dtpNSX.Value.Date,
                            dtpHSD.Value.Date,
                            cboMaLoaiHang.Text);

                        resetValue();

                        reload();
                    }

                }
            }
            catch (SqlException ex)
            {
                foreach (SqlError error in ex.Errors)
                {
                    if (error.Message == "Không tồn lại loại hàng này!")
                        errorValidate.SetError(cboMaLoaiHang, error.Message);
                    else
                        MessageBox.Show($"Có lỗi xảy ra! {error.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                if (MessageBox.Show($"Bạn có muốn xóa hàng hóa {txtMaHang.Text}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    hangHoaBLL.xoaHangHoa(txtMaHang.Text);

                    resetValue();

                    reload();
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
                    hangHoaBLL.themHangHoa(
                            txtMaHang.Text.Trim(),
                            txtTenHang.Text.Trim(),
                            txtDonGia.Text.Trim(),
                            txtSoLuong.Text.Trim(),
                            cboDonViTinh.Text,
                            dtpNSX.Value.Date,
                            dtpHSD.Value.Date,
                            cboMaLoaiHang.Text);

                    btnThem.Enabled = true;
                    btnLuu.Enabled = false;

                    resetValue();

                    reload();
                }
            }
            catch (SqlException ex)
            {
                foreach (SqlError error in ex.Errors)
                {
                    if (error.Message == "Mã hàng đã tồn tại!")
                        errorValidate.SetError(txtMaHang, error.Message);
                    else if (error.Message == "Không tồn lại loại hàng này!")
                        errorValidate.SetError(cboMaLoaiHang, error.Message);
                    else
                        MessageBox.Show($"Có lỗi xảy ra! {error.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            txtMaHang.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;

            if (btnThem.Enabled == false && tabContainer.SelectedTab == tpChinhSua)
            {
                btnThem.Enabled = true;
                btnLuu.Enabled = false;
            }

            resetValue();
        }

        private void btnHienTatCa_Click(object sender, EventArgs e)
        {
            resetValueS();

            dgvHangHoa.DataSource = hangHoaBLL.layTatCaHangHoa();

            lblCount.Text = dgvHangHoa.RowCount.ToString();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateS())
                {
                    dgvHangHoa.DataSource = hangHoaBLL.timKiemHangHoa(
                        txtMaHangS.Text,
                        cboMaLoaiHangS.Text,
                        txtTenHangS.Text,
                        txtSoLuongStart.Text,
                        txtSoLuongEnd.Text,
                        txtDonGiaStart.Text,
                        txtDonGiaEnd.Text,
                        cboDonViTinhS.Text,
                        dtpNSXStart.Value.Date.ToString("yyyy/MM/dd"),
                        dtpNSXEnd.Value.Date.ToString("yyyy/MM/dd"),
                        dtpHSDStart.Value.Date.ToString("yyyy/MM/dd"),
                        dtpHSDEnd.Value.Date.ToString("yyyy/MM/dd")
                    );

                    lblCount.Text = dgvHangHoa.RowCount.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra! {ex}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
