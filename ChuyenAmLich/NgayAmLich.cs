using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuyenAmLich
{
    public enum FORMAT
    {
        DAI,
        NGAN,
    }
    public class NgayAmLich
    {
        
        static String[] CAN = { "Canh", "Tân", "Nhâm", "Quý", "Giáp", "Ất", "Bính", "Đinh", "Mậu", "Kỷ" };
        static String[] CHI = { "Thân", "Dậu", "Tuất", "Hợi", "Tý", "Sửu", "Dần", "Mão", "Thìn", "Tỵ", "Ngọ", "Mùi" };
        int ngay = 1, thang = 1, nam;
        Soc _soc;
        public NgayAmLich()
            : this(Soc.SOCGOC)
        {
        }

        public NgayAmLich(Soc soc)
        {
            _soc = soc;
            thang = soc.Thang;
            nam = soc.Nam;
        }

        public NgayAmLich(DateTime ngayduong)
            : this(Soc.TimSoc(ngayduong))
        {
            ngay = ngayduong.Subtract(_soc.NgayDuongLich).Days + 1;
        }
        public int Ngay
        {
            set
            {
                ngay = value;
            }
            get
            {
                return ngay;
            }
        }
        public int Thang
        {
            set
            {
                thang = value;
            }
            get
            {
                return thang;
            }
        }
        public int Nam
        {
            set
            {
                nam = value;
            }
            get
            {
                return nam;
            }
        }

        public override string ToString()
        {
            return ToString(FORMAT.NGAN);
        }
        public string ToString(FORMAT format)
        {
            String rs = null;
            switch (format)
            {
                case FORMAT.DAI:
                    rs = " Ngày " + ngay + " Tháng " + thang + " năm " + CAN[nam % 10] + " " + CHI[nam % 12];
                    break;

                case FORMAT.NGAN: rs = ngay + "/" + thang + "/" + nam;
                    break;
                default:
                    rs = ngay + "/" + thang + "/" + nam;
                    break;
            }
            return rs;
        }
    }
}
