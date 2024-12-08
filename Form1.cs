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
    public partial class Form1 : Form
    {
        private BindingList<NhanVien> danhSachNhanVien;

        public Form1()
        {
            InitializeComponent();
            danhSachNhanVien = new BindingList<NhanVien>();
            dgvNhanVien.DataSource = danhSachNhanVien;
        }

        

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormNhanVien form = new FormNhanVien();
            if (form.ShowDialog() == DialogResult.OK)
            {
                danhSachNhanVien.Add(form.NhanVienMoi);
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow != null)
            {
                NhanVien nv = (NhanVien)dgvNhanVien.CurrentRow.DataBoundItem;
                FormNhanVien form = new FormNhanVien(nv); 
                if (form.ShowDialog() == DialogResult.OK)
                {
                    dgvNhanVien.Refresh();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (dgvNhanVien.CurrentRow != null)
            {
                
                NhanVien nv = (NhanVien)dgvNhanVien.CurrentRow.DataBoundItem;
                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa nhân viên: {nv.TenNV}?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    danhSachNhanVien.Remove(nv);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}