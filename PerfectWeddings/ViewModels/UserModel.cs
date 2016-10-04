using System.ComponentModel.DataAnnotations;

namespace PerfectWeddings.ViewModels
{

    public class UserModel
    {
        [Required(ErrorMessage = "Please Enter User Name")]
        [Display(Name = "User")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Enter Password")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The password and Retype password do not match.")]
        [DataType(DataType.Password)]
        [Display(Name = "ReType Password")]
        public string ReTypePassword { get; set; }
        // public string ImagePath { get; set; }
        [Required(ErrorMessage = "Please Enter First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Please Enter Email Address")]
        [Display(Name = "Email ")]
        public string Email { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public bool IsOwner { get; set; }
        public long UserId { get; set; }
        public int CompanyKey { get; set; }
        [Display(Name = "Company")]
        public string CompanyName { get; set; }
        public string ThemeType { get; set; }
        public string Title { get; set; }
        [Display(Name = "Joined Date")]
        public string JoinedDate { get; set; }

        public ChangePassWord ChangePassWord { get; set; }

        public string CompanyGuid { get; set; }
        public string UserGuid { get; set; }
    }

    public class ChangePassWord
    {
        [Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Please Enter New Password")]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Please Enter Retype Password")]
        [Display(Name = "ReType  Password")]
        public string ReTypeNewPassword { get; set; }
    }
}