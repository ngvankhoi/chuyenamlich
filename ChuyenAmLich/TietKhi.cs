using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuyenAmLich
{
    /// <summary>
    /// Class định nghĩa các 12 tiết khí trong năm
    /// </summary>
    public class TietKhi
    {
        int ngay, thang;
        private TietKhi(int pngay,int pthang)
        {
            ngay = pngay;
            thang = pthang;
        }
        public DateTime NgayTrongNam(int Year)
        {
            return new DateTime(Year, thang, ngay);
        }

        /// Các tiết khí trong Năm
        public static TietKhi XUANPHAN { get { return new TietKhi(20, 3); } } //Xuân Phân ngày 20/3
        public static TietKhi COCVU {  get{ return new TietKhi(19, 4); }} //Cóc Vũ ngày 19/4
        public static TietKhi TIEUMAN {  get{ return new TietKhi(21, 5); }}// Tiểu Man
        public static TietKhi HACHI {  get{ return new TietKhi(22, 6); }}// Hạ chí
        public static TietKhi DAITHU {  get{ return new TietKhi(23, 7); }}// Đại thử
        public static TietKhi XUTHU {  get{ return new TietKhi(23, 8); }}// Xử thử
        public static TietKhi THUPHAN {  get{ return new TietKhi(23, 9); }}// Thu phân
        public static TietKhi SUONGGIANG {  get{ return new TietKhi(23, 10); }}//Sương giáng
        public static TietKhi TIEUTUYET {  get{ return new TietKhi(22, 11); }}//Tiểu Tuyết
        public static TietKhi DONGCHI {  get{ return new TietKhi(22, 12); }}//Đông chí
        public static TietKhi DAIHAN {  get{ return new TietKhi(21, 1); }}//Đại Hàn
       /// <summary>
       /// Danh sách các tiết khí trong năm theo thứ tự.
       /// </summary>
        static public TietKhi[] TietKhiTrongNam 
        {
            get
            {
                return new TietKhi[]{XUANPHAN,COCVU,TIEUMAN,HACHI,DAITHU,XUTHU,THUPHAN,SUONGGIANG,TIEUTUYET,DONGCHI,DAIHAN };
            }
        }
    }
}
