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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
                

        private void btnchuyen_Click(object sender, EventArgs e)
        {
            NgayAmLich kq = Soc.TimNgayAm(dpk_ngayduong.Value); ;

            lb_ketqua.Text = kq.ToString(FORMAT.DAI);
            lb_ngaybt.Text = kq.ToString();

        }
    }
}
