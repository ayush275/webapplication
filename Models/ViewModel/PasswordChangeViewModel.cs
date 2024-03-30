
using System.ComponentModel.DataAnnotations;

namespace WebData.Models.ViewModel
{
    public class PasswordChangeViewModel
    {
       

        [Required,DataType(DataType.Password ),Display(Name ="Current password")]
        public string CurrentPassword { get; set; }
        [Required, DataType(DataType.Password),Display(Name ="New password")]
        public string NewPassword { get; set; }
        [Required, DataType(DataType.Password)]
        [Compare("NewPassword",ErrorMessage="Confrim new Password does not match")]
        public string ConfirmPassword { get; set; }

    }
}
