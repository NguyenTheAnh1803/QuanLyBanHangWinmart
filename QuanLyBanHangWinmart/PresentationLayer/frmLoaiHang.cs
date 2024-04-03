using QuanLyBanHangWinmart.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHangWinmart
{
    public partial class frmLoaiHang : Form
    {
        LoaiHangHoaBLL loaiHangHoaBLL = new LoaiHangHoaBLL();
        HangHoaBLL hangHoaBLL = new HangHoaBLL();

        public frmLoaiHang()
        {
            InitializeComponent();
        }

        private void frmLoaiHang_Load(object sender, EventArgs e)
        {
            dgvLoaiHang.DataSource = loaiHangHoaBLL.layTatCaLoaiHang();

            dgvLoaiHang.Columns[0].HeaderText = "Mã loại hàng";
            dgvLoaiHang.Columns[1].HeaderText = "Tên loại hàng";

            dgvLoaiHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHangHoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void dgvLoaiHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || !btnThem.Enabled)
                return;

            string maLoaiHang = dgvLoaiHang.CurrentRow.Cells["sMaLoaiHang"].Value.ToString();
            txtMaLoaiHang.Text = maLoaiHang;
            txtTenLoaiHang.Text = dgvLoaiHang.CurrentRow.Cells["sTenLoaiHang"].Value.ToString();

            dgvHangHoa.DataSource = hangHoaBLL.layHangHoaTheoLoai(maLoaiHang);

            if (btnThem.Enabled == true)
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void resetValue()
        {
            txtMaLoaiHang.Clear();
            txtTenLoaiHang.Clear();
        }

        private bool validate()
        {
            bool check = true;
            errorValidate.Clear();

            if (txtMaLoaiHang.Text.Trim() == "")
            {
                errorValidate.SetError(txtMaLoaiHang, "Không được để trống!");
                check = false;
            }
            else if (txtMaLoaiHang.Text.Length > 10)
            {
                errorValidate.SetError(txtMaLoaiHang, "Không được quá 10 kí tự!");
                check = false;
            }

            if (txtTenLoaiHang.Text.Trim() == "")
            {
                errorValidate.SetError(txtTenLoaiHang, "Không được để trống!");
                check = false;
            }
            else if (txtTenLoaiHang.Text.Length > 100)
            {
                errorValidate.SetError(txtTenLoaiHang, "Không được quá 100 kí tự!");
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
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (validate())
                {
                    if (MessageBox.Show($"Bạn có muốn sửa loại hàng {txtMaLoaiHang.Text}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        loaiHangHoaBLL.suaLoaiHang(
                            txtMaLoaiHang.Text.Trim(),
                            txtTenLoaiHang.Text.Trim()
                        );

                        resetValue();

                        dgvLoaiHang.DataSource = loaiHangHoaBLL.layTatCaLoaiHang();
                    }

                }
            }
            catch (SqlException ex)
            {
                foreach (SqlError error in ex.Errors)
                {
                    if (error.Message == "Mã loại hàng không tồn tại!")
                        errorValidate.SetError(txtMaLoaiHang, error.Message);
                    else if (error.Message == "Tên loại hàng đã tồn tại!")
                        errorValidate.SetError(txtTenLoaiHang, error.Message);
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
                DataTable hangHoaTheoLoai = hangHoaBLL.layHangHoaTheoLoai(txtMaLoaiHang.Text);
                int count = hangHoaTheoLoai.Rows.Count;

                if (MessageBox.Show(
                    $"Loại hàng {txtMaLoaiHang.Text} đang được sử dụng bởi {count} hàng hóa khác. \nKhi bạn xóa sẽ xóa cả {count} hàng hóa này. \nBạn có chắc chắn muốn xóa loại hàng {txtMaLoaiHang.Text}", 
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    loaiHangHoaBLL.xoaLoaiHang(txtMaLoaiHang.Text);

                    resetValue();

                    dgvLoaiHang.DataSource = loaiHangHoaBLL.layTatCaLoaiHang();
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
                    loaiHangHoaBLL.themLoaiHang(
                        txtMaLoaiHang.Text.Trim(),
                        txtTenLoaiHang.Text.Trim()
                    );

                    btnThem.Enabled = true;
                    btnLuu.Enabled = false;

                    resetValue();

                    dgvLoaiHang.DataSource = loaiHangHoaBLL.layTatCaLoaiHang();
                }
            }
            catch (SqlException ex)
            {
                foreach (SqlError error in ex.Errors)
                {
                    if (error.Message == "Mã loại hàng đã tồn tại!")
                        errorValidate.SetError(txtMaLoaiHang, error.Message);
                    else if (error.Message == "Tên loại hàng đã tồn tại!")
                        errorValidate.SetError(txtTenLoaiHang, error.Message);
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

            btnXoa.Enabled = false;
            btnSua.Enabled = false;

            resetValue();

            dgvLoaiHang.DataSource = loaiHangHoaBLL.layTatCaLoaiHang();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                dgvLoaiHang.DataSource = loaiHangHoaBLL.timKiemLoaiHang(
                    txtMaLoaiHang.Text,
                    txtTenLoaiHang.Text
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra! {ex}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
