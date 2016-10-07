using PerfectWeddings.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PerfectWeddings.ViewModels
{
    public class RegisterSupplierViewModel

    {
        [Required(ErrorMessage = "Please Enter First Name")]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Please Enter Last Name")]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [Display(Name = "E-mail")]
        [Remote("CheckExistingEmail", "Account", ErrorMessage = "Email already exists!")]
        public string email { get; set; }


        [Required(ErrorMessage = "Please Enter phone no")]
        [Display(Name = "Phone No")]
        public string phoneNo { get; set; }



        [Required(ErrorMessage = "Please enter message")]
        [Display(Name = "Message")]
        public string message { get; set; }


        public EnquiryCategoryEnum category { get; set; }
    }
}