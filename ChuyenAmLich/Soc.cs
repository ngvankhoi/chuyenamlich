using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuyenAmLich
{
    public enum KIEUTHANG /// Kiểu tháng âm lịch, Tháng đủ hay tháng thiếu
    {
        THIEU,
        DU,
    }

    public class Soc // thoi diem bat dau cua thang am lich
    {

        const double SONGAYTRONGTHANG = 29.53058868;
        /// <summary>
        /// lấy sóc bắt đầu từ ngày 19/2/2015 (tức 1/1/2015 âm lịch)làm sóc gốc
        /// </summary>
        public static Soc SOCGOC {
            get
            {
                if (socgoc == null)
                {
                    socgoc = new Soc();
                    socgoc.namam = 2015;
                    socgoc.thangam = 1;
                }
                return socgoc;
            }
        }
        static Soc socgoc;

        public static Soc TimSoc(DateTime ngayduong )
        {
            Soc result;
            if(ngayduong >= SOCGOC.NgayDuongLich )            
                for (result = SOCGOC; !result.ChuaNgayDuongLich(ngayduong); result = result.SocSau) ;
            else
                for (result = SOCGOC; !result.ChuaNgayDuongLich(ngayduong); result = result.SocTruoc) ;
            return result;
        }

        public static NgayAmLich TimNgayAm(DateTime ngayduong)
        {                     
            return new NgayAmLich(ngayduong);
        }
        KIEUTHANG kieuSoc;
        /// <summary>
        /// kiểu tháng đủ hay thiếu
        /// </summary>
        public KIEUTHANG KieuSoc 
        {
            get { return kieuSoc; }
        }

        /// <summary>
        ///số ngày tính từ ngày gốc
        /// </summary>
        double vectorNgay;
        double phanduNgay;
        //public int VectorNgay 
        //{
        //    get
        //    {
        //        return vectorNgay;
        //    }
        //}

        bool nhuan=false;
        /// <summary>
        /// là tháng nhuận?
        /// </summary>
        public bool ThangNhuan
        {
            get
            {
                return nhuan;
            }
        }

        int thangam=-1,namam=-1;
        /// <summary>
        /// tháng trong âm lịch  
        /// </summary>
        public int Thang
        {
            get
            {                
                if (thangam == -1) // tháng chưa được tính
                {
                    if (this.ChuaTietKhi(TietKhi.DONGCHI)) // tháng 11 là tháng chứa tiết khí đông chí
                        thangam = 11;
                    else
                    {
                        Soc thang11truoc;
                        for (thang11truoc = this.SocTruoc; thang11truoc.thangam != 11 && !thang11truoc.ChuaTietKhi(TietKhi.DONGCHI); thang11truoc = thang11truoc.SocTruoc) ;
                        
                        Soc thang11sau;
                        for (thang11sau = this.SocSau; thang11sau.Thang != 11; thang11sau = thang11sau.SocSau) ;
                       
                        if (thang11sau.NgayDuongLich.Subtract(thang11truoc.NgayDuongLich).Days <= 365) // nếu tháng 11 sau cách tháng 11 trước nhỏ hơn 365 ngày thì không phải năm nhuận
                        {                           
                            for(Soc t = thang11truoc.SocSau;t!=thang11sau;t=t.SocSau )
                            {
                                t.thangam = (t.SocTruoc.Thang % 12) + 1;                              
                            }
                        }
                        else// là năm nhuận, phải tìm tháng nhuận
                        {
                            bool bietthangnhuan = false;
                            for (Soc t = thang11sau.SocTruoc; t != thang11truoc; t = t.SocTruoc)
                            {
                                bool chuatietkhi = false;
                                foreach(TietKhi tk in TietKhi.TietKhiTrongNam )  // kiểm tra tháng có chứa bất kì tiết khí nào trong năm không
                                {
                                    if (t.ChuaTietKhi(tk))
                                    {
                                        chuatietkhi = true;
                                        break;
                                    }
                                }
                                if (chuatietkhi || bietthangnhuan)
                                    if (!t.SocSau.ThangNhuan)
                                        t.thangam = ((t.SocSau.Thang+10) % 12)+1 ;
                                    else
                                        t.thangam = t.SocSau.Thang;
                                else
                                {
                                    t.thangam = ((t.SocSau.Thang+10) % 12) +1;
                                    t.nhuan = true;
                                    bietthangnhuan = true;
                                }
                            }
                        }
                    }
                }
                return thangam;
            }
        }

        /// <summary>
        /// Năm trong âm lịch
        /// </summary>
        public int Nam
        {
            get {
                if(namam == -1)
                {
                    if (Thang >= 1 && Thang <= 11)
                        namam = NgayDuongLich.Year;
                    else
                    {
                       if(NgayDuongLich.Month==Thang)
                           namam = NgayDuongLich.Year;
                        else
                           namam = NgayDuongLich.Year-1;
                    }
                }
                return namam;
            }
        }
       

        private Soc()
        {
            kieuSoc = KIEUTHANG.THIEU;
            vectorNgay = 0.183532070;  
            //vectorNgay = 0.32;  
            duonglich = new DateTime(2015, 2, 19);
        }

        private Soc(Soc psoctruoc, double songay)
        {
            vectorNgay = songay;
            double Songay = songay - (long)psoctruoc.vectorNgay ;       
            if (SONGAYTRONGTHANG+(Songay-(long)Songay) >= 30)
                kieuSoc = KIEUTHANG.DU;
            else
                kieuSoc = KIEUTHANG.THIEU;
            duonglich = psoctruoc.NgayDuongLich.AddDays((long)Songay);
            socTruoc = psoctruoc;            
            socSau = null;
        }

        private Soc(double songay,Soc psocsau)
        {
            vectorNgay = songay;
            double Songay = (psocsau.vectorNgay + ((long)Math.Abs(vectorNgay) + 1)) - (long)(vectorNgay + ((long)Math.Abs(vectorNgay) + 1));                 
            if (Songay >= 30)
                kieuSoc = KIEUTHANG.DU;
            else
                kieuSoc = KIEUTHANG.THIEU;
            duonglich = psocsau.NgayDuongLich.AddDays(-(long)Songay);
            socSau = psocsau;
            
            socTruoc = null;
        }


        DateTime duonglich;
        /// <summary>
        /// Ngày dương lịch bắt đầu của sóc
        /// </summary>
      public  DateTime NgayDuongLich
        {
            get
            {
                return duonglich;
            }
        }
        /// <summary>
        /// ngày dương lịch cuối sóc
        /// </summary>
       public DateTime NgayCuoiSoc
        {
            get
            {
                if (kieuSoc == KIEUTHANG.THIEU)
                    return NgayDuongLich.AddDays(28);
                else
                    return NgayDuongLich.AddDays(29);
            }
        }

        Soc socTruoc=null,socSau=null ;
         /// <summary>
        /// sóc liền sau của sóc hiện tại
        /// </summary>
        public Soc SocSau 
        {
            get {
                if (socSau == null)
                {                  
                        socSau = new Soc(this, vectorNgay + SONGAYTRONGTHANG);//tạo mới sóc sau và gán thuộc tính socTruoc của sóc sau là sóc hiện tại.
                   
                }             
                return socSau;
            }
        }

        /// <summary>
        /// sóc liền trước của sóc hiện tại
        /// </summary>
        public Soc SocTruoc
        {
            get
            {
                if (socTruoc == null)
                {
                   
                   socTruoc = new Soc(vectorNgay - SONGAYTRONGTHANG, this); // tạo mới và gán thuộc tính socsau của sóc trước bằng sóc hiện tại
                  
                }                
                return socTruoc;
            }
        }
        /// <summary>
        /// Kiểm tra một ngày dương lịch có thuộc sóc hiện tại
        /// </summary>
        /// <param name="ngayduong"></param>
        /// <returns></returns>
        public bool ChuaNgayDuongLich(DateTime ngayduong)
        {
            return ngayduong >= NgayDuongLich && ngayduong < SocSau.NgayDuongLich;
        }
        
        /// <summary>
        /// kiểm tra sóc hiện tại có chứa tiết khí không
        /// </summary>
        /// <param name="tiet"></param>
        /// <returns></returns>
        public bool ChuaTietKhi(TietKhi tiet)
        {
            return ChuaNgayDuongLich(tiet.NgayTrongNam(NgayDuongLich.Year));
        }
    }
}
