

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace WebData.Models.ViewModel
{
    public class SignUpUserViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter Username")]
        [Remote(action: "UsernameExist",controller:"Account")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter Email")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9,-]+\.[a-z]{2,4}",ErrorMessage ="enter valid mail")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please enter Mobile")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-.]?([0-9]{3})[-.]?([0-9]{4})$",ErrorMessage ="enter valid number")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [RegularExpression(@"^\(?([A-Z]{1})\)?[-.]?([a-z]{4})[-.]?([0-9]{1})$", ErrorMessage ="enter valid Password")]
       
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter ConfirmPassword")]
        [Compare("Password", ErrorMessage = ("confirm password can't match !"))]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Please Checkbox")]
        public bool IsActive { get; set; }
        public bool IsRemember { get; set; }

    }
}
