using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT4
{
    public partial class Form1 : Form
    {
        private List<NhanVien> danhSachNhanVien = new List<NhanVien>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var nhanVienForm = new NhanVienForm();
            if (nhanVienForm.ShowDialog() == DialogResult.OK)
            {
                var nhanVien = new NhanVien(nhanVienForm.MSNV, nhanVienForm.TenNV, nhanVienForm.LuongCB);
                danhSachNhanVien.Add(nhanVien);  // Thêm vào danh sách
                dataGridView1.Rows.Add(nhanVien.MSNV, nhanVien.TenNV, nhanVien.LuongCB);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var nhanVienForm = new NhanVienForm
                {
                    MSNV = dataGridView1.CurrentRow.Cells[0].Value.ToString(),
                    TenNV = dataGridView1.CurrentRow.Cells[1].Value.ToString(),
                    LuongCB = decimal.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString())
                };

                if (nhanVienForm.ShowDialog() == DialogResult.OK)
                {
                    dataGridView1.CurrentRow.Cells[0].Value = nhanVienForm.MSNV;
                    dataGridView1.CurrentRow.Cells[1].Value = nhanVienForm.TenNV;
                    dataGridView1.CurrentRow.Cells[2].Value = nhanVienForm.LuongCB;
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {

                var result = MessageBox.Show("Ban co chan muon xoa nhan vien nao khong?",
                                               "Xac nhan xoa",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {

                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                }
            }
            else
            {
                MessageBox.Show("Vui long chon 1 nhan vien de xoa.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
                this.Close();  
        }
    }
}
