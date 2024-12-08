using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baitapbuoi4
{
    public partial class FormNhanVien : Form
    {
        public NhanVien NhanVienMoi { get; set; }
        public FormNhanVien()
        {
            InitializeComponent();
        }

        public FormNhanVien(NhanVien nhanVien)
        {
            InitializeComponent();

            txtMSNV.Text = nhanVien.MSNV;
            txtTenNV.Text = nhanVien.TenNV;
            txtLuongCB.Text = nhanVien.LuongCB.ToString();
            NhanVienMoi = nhanVien;
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtMSNV.Text) ||
                string.IsNullOrWhiteSpace(txtTenNV.Text) ||
                string.IsNullOrWhiteSpace(txtLuongCB.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtLuongCB.Text, out double luongCB))
            {
                MessageBox.Show("Lương cơ bản phải là số.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (double.TryParse(txtTenNV.Text, out _))
            {
                MessageBox.Show("Tên nhân viên không được phép có số.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (NhanVienMoi == null)
            {
                NhanVienMoi = new NhanVien
                {
                    MSNV = txtMSNV.Text.Trim(),
                    TenNV = txtTenNV.Text.Trim(),
                    LuongCB = luongCB
                };
            }
            else
            {
                
                NhanVienMoi.TenNV = txtTenNV.Text.Trim();
                NhanVienMoi.LuongCB = luongCB;

            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        
    }
}
