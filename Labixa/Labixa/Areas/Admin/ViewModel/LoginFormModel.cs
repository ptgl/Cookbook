using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Labixa.Areas.Admin.ViewModel
{
    public class LoginFormModel
    {
        public LoginFormModel()
        {
            
        }
       
        [Required(ErrorMessage = "Please enter your name")]
        public string name { get; set; }
         [Required(ErrorMessage = "Please enter your email")]
        public string email { get; set; }
         [Required(ErrorMessage = "Please enter your password")]
        public string pass { get; set; }
         [Required(ErrorMessage = "Please enter your confirm password")]
        public string cfpass { get; set; }
       
    }
}