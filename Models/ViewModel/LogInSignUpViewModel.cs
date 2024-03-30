using System.ComponentModel.DataAnnotations;

namespace WebData.Models.ViewModel
{
    public class LogInSignUpViewModel
    {
        [Key]

        [Required(ErrorMessage =" Please enter username")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Please enter Password")]
        public string Password { get; set; }
        [Required(ErrorMessage ="Please Check box")]
        public bool IsRemember { get; set; }


    }
}
