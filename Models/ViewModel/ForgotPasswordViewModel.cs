using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace WebData.Models.ViewModel
{
    public class ForgotPasswordViewModel
    {
        
        [EmailAddress]
        public string Email { get; set; }
        public bool EmailSent { get; set; }
    }
}
