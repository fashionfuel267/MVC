using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceData.ViewModels
{
    public class dbviewModel
    {
    }
    public class ApplicationUserVModel
    {
      //  public string Fullname { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }



    }
    public class LoginVModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
