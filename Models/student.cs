

using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebData.Models
{
    public class student
    {
        [Key]
        public int Id { get; set; }
 
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string city { get; set; }

    }
}
