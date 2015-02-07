using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuyenAmLich
{
   public class NgayAmLich
    {
        int ngay=1, thang=1, nam;
        Soc _soc;
        public NgayAmLich():this(Soc.SOCGOC)
        {             
        }

        public NgayAmLich(Soc soc)
        {
            _soc = soc;
            thang = soc.Thang;
            nam = soc.Nam;
        }

        public NgayAmLich(DateTime ngayduong):this(Soc.TimSoc(ngayduong))
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
            return ngay+"/"+thang+"/"+nam ;
        }
    }
}
