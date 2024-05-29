using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRestaurant
{
     public class Account
    {
        public string tenTaiKhoan;
        public string matkhau;
        public string email;
        public string sdt;
        
        public Account () { }   
        public Account ( string tenTaiKhoan, string matkhau )
        {
            this.tenTaiKhoan = tenTaiKhoan;
            this.matkhau = matkhau;
        }
        
    }
}
