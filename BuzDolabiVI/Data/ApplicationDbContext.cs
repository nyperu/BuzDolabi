using BuzDolabiVI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BuzDolabiVI.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserDetails>
    {
        public DbSet<Yorum> Yorum { get; set; }
        public DbSet<Tarifler1> Tarifler1 { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
       
    }
}