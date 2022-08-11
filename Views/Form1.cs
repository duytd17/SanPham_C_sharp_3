using Project_Template_SM22_Csharp.DomainClass;
using Project_Template_SM22_Csharp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project_Template_SM22_Csharp.Views
{
    public partial class Form1 : Form
    {
        SanPhamService _spService;
        public Form1()
        {
            InitializeComponent();
            _spService = new SanPhamService();
            LoadData(null);
            LoadLocTrangThai();
        }

        public void LoadLocTrangThai()
        {
            List<string> _lst = new List<string>() { "Hoạt động", "Không hoạt động" };
            foreach( var x in _lst)
            {
                cmb_Loc.Items.Add(x);
            }
        }
        public void LoadData(SanPham obj)
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Ma";
            dataGridView1.Columns[1].Name = "Ten";
            dataGridView1.Columns[2].Name = "Gia";
            dataGridView1.Columns[3].Name = "Trang thai";
            dataGridView1.Rows.Clear();
            foreach(var x in _spService.GetSanPham(obj))
            {
                dataGridView1.Rows.Add(x.Ma, x.Ten,x.GiaBan, (x.TrangThai == 1 ? "Hoạt động" : "Không hoạt động"));
            }
        }
        public SanPham GetDataFromGui()
        {
            return new SanPham()
            {
                Ma = txt_Ma.Text,
                Ten = txt_Ten.Text,
                GiaBan = decimal.Parse(txt_GIaBan.Text),
                TrangThai = (cbx_HoatDong.Checked == true ? 1 : 0),

            };
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_spService.AddSP(GetDataFromGui()));
            LoadData(null);
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_spService.DeleteSP(GetDataFromGui()));
            LoadData(null);
        }
        //nên làm lọc kiểu này khi bắt lọc 2 đk: hđ với kohđ hoặc nam với nữ. Còn nếu lọc nhiều trường thì sẽ làm cách khác bạn nhé :> 
        public void LocHoatDong()
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Ma";
            dataGridView1.Columns[1].Name = "Ten";
            dataGridView1.Columns[2].Name = "Gia";
            dataGridView1.Columns[3].Name = "Trang thai";
            dataGridView1.Rows.Clear();
            foreach (var x in _spService.GetSanPham().Where(c => c.TrangThai == 1 ? true : false))
            {
                dataGridView1.Rows.Add(x.Ma, x.Ten, x.GiaBan, (x.TrangThai == 1 ? "Hoạt động" : "Không hoạt động"));
            }
        }

        public void LocKoHoatDong()
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Ma";
            dataGridView1.Columns[1].Name = "Ten";
            dataGridView1.Columns[2].Name = "Gia";
            dataGridView1.Columns[3].Name = "Trang thai";
            dataGridView1.Rows.Clear();
            foreach (var x in _spService.GetSanPham().Where(c => c.TrangThai == 0 ? true : false))
            {
                dataGridView1.Rows.Add(x.Ma, x.Ten, x.GiaBan, (x.TrangThai == 1 ? "Hoạt động" : "Không hoạt động"));
            }
        }
        private void cmb_Loc_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(cmb_Loc.Text == "Hoạt động")
            {
                LocHoatDong();
            }
            if (cmb_Loc.Text == "Không hoạt động")
            {
                LocKoHoatDong();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rd = e.RowIndex;
            if (rd == -1) return;
            txt_Ma.Text = Convert.ToString(dataGridView1.Rows[rd].Cells[0].Value);
            txt_Ten.Text = Convert.ToString(dataGridView1.Rows[rd].Cells[1].Value);
            txt_GIaBan.Text = Convert.ToString(dataGridView1.Rows[rd].Cells[2].Value);
            cbx_HoatDong.Checked = Convert.ToString(dataGridView1.Rows[rd].Cells[3].Value) == "Hoạt động";
            cbx_KoHoatDong.Checked = Convert.ToString(dataGridView1.Rows[rd].Cells[3].Value) == "Không hoạt động";
           
        }

        private void cbx_HoatDong_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_HoatDong.Checked == true)
            {
                cbx_KoHoatDong.Checked = false;
            }

            if (cbx_KoHoatDong.Checked == true)
            { 
                cbx_HoatDong.Checked = false;
            };
                    
        }

        private void cbx_KoHoatDong_CheckedChanged(object sender, EventArgs e)
        {

            if (cbx_KoHoatDong.Checked == true)
            {
                cbx_HoatDong.Checked = false;
            };
            if (cbx_HoatDong.Checked == true)
            {
                cbx_KoHoatDong.Checked = false;
            }

        }
    }
}
