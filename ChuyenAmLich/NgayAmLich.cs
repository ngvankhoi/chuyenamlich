using System;
using System.Collections.Generic;
using System.Data;
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
        public DateTime getNgayDuongLich()
        {
           return _soc.NgayDuongLich;
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

        public DataTable LayDanhSachThang()
        {
            DataTable dtrs = new DataTable();
            dtrs.Columns.AddRange(new DataColumn[] { new DataColumn("thangam"), new DataColumn("thangduong"), new DataColumn("namduong") });

            Soc resul ;
            List<int> lrs = new List<int>();
            if (Nam < Soc.SOCGOC.Nam)
            {
                for (resul = Soc.SOCGOC.SocTruoc; resul.Nam != Nam; resul = resul.SocTruoc) ;
                for (; resul.Nam == Nam; resul = resul.SocTruoc)
                {
                    DataRow ndr = dtrs.NewRow();
                    ndr["thangam"] = resul.ThangNhuan ? (resul.Thang + "N" ): resul.Thang+"";
                    ndr["thangduong"] = resul.NgayDuongLich.Month;
                    ndr["namduong"] = resul.NgayDuongLich.Year;
                    dtrs.Rows.InsertAt(ndr, 0);
                }
            }
            else
            {
                for (resul = Soc.SOCGOC; resul.Nam != Nam; resul = resul.SocSau) ;
                for (; resul.Nam == Nam; resul = resul.SocSau)
                {
                    DataRow ndr = dtrs.NewRow();
                    ndr["thangam"] = resul.ThangNhuan ? (resul.Thang + "N") : resul.Thang + "";
                    ndr["thangduong"] = resul.NgayDuongLich.Month;
                    ndr["namduong"] = resul.NgayDuongLich.Year;
                    dtrs.Rows.Add(ndr);
                }
            }
            return dtrs;
        }
        public int[] LayDanhSachNgay()
        {
            Soc resul;
            List<int> lrs = new List<int>();
            if (Nam < Soc.SOCGOC.Nam)
            {
                for (resul = Soc.SOCGOC.SocTruoc; resul.Nam != Nam; resul = resul.SocTruoc) ;

                for (; resul.Nam == Nam; resul = resul.SocTruoc)
                {
                    lrs.Insert(0, resul.Thang);
                }
            }
            else
            {
                for (resul = Soc.SOCGOC; resul.Nam != Nam; resul = resul.SocSau) ;
                for (; resul.Nam == Nam; resul = resul.SocSau)
                {
                    lrs.Add(resul.Thang);
                }
            }
            return lrs.ToArray();
        }
       public DateTime TimNgayDuong()
        {
            while (!(_soc.Nam == Nam && _soc.Thang == Thang))
            {
                if (_soc.Nam < Nam)
                {
                    _soc = _soc.SocSau;
                }
                else
                    if (_soc.Nam > Nam)
                    {
                        _soc = _soc.SocTruoc;
                    }
                    else //_soc.Nam == Nam
                    {
                        //if(_soc.Thang )
                    }
            }
            return _soc.NgayDuongLich;
        }

    }
}
