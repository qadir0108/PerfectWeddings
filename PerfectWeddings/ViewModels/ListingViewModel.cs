using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PerfectWeddings.ViewModels
{
    public class ListingViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public string Adress { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        //public Location Location { get; set; }
        public string Category { get; set; }

        public int Capacity { get; set; }
        public int Cost { get; set; }

        //[Required(ErrorMessage = "Please Enter Name")]
        //[Display(Name = "Name")]
        //public string Name { get; set; }

        //[Required(ErrorMessage = "Please Enter Email")]
        //[Display(Name = "E-mail")]
        //[Remote("CheckExistingEmail", "Account", ErrorMessage = "Email already exists!")]
        //public string Email { get; set; }

        //[Required(ErrorMessage = "Please Enter Wedding Date")]
        //[Display(Name = "Wedding Date")]
        //public DateTime WeddingDate { get; set; }
    }
}