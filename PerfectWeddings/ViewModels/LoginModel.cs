using System.ComponentModel.DataAnnotations;

namespace PerfectWeddings.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please Enter a User Name")]        
        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "User Name")]
        public string userName { get; set; }
        [Required(ErrorMessage = "Please Enter a Password")]
        [DataType(DataType.Text)]       
        [Display(Name = "Password")]
        public string Password { get; set; }

       
    }
}