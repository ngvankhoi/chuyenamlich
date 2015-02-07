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
        public static readonly DateTime ngaygoc = new DateTime(2015, 2, 19);// ngay 1/1/2015 am lich
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
        }
    }
}
