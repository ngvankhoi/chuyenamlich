using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuyenAmLich
{
    
    public partial class ChuongTrinhChuyenNgay : Form
    {
        public ChuongTrinhChuyenNgay()
        {
            InitializeComponent();
        }
        NgayAmLich ngayam = new NgayAmLich();
        private void Form1_Load(object sender, EventArgs e)
        {

        }
                

        private void btnchuyen_Click(object sender, EventArgs e)
        {
            NgayAmLich kq = Soc.TimNgayAm(dpk_ngayduong.Value); ;

            lb_ketqua.Text = kq.ToString(FORMAT.DAI);
            lb_ngaybt.Text = kq.ToString();

        }

        private void tb_nam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {

                TimCacThangTrongNam(int.Parse(tb_nam.Text));
                cbb_thang.Focus();
                SendKeys.Send("{Tab}"); ;
            }
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }        
        private void TimCacThangTrongNam(int p)
        {            
            ngayam.Nam = p;
            cbb_thang.DataSource = ngayam.LayDanhSachThang();
            cbb_thang.DisplayMember = "thangam";
            cbb_thang.ValueMember = "thangduong";
        }

        private void tb_nam_Validated(object sender, EventArgs e)
        {

        }

        private void cbb_thang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbb_thang.DataSource!=null)
            {
                try{
                    ngayam.Thang = int.Parse(cbb_thang.Text);
                    cbb_ngay.DataSource = ngayam.LayDanhSachNgay();
                }
                catch
                {}
            }
        }

        private void cbb_ngay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_ngay.DataSource != null)
            {
                try{
                    ngayam.Ngay = int.Parse(cbb_ngay.Text);
                }
                catch
                {}
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lb_kqNgayduong.Text = ngayam.getNgayDuongLich().ToString("dd/MM/yyyy");
        }
    }
}