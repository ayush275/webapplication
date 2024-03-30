using Microsoft.EntityFrameworkCore;
using WebData.Models;
using WebData.Models.Account;

namespace WebData.Models
{
    public class studentDbContext : DbContext
    {
        public studentDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<student> student{ get; set; } = null !;
        public virtual DbSet<User> userlogin { get; set; } = null!;
       
    }
}

