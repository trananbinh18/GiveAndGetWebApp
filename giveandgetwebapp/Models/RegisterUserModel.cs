using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace giveandgetwebapp.Models
{
    public class RegisterUserModel
    {
        [Required(ErrorMessage ="Trường Tên bắt buộc nhập")]
        public string name { get; set; } 
        public string mssv { get; set; }
        [Required(ErrorMessage = "Trường SDT bắt buộc nhập")]
        public string phone { get; set; }
        [Required(ErrorMessage = "Trường Email bắt buộc nhập")]
        public string email { get; set; }
        [Required(ErrorMessage = "Trường Mật khẩu bắt buộc nhập")]
        public string password { get; set; }
        public string gender { get; set; }

    }
}